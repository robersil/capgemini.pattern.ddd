using Dapper;
using DDD.Domain.Employee;
using DDD.Domain.Interface.EmployeeRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DDD.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("stringConnection");
        }
        public List<Employees> Get()
        {
            var connection = new SqlConnection(_connectionString);
            var employees = connection.Query<Employees>("SELECT [id]" +
                                                         ", [Name]" +
                                                         ", [LastName]" +
                                                         ", [Position]" +
                                                         "FROM [dbo].[Employees]");

            return employees.ToList();
        }

        public void Post(Employees employees)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into Employees (Name, LastName, Position) values (@name, @lastName, @position)";

            connection.Execute(query, new { name = employees.Name, lastName = employees.LastName, position = employees.Position });
        }
    }
}
