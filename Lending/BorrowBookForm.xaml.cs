using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lending
{
    /// <summary>
    /// Interaction logic for BorrowBookForm.xaml
    /// </summary>


    public struct Item
    {
        public string itemName { get; set; }
        public string isbn { get; set; }
        public string author { get; set; }
    }

    public struct Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }

    public partial class BorrowBookForm : Window
    {

        string booksPath = "Resources/Books.xml";
        string studentPath = "Resources/Students.xml";

        List<Model.Book> books = new List<Model.Book>();
        List<Model.Student> students = new List<Model.Student>();


        public BorrowBookForm()
        {
            InitializeComponent();
            populateBookList();
            populateStudentList();
        }

        private void BorrowBook(object sender, RoutedEventArgs e)
        {
            if (studentList.SelectedItem != null && bookList.SelectedItem != null)
            {
                var selectedStudent = (Lending.Person)studentList.SelectedItem;
                var selectedBook = (Lending.Item)bookList.SelectedItem;

                //First we have to store the selected Student object

                Model.Student borrowedByStudent = new Model.Student();

                foreach (Model.Student student in students) if (student.Email == selectedStudent.email) borrowedByStudent = student;

                //We search for the exact same book by ISBN, if it matches we run the LoanBook function with the selected student
                //Also we delete it from the ListView

                foreach (Model.Book book in books)
                {
                    if (book.ISBN == selectedBook.isbn)
                    {
                        book.LoanBook(borrowedByStudent, booksPath);
                        bookList.Items.RemoveAt(bookList.SelectedIndex);
                    }
                }

            } else MessageBox.Show("No items selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void populateBookList()
        {
            books = Model.Book.LoadBooks(booksPath);
            foreach (Model.Book item in books)
            {
                //Check whether it's borrowed or not. If it isn't then add to the ListView
                if (item.BorrowedBy == "")
                    bookList.Items.Add(new Item
                    {
                        itemName = item.Title,
                        isbn = item.ISBN,
                        author = item.Author.FirstName + " " + item.Author.LastName
                    });
            }
        }

        private void populateStudentList()
        {
            students = Model.Student.LoadStudent(studentPath);
            foreach (Model.Student person in students)
            {
                studentList.Items.Add(new Person
                {
                    firstName = person.FirstName,
                    lastName = person.LastName,
                    email = person.Email
                });
            }
        }
    }
}
