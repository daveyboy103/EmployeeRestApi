using System;

namespace EmployeeModels.Dtos
{
    public record Order(
        int OrderId,
        string CustomerId,
        int EmployeeId,
        DateTime OrderDate,
        DateTime RequiredDate,
        DateTime ShippedDate,
        int ShipVia,
        string Freight,
        string ShipName,
        string ShipAddress,
        string ShipCity,
        string ShipRegion,
        string ShipPostalCode,
        string ShipCountry
    );
}