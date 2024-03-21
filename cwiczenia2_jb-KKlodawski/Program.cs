using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };
            using var csvReader = new CsvReader(File.OpenText(args[0]),csvConfig);
            string value;
            var data = new List<Student>();
            var logs = new List<String>();

            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    var x = value.Split(',');
                    if (x.Length != 9)
                    {
                        logs.Add("Błąd przy wczytywaniu studenta w wierszu " + value);
                        continue;
                    }
                    var tmpStudy = new Studies(x[2], x[3]);
                    var tmpstud = new Student(x[0], x[1], tmpStudy, x[4], x[5], x[6], x[7], x[8]);
                    if(data.Exists(s => s.index == tmpstud.index && s.name == tmpstud.name && s.surname == tmpstud.surname)
                       )
                    {
                        Student s = data.Find(s => s.index == tmpstud.index && s.name == tmpstud.name && s.surname == tmpstud.surname);
                        if (!s.study.Exists(s => s.mode == tmpStudy.mode && s.name == tmpStudy.name))
                        {
                            data.Find(s => s.index == tmpstud.index && s.name == tmpstud.name && s.surname == tmpstud.surname).study.Add(tmpStudy);
                        }
                        else logs.Add("Nieunikatowy student " + tmpstud.toString());
                    }
                    else
                    {
                        data.Add(tmpstud);
                    }
                }
            }
            var template = new
            {
                CreatedAt = DateTime.Now,
                Author = "Kamil Kłodawski",
                Students = data.Select(s => new
                {
                    Index = "s" + s.index,
                    Name = s.name,
                    Surname = s.surname,
                    Email = s.email,
                    BirthDate = s.birthday.Year + "/" + s.birthday.Month + "/" + s.birthday.Day,
                    MothersName = s.mothersName,
                    FathersName = s.fathersName,
                    Studies = s.study.Select(st => new
                    {
                        Name = st.name,
                        Mode = st.mode
                    }).ToList()
                }).ToList()
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string json = JsonSerializer.Serialize(template, options);
            File.WriteAllText(args[1], json);

            using (StreamWriter sw = File.CreateText("logs.txt"))
            {
                foreach (String log in logs) sw.WriteLine(log);   
            };
            

        }
        
    }
}