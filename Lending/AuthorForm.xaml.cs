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
using System.Text.RegularExpressions;

namespace Lending
{
    /// <summary>
    /// Interaction logic for AuthorForm.xaml
    /// </summary>
    public partial class AuthorForm : Window
    {

        string filePath = "Resources/Authors.xml";

        public AuthorForm()
        {
            InitializeComponent();
        }

        private void CreateAuthor(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = firstNameBox.Text;
                string lastName = lastNameBox.Text;

                // Input validation
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    throw new ArgumentException("Missing data! Please fill out all fields.");
                }

                Model.Author.addAuthor(new Model.Author(firstName, lastName), filePath);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
