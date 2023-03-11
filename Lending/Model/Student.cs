using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Lending.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }

        public Student(string FirstName, string LastName, Address Address, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Email = Email;
        }

        public Student() { }

        public static void addStudent(Student newStudent, string filePath)
        {

            List<Student> students;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("students") { Namespace = "" });
            using (StreamReader reader = new StreamReader(filePath))
            {
                students = (List<Student>)serializer.Deserialize(reader);
            }

            // Add the new Author to the List<Author>
            students.Add(newStudent);

            // Serialize the List<Author> to XML and write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, students);
            }
        }

        public static List<Student> LoadStudent(string filePath)
        {
            List<Student> students = new List<Student>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("students") { Namespace = "" });
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                students = (List<Student>)serializer.Deserialize(stream);
            }

            return students;
        }
    }
}
