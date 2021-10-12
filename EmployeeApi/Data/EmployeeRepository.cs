using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EmployeeModels.Dtos;
using Microsoft.Extensions.Configuration;

namespace EmployeeApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = null;
            await Task.Factory.StartNew(() =>
            {
                string connectionString = _configuration.GetConnectionString("DBConnection");

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand($"select * from Employees where EmployeeID = {id}", conn))
                    {
                        var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            employee = BuildEmployee(dr);
                            break;
                        }
                    }
                }
            });

            return employee;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var ret = new List<Employee>();
            
            await Task.Factory.StartNew(() =>
            {
                string connectionString = _configuration.GetConnectionString("DBConnection");

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("select * from Employees", conn))
                    {
                        var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            var employee = BuildEmployee(dr);

                            ret.Add(employee);
                        }
                    }

                }

            });

            return ret;
        }

        private static Employee BuildEmployee(SqlDataReader sqlDataReader)
        {
            string GetString(SqlDataReader dr, string fieldName)
            {
                if(dr[fieldName] != DBNull.Value)
                    return dr.GetString(dr.GetOrdinal(fieldName));
                return null;
            }

            int? GetInt32(SqlDataReader dr, string fieldName)
            {
                if(dr[fieldName] != DBNull.Value)
                    return dr.GetInt32(dr.GetOrdinal(fieldName));
                return null;
            }

            {
                return new Employee(
                    EmployeeId: sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("EmployeeID")),
                    LastName: GetString(sqlDataReader, "LastName"),
                    FirstName: GetString(sqlDataReader, "FirstName"),
                    Title: GetString(sqlDataReader, "Title"),
                    TitleOfCourtesy: GetString(sqlDataReader, "TitleOfCourtesy"),
                    BirthDate: sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("BirthDate")),
                    HireDate: sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("HireDate")),
                    Address: GetString(sqlDataReader, "Address"),
                    City: GetString(sqlDataReader, "City"),
                    Region: GetString(sqlDataReader, "Region"),
                    PostalCode: GetString(sqlDataReader, "PostalCode"),
                    Country: GetString(sqlDataReader, "Country"),
                    HomePhone: GetString(sqlDataReader, "HomePhone"),
                    Extension: GetString(sqlDataReader, "Extension"),
                    Photo: null,
                    Notes: GetString(sqlDataReader, "Notes"),
                    ReportsTo: GetInt32(sqlDataReader, "ReportsTo"),
                    PhotoPath: sqlDataReader.GetString(sqlDataReader.GetOrdinal("PhotoPath")),
                    DepartmentId: GetInt32(sqlDataReader, "DepartmentID"));
            }
        }
    }
}