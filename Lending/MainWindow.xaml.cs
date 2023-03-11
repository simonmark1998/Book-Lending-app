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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lending
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //Datas
        public static List<Model.Author> authors = new List<Model.Author>();
        public static List<Model.Student> students = new List<Model.Student>();
        public static List<Model.Book> books = new List<Model.Book>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenAuthorForm(object sender, RoutedEventArgs e)
        {
            AuthorForm objAuthorForm = new AuthorForm();
            objAuthorForm.Show();
        }

        private void OpenStudentForm(object sender, RoutedEventArgs e)
        {
            StudentForm objStudentForm = new StudentForm();
            objStudentForm.Show();
        }

        private void OpenBookForm(object sender, RoutedEventArgs e)
        {
            BookForm objBookForm = new BookForm();
            objBookForm.Show();
        }

        private void OpenBorrowBookForm(object sender, RoutedEventArgs e)
        {
            BorrowBookForm objBorrowBookForm = new BorrowBookForm();
            objBorrowBookForm.Show();
        }

        private void OpenMissingBooks(object sender, RoutedEventArgs e)
        {
            MissingBooks objMissingBooks = new MissingBooks();
            objMissingBooks.Show();
        }
    }
}
