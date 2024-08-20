internal class Program
{
    private static void Main(string[] args)
    {
        //The Intersect extension method requires two collections.
        //It returns a new collection that includes common elements
        //that exists in both the collection

        IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
        IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

        var result = strList1.Intersect(strList2);

        foreach (string str in result)
            Console.WriteLine(str);

        Console.WriteLine("-----------------");

        IList<Student> studentList1 = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
        new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };

        IList<Student> studentList2 = new List<Student>() {
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };
         

        var resultList = studentList1.Intersect(studentList2, new StudentComparer()); 
        foreach(Student student in resultList)
        {
            Console.WriteLine(student.StudentName);
        }



    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID &&
                            x.StudentName.ToLower() == y.StudentName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }
}