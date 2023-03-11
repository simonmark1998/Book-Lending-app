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
using System.Text.RegularExpressions;

namespace Lending
{
    /// <summary>
    /// Interaction logic for BookForm.xaml
    /// </summary>
    public partial class BookForm : Window
    {

        string authorsPath = "Resources/Authors.xml";
        string booksPath = "Resources/Books.xml";

        List<Model.Author> authors = new List<Model.Author>();


        private void PopulateComboBox()
        {
            foreach (Model.Author author in authors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = $"{author.FirstName} {author.LastName}";
                authorComboBox.Items.Add(item);
            }
        }

        public BookForm()
        {
            InitializeComponent();
            authors = Model.Author.LoadAuthors(authorsPath);
            PopulateComboBox();
        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {
            try
            {
                string Title = titleBox.Text;
                string ISBN = isbnBox.Text;
                string Publisher = publisherBox.Text;

                // Input validation
                if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(ISBN) || string.IsNullOrEmpty(Publisher) || string.IsNullOrEmpty(authorComboBox.SelectedItem.ToString()))
                {
                    throw new ArgumentException("Missing data! Please fill out all fields.");
                }

                string authorName = authorComboBox.SelectedItem.ToString();

                //Validates both ISBN 10 and ISBN 13 numbers, and confirms ISBN 13 numbers start with only 978 or 979.
                if (!Regex.IsMatch(ISBN, @"^(97(8|9))?\d{9}(\d|X)$"))
                    throw new ArgumentException("Invalid ISBN argument. Please enter a valid 10 digit ISBN number or a 13 digit ISBN starting with 978 or 979");

                Model.Author author = new Model.Author(authorName.Split(' ')[1], authorName.Split(' ')[2]);

                Model.Book.addBook(new Model.Book(Title, ISBN, author, Publisher), booksPath);

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
