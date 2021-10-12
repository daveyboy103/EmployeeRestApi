using System;
using System.Linq;
using EmployeeModels.Storage;
using NUnit.Framework;

namespace EmployeeTests.PropertyBagTests
{
    [TestFixture]
    public class PropertyBagTests
    {
        [Test]
        public void ShouldInitialiseToEmpty()
        {
            var propertyBag = new GenericPropertyBag();
            
            Assert.IsTrue(!propertyBag.Any());
        }

        [Test]
        public void ShouldAddAndRetrieveCustomType()
        {
            var propertyBag = new GenericPropertyBag();
            var customType = new CustomType();
            propertyBag.Add("key", customType);

            var ret = propertyBag.GetPropertyValue<CustomType>("key");
            
            Assert.AreEqual(customType, ret);
        }

        [Test]
        public void ShouldThrowExceptionForWrongTypeRetrieval()
        {
            var propertyBag = new GenericPropertyBag();
            var customType = new CustomType();
            propertyBag.Add("key", customType);

            try
            {
                var ret = propertyBag.GetPropertyValue<string>("key");
            }
            catch (InvalidCastException)
            {
                Assert.Pass();
            }
        }
    }

    public class CustomType
    {
        
    }
}