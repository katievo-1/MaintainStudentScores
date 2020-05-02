using System.Collections.Generic;
using System.IO;
namespace StudentScores
{
    public class StudentDB
    {
        public static char Separator = '|';

        private static string path = "../../MaintainStudentScores.txt";

        public static List<Student> GetStudents()
        {
            if (File.Exists(path))
            {
                var students = new List<Student>();

                foreach (var line in File.ReadLines(path))
                {
                    var studentData = line.Split(Separator);
                    var studentScores = new List<double>();

                    for(int i=1; i<studentData.Length; i++)
                    {
                        studentScores.Add(double.Parse(studentData[i]));
                    }

                    students.Add(new Student(studentData[0], studentScores));
                }

                return students;
            }
            else
            {
                return new List<Student>();
            }
        }

         public static void SaveStudents(IList<Student> students)
        {
            var textOut = new StreamWriter
                (new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (var student in students)
            {
                textOut.WriteLine(student.ToString());
            }

            textOut.Close();
         }
    }
}
