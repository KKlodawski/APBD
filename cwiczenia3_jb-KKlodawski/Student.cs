using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Globalization;
using System.Reflection;

namespace Zadanie3
{
    public class Student
    {

        public string name { get; set; }
        public string surname { get; set; }
        public string studiesName { get; set; }
        public string studiesMode { get; set; }
        public int id { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

        public Student(string name, string surname, string studiesName, string studiesMode, int id, string birthday,
            string email, string mothersName, string fathersName)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.birthday = birthday;
            this.email = email;
            this.mothersName = mothersName;
            this.fathersName = fathersName;
            this.studiesMode = studiesMode;
            this.studiesName = studiesName;
        }

        public String toString()
        {
            return name + " " + surname + " " + id + " " + birthday + " " + mothersName + " " + fathersName;
        }

        public static List<Student> getList()
        {
            List<Student> studentstmp = new List<Student>();
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true
            };
            //var reader = new StreamReader("Data\\data.csv");
            using (var csv = new CsvReader(File.OpenText("Data\\data.csv"), csvConfig))
            {
                csv.Read();
                string value;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        var x = value.Split(',');
                        var tmpstud = new Student(x[0], x[1], x[2], x[3], int.Parse(x[4]), x[5], x[6], x[7], x[8]);
                        studentstmp.Add(tmpstud);
                    }
                }
            }

            return studentstmp;
        }

        public static bool NotEmptyStudent(Student student)
        {
            PropertyInfo[] properties = typeof(Student).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(student);

                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
