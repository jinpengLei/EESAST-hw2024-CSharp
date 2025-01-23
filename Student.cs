namespace StudentGradeManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public interface IStudent
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Dictionary<string, Grade> Grades { get; }
    public void AddGrade(string course, string credit, string score);
    public void AddGrades(List<(string course, int credit, int score)> grades);
    public void RemoveGrade(string course);
    public void RemoveGrades(List<string> courses);
    public int GetTotalCredit();
    public double GetTotalGradePoint();
    public double GetGPA();
    public string ToString();
}

public class Student : IStudent
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Dictionary<string, Grade> Grades { get; }

    public Student(string name, string id)
    {
        Name = name;
        ID = Int32.Parse(id);
        Grades = new Dictionary<string, Grade>();
    }

    public void AddGrade(string course, string credit, string score)
    {
        Grades.Add(course, new Grade(Int32.Parse(credit), Int32.Parse(score)));
    }

    public void AddGrades(List<(string course, int credit, int score)> grades)
    {
        foreach (var grade in grades)
        {
            Grades.Add(grade.course, new Grade(grade.credit, grade.score));
        }
    }

    public void RemoveGrade(string course)
    {
        Grades.Remove(course);
    }

    public void RemoveGrades(List<string> courses)
    {
        courses.ForEach(course => RemoveGrade(course));
    }
    public int GetTotalCredit()
    {
        int totalCredit = 0;
        foreach (var value in Grades.Values)
        {
            totalCredit += value.Credit;
        }
        return totalCredit;
    }
    public double GetTotalGradePoint()
    {
        double totalGradePoint = 0;
        foreach (var value in Grades.Values)
        {
            totalGradePoint += value.GradePoint * value.Credit;
        }
        return totalGradePoint;
    }

    public double GetGPA()
    {
        return GetTotalGradePoint() / GetTotalCredit();
    }

    public override string ToString()
    {
        string str = $"ID: {ID}, name:{Name}, gpa:{GetGPA()}";
        return str;
    }

}
