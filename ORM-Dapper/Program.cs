using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.Write("Enter a new department name: ");
            var newDept = Console.ReadLine();
            repo.InsertDepartment(newDept);

            var depts = repo.GetAllDepartments();
            foreach (var dept in depts)
            {
                Console.WriteLine($"{dept.Name} ({dept.DepartmentID})");
            }
        }
    }
}
