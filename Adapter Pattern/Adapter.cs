using System;
using System.Collections.Generic;

public interface IStudentDataProvider
{
    List<string> GetStudentList();
}

public class StudentDatabase
{
    public List<string> FetchStudentData()
    {
        return new List<string> { "student 1", "stundet 2", "student 3" };
    }
}

public class StudentDatabaseAdapter : IStudentDataProvider
{
    private readonly StudentDatabase studentDatabase;

    public StudentDatabaseAdapter(StudentDatabase studentDatabase)
    {
        this.studentDatabase = studentDatabase;
    }

    public List<string> GetStudentList()
    {
        return studentDatabase.FetchStudentData();
    }
}

class Program
{
    static void Main()
    {
        StudentDatabase studentDb = new StudentDatabase();

        IStudentDataProvider studentDataProvider = new StudentDatabaseAdapter(studentDb);

        List<string> studentList = studentDataProvider.GetStudentList();

        Console.WriteLine("Student List:");
        foreach (var student in studentList)
        {
            Console.WriteLine(student);
        }
    }
}