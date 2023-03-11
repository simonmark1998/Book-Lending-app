using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace Lending.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Author Author { get; set; }
        public string Publisher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BorrowedBy { get; set; }

        public void LoanBook(Student student, string xmlPath)
        {
            // logic for loaning book
            // let's set the latest possible date 9999-12-31T23:59:59 when we borrow a book and set the start date to the actual date
            // set the BorrowedBy string to email of the student, it will function like a primary key in SQL

            this.StartDate = DateTime.Now;
            this.EndDate = new DateTime(9999, 12, 31);
            this.BorrowedBy = student.Email;

            // We should also update the XML file of the Books, where the ISBN matches. ISBN will be like a primary key to Books table

            var doc = XDocument.Load(xmlPath);

            // Find the book element with the matching ISBN
            XElement book = doc.Descendants("Book")
                              .FirstOrDefault(x => (string)x.Element("ISBN") == this.ISBN);

            // Update element values
            book.Element("BorrowedBy").SetValue(student.Email);
            book.Element("StartDate").SetValue(StartDate);
            book.Element("EndDate").SetValue(EndDate);

            // Save the XML back as file
            doc.Save(xmlPath);
        }

        public Book(string Title, string ISBN, Author Author, string Publisher)
        {
            this.Title = Title;
            this.ISBN = ISBN;
            this.Author = Author;
            this.Publisher = Publisher;
            this.BorrowedBy = "";
        }

        public Book() { }

        public static void addBook(Book newBook, string filePath)
        {

            List<Book> books;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("books") { Namespace = "" });
            using (StreamReader reader = new StreamReader(filePath))
            {
                books = (List<Book>)serializer.Deserialize(reader);
            }

            // Add the new Author to the List<Author>
            books.Add(newBook);

            // Serialize the List<Author> to XML and write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, books);
            }
        }

        public static List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new List<Book>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("books") { Namespace = "" });
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                books = (List<Book>)serializer.Deserialize(stream);
            }

            return books;
        }

        public static void deleteBorrow(Book bookToDelete, string xmlPath)
        {
            var doc = XDocument.Load(xmlPath);

            // Find the book element with the matching ISBN
            XElement book = doc.Descendants("Book")
                              .FirstOrDefault(x => (string)x.Element("ISBN") == bookToDelete.ISBN);

            // Update element values
            book.Element("BorrowedBy").SetValue("");
            book.Element("EndDate").SetValue(DateTime.Now);

            doc.Save(xmlPath);
        }
    }
}
