using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadanie3
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private List<Student> students = Student.getList();

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult Get()
        {
            if (students.Count <= 0)
            {
                return NotFound();
            }
            else return Ok(students);
        }

        [HttpGet("{index}")]
        [ResponseCache(NoStore = true)]
        public IActionResult Get(string index)
        {
            try
            {
                int id = int.Parse(index.Substring(1));
                Student tmpstud = students.Find(e => e.id == id);
                if (tmpstud != null) return Ok(tmpstud);
                else return NotFound();
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpPut("{index}")]
        public IActionResult  Put(string index, [FromBody] Student value)
        {
            int id = int.Parse(index.Substring(1));
            Student tmpstud = students.Find(e => e.id == id);
            if (tmpstud == null) return NotFound();
            tmpstud.name = value.name;
            tmpstud.surname = value.surname;
            tmpstud.birthday = value.birthday;
            tmpstud.email = value.email;
            tmpstud.mothersName = value.mothersName;
            tmpstud.fathersName = value.fathersName;
            tmpstud.studiesMode = value.studiesMode;
            tmpstud.studiesName = value.studiesName;
            
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                Delimiter = ","
            };
            using (var writer = new CsvWriter(new StreamWriter("Data\\data.csv"),csvConfig))
            {
                writer.WriteRecords(students);
            }

            return Ok(students.Find(e => e.id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student s)
        {
            if (students.Exists(e => e.id == s.id))
            {
                return Conflict("Not unique index!");
            }
            else if (!(s.id is int))
            {
                return Conflict("Wrong id format!");
            }
            else if (!Student.NotEmptyStudent(s))
            {
                return Conflict("Some data are empty!");
            }
            else
            {
                students.Add(s);
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    Delimiter = ","
                };
                using (var writer = new CsvWriter(new StreamWriter("Data\\data.csv"),csvConfig))
                {
                    writer.WriteRecords(students);
                }

                return Ok(s);
            }
            
        }
        
        [HttpDelete("{index}")]
        public IActionResult Delete(string index)
        {
            int id = int.Parse(index.Substring(1));
            Student tmpstud = students.Find(e => e.id == id);
            if (tmpstud != null)
            {
                students.Remove(tmpstud);
                
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    Delimiter = ","
                };
                using (var writer = new CsvWriter(new StreamWriter("Data\\data.csv"),csvConfig))
                {
                    writer.WriteRecords(students);
                }
                
                return Ok(tmpstud);
            }
            else return NotFound();
        }

      

    }
}
