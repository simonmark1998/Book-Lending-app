# Book Rental Application

This is a book rental application designed for librarians. The main window contains 5 buttons with different functions:

1.  Create Author - allows the user to create an author with a first name and a last name.
2.  Create Student - allows the user to create a student with a first name, last name, address (street, house number, city, postal code), and email.
3.  Create Book - allows the user to create a book with a title, ISBN, author, and publisher.
4.  Borrow Book - allows the user to borrow a book for a student by selecting an available book and a student from the respective lists and clicking the "Borrow" button.
5.  Missing Books - displays a list of borrowed books that have not been returned yet. The user can select a book from the list and click the "Bring Back" button to mark it as returned.

The application stores authors, students, and books in separate XML files located in the Resources folder.

The application was developed using C# and WPF in the .NET framework, with Visual Studio IDE.

## Installation

To install and run the application, follow these steps:

1.  Clone the repository from GitHub to your local machine.
2.  Open the solution file in Visual Studio IDE.
3.  Build the solution and run the application.

## Usage

To use the application, follow these steps:

1.  Click on the desired button to create an author, student, or book.
2.  Fill out the necessary information in the form that appears and click "Save".
3.  To borrow a book, select an available book and a student from the respective lists and click the "Borrow" button.
4.  To mark a borrowed book as returned, select it from the "Missing Books" list and click the "Bring Back" button.
