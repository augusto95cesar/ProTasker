using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using ProTasker.API.DTOs;
using ProTasker.API.Services;
using System.Data;

namespace ProTasker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //string connectionString = "Data Source=database.db";

            //using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            //{
            //    dbConnection.Open();

            //    // Exemplo: Criar tabela
            //    string createTableQuery = @"
            //    CREATE TABLE IF NOT EXISTS Products (
            //        Id INTEGER PRIMARY KEY AUTOINCREMENT,
            //        Name TEXT NOT NULL,
            //        Price REAL NOT NULL
            //    );";
            //    dbConnection.Execute(createTableQuery);

            //    // Exemplo: Inserir dados
            //    string insertQuery = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
            //    dbConnection.Execute(insertQuery, new { Name = "Product A", Price = 9.99 });

            //    // Exemplo: Consultar dados
            //    string selectQuery = "SELECT * FROM Products";
            //    var products = dbConnection.Query<Product>(selectQuery);

            //    foreach (var product in products)
            //    {
            //        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            //    }
            //}

            return Ok();
        }


        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            List<GetAllProjetosDTO> projetos = new ProjetoService().GetAll(userId);

            return Ok(projetos);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
