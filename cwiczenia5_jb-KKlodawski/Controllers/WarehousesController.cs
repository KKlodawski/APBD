using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie5.DTOs;
using Zadanie5.Services;

namespace Zadanie5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddProduct(ProductDTO product)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();

                using SqlCommand prodIdCommand = 
                    new SqlCommand($"SELECT COUNT(IdProduct) FROM Product WHERE IdProduct={product.IdProduct}", connection);
                using SqlCommand warehouseIdCommand = 
                    new SqlCommand($"SELECT COUNT(IdWarehouse) FROM Warehouse WHERE IdWarehouse={product.IdWarehouse}", connection);

                var prodExists = (int?)prodIdCommand.ExecuteScalar();
                var warehouseExists = (int?)warehouseIdCommand.ExecuteScalar();

                if (prodExists <= 0 || warehouseExists <= 0)
                {
                    return BadRequest("Product or Warehouse doesn't exists!");
                }

                using SqlCommand orderExistsCommand =
                    new SqlCommand(
                        $"SELECT IdOrder FROM \"Order\" WHERE IdProduct={product.IdProduct} AND Amount={product.Amount} AND CreatedAt<'{product.CreatedAt}' AND FulfilledAt IS NULL",
                        connection);
                
                var orderExists = (int?)orderExistsCommand.ExecuteScalar();

                if (orderExists==null) return BadRequest("Given order don't match any existing order or is already fulfilled!");

                using SqlCommand containOrderCommand = 
                    new SqlCommand($"SELECT Count(IdProductWarehouse) FROM Product_Warehouse WHERE IdOrder={orderExists}",
                        connection);

                var containOrder = (int?)containOrderCommand.ExecuteScalar();
                
                if (containOrder >= 1) return BadRequest("Order already exists!");

                using SqlCommand updateOrder = 
                    new SqlCommand($"UPDATE \"Order\" SET FulfilledAt=CONVERT(DATETIME,'{DateTime.Now.ToString()}',104) WHERE IdOrder={orderExists}",connection);

                updateOrder.ExecuteNonQuery();

                using SqlCommand priceCommand = 
                    new SqlCommand($"SELECT Price FROM Product WHERE IdProduct={product.IdProduct}",connection);

                decimal price = (decimal)priceCommand.ExecuteScalar() * product.Amount;

                using SqlCommand insertNewRowInProdWare = 
                    new SqlCommand($"INSERT INTO Product_Warehouse VALUES ({product.IdWarehouse},{product.IdProduct},{orderExists},{product.Amount},{price.ToString().Replace(",",".")},CONVERT(DATETIME,'{DateTime.Now.ToString()}',104)); SELECT SCOPE_IDENTITY()",connection);
                
                int inserted = (int)(decimal)insertNewRowInProdWare.ExecuteScalar();
               
                return Ok(inserted);
            }
            
        }
        
    }
}
