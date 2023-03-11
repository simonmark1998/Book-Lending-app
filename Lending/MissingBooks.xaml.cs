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
    /// Interaction logic for MissingBooks.xaml
    /// </summary>

    public struct BorrowedItem
    {
        public string bookName { get; set; }
        public string isbn { get; set; }
        public string email { get; set; }
        public DateTime startDate { get; set; }
    }

    public partial class MissingBooks : Window
    {

        string booksPath = "Resources/Books.xml";

        List<Model.Book> books = new List<Model.Book>();

        public MissingBooks()
        {
            InitializeComponent();
            populateBookList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (borrowedBookList.SelectedItem != null)
            {
                var selectedLending = (Lending.BorrowedItem)borrowedBookList.SelectedItem;

                //We search by the ISBN, if it matches we delete the borrow and remove it from the listview

                foreach (Model.Book book in books)
                {
                    if (book.ISBN == selectedLending.isbn)
                    {
                        Model.Book.deleteBorrow(book, booksPath);
                        borrowedBookList.Items.RemoveAt(borrowedBookList.SelectedIndex);
                    }
                }
            } else MessageBox.Show("No items selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void populateBookList()
        {
            books = Model.Book.LoadBooks(booksPath);
            foreach (Model.Book item in books)
            {

                if (item.BorrowedBy != "")
                    borrowedBookList.Items.Add(new BorrowedItem
                    {
                        bookName = item.Title,
                        isbn = item.ISBN,
                        email = item.BorrowedBy,
                        startDate = item.StartDate
                    });
                ;
            }
        }
    }
}
