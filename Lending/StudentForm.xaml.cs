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
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {

        string filePath = "Resources/Students.xml";

        public StudentForm()
        {
            InitializeComponent();
        }

        private void CreateStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = firstNameBox.Text;
                string lastName = lastNameBox.Text;
                string street = streetBox.Text;
                string city = cityBox.Text;
                string postalCode = postalCodeBox.Text;
                string houseNumber = houseNumberBox.Text;
                string emailAddress = emailBox.Text;

                // Input validation
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(postalCode) || string.IsNullOrEmpty(houseNumber) || string.IsNullOrEmpty(emailAddress))
                {
                    throw new ArgumentException("Missing data! Please fill out all fields.");
                }

                if (!Regex.IsMatch(street, @"^[A-Za-z\s]+$"))
                    throw new ArgumentException("Street can only contain letters and spaces.");
                if (!Regex.IsMatch(city, @"^[A-Za-z\s]+$"))
                    throw new ArgumentException("City can only contain letters and spaces.");
                if (!Regex.IsMatch(postalCode, @"^\d{4,5}$"))
                    throw new ArgumentException("Postal code must be a 4 or a 5 digit number.");
                if (!Regex.IsMatch(houseNumber, @"^\d+$"))
                    throw new ArgumentException("House number must be a number.");
                if (!Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("Invalid email address.");

                //If everything passed, add it to XML

                Model.Address newAddress = new Model.Address(street, houseNumber, postalCode, city);

                Model.Student.addStudent(new Model.Student(firstName, lastName, newAddress, emailAddress), filePath);

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
