using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Zadanie5.DTOs;

namespace Zadanie5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        [HttpPost]
        public ActionResult AddProductProc(ProductDTO product)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = 
                       new SqlCommand($"BEGIN exec AddProductToWarehouse {product.IdProduct},{product.IdWarehouse},{product.Amount},'{product.CreatedAt}' END", connection))
                {
                    Console.WriteLine(command.CommandText);
                    command.ExecuteNonQuery();

                    return Ok();
                }
            }
        }
    }
}