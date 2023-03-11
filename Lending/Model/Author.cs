using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Lending.Model
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public Author()
        {

        }

        public static void addAuthor(Author newAuthor,string filePath)
        {

            List<Author> authors;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Author>), new XmlRootAttribute("authors") { Namespace = "" });
            using (StreamReader reader = new StreamReader(filePath))
            {
                authors = (List<Author>)serializer.Deserialize(reader);
            }

            // Add the new Author to the List<Author>
            authors.Add(newAuthor);

            // Serialize the List<Author> to XML and write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, authors);
            }
        }

        public static List<Author> LoadAuthors(string filePath)
        {
            List<Author> authors = new List<Author>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Author>), new XmlRootAttribute("authors") { Namespace = "" });
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                authors = (List<Author>)serializer.Deserialize(stream);
            }

            return authors;
        }
    }
}
