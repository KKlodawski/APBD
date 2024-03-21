
public class Student
{
    public String name { get; set; }
    public String surname { get; set; }
    public List<Studies> study { get; set; } = new List<Studies>();
    public String index { get; set; }
    public DateTime birthday { get; set; }
    public String email { get; set; }
    public String mothersName { get; set; }
    public String fathersName { get; set; }

    public Student() { }
    public Student(string name, string surname, Studies study, String index, string birthday, string email, string mothersName, string fathersName)
    {
        this.name = name;
        this.surname = surname;
        this.study.Add(study);
        this.index = index;
        this.birthday = DateTime.Parse(birthday);
        this.email = email;
        this.mothersName = mothersName;
        this.fathersName = fathersName;
    }

    public String toString()
    {
        string stud = "";
        foreach(Studies std in study)
        {
            stud += "[" + std.toString() + "] ";
        }
        return name + " " + surname + " " + index + " " + birthday + " " + mothersName + " " + fathersName + " " + stud;
    }

    public String showStudies() {
        String tmp = "";
        foreach (Studies s in study)
        {
            tmp += s.name + " " + s.mode + " ";
        }
        return tmp;
        
    }
    

}
public struct Studies
{
    public String name { get; set; }
    public String mode { get; set; }

    public Studies(String name, String mode)
    {
        this.name = name;
        this.mode = mode;
    }

    public string toString() => this.name + " " + this.mode;
}