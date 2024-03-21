using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Zadanie4.DTOs;

namespace Zadanie4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get([FromQuery]string? param)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();

                if (param == null) param = "Name";
                if (!(param.ToLower().Equals("name") || param.ToLower().Equals("description") || param.ToLower().Equals("category") || param.ToLower().Equals("area"))) return BadRequest();

                using SqlCommand command = new SqlCommand($"SELECT * FROM Animal ORDER BY {param}", connection);

                SqlDataReader reader = command.ExecuteReader();

                List<AnimalDTO> list = new List<AnimalDTO>();

                while (reader.Read())
                {
                    int id = Convert.ToInt16(reader["IdAnimal"]);
                    string? name = Convert.ToString(reader["Name"]);
                    string? Description = Convert.ToString(reader["Description"]);
                    string? Category = Convert.ToString(reader["Category"]);
                    string? Area = Convert.ToString(reader["Area"]);
                    Console.WriteLine($"{name} | {Description} | {Category} | {Area}");
                    list.Add(new AnimalDTO(id, name, Description, Category, Area));

                }

                reader.Close();
                connection.Close();

                return Ok(list);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]AnimalDTO animal)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();

                using SqlCommand command = new SqlCommand($"INSERT INTO Animal VALUES ('{animal.Name}','{animal.Description}','{animal.Category}','{animal.Area}')", connection);
                Console.WriteLine(command.CommandText);
                var numberOfRows = (int?)command.ExecuteNonQuery();
                connection.Close();

                return Ok(animal);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody]AnimalDTO animal)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();
                
                using SqlCommand command = 
                    new SqlCommand($"UPDATE Animal SET name='{animal.Name}', description='{animal.Description}', category='{animal.Category}', area='{animal.Area}' where IdAnimal='{animal.IdAnimal}'", connection);
                var numberOfRows = (int?)command.ExecuteNonQuery();
                connection.Close();
                if (numberOfRows < 1)
                {
                    return BadRequest("Niepoprawne Id!");
                }
                
            }
            return Ok(animal);
        }

        [HttpDelete]
        public ActionResult Delete(int IdAnimal)
        {
            using (SqlConnection connection =
                   new SqlConnection(
                       "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24777;Integrated Security=True"))
            {
                connection.Open();
                using SqlCommand command = 
                    new SqlCommand($"DELETE FROM Animal WHERE IdAnimal='{IdAnimal}'", connection);
                var numberOfRows = (int?)command.ExecuteNonQuery();
                if (numberOfRows < 1)
                {
                    return BadRequest("Niepoprawne Id!");
                }
                
                connection.Close();
            }
            return Ok(IdAnimal);
        }
    }
}
