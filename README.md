
# Book Rental Application

This is a book rental application designed for use by librarians or other staff members who manage book rental services. The application features a main window with 5 buttons that allow users to perform different functions.

## Features

1.  **Create Author:** This button allows users to create a new author by entering their first name and last name.
2.  **Create Student:** This button allows users to create a new student by entering their first name, last name, address (street, house number, city, postal code), and email.
3.  **Create Book:** This button allows users to create a new book by entering its title, ISBN, author, and publisher.
4.  **Borrow Book:** This button allows users to borrow a book from the library by selecting a book and a student from the list of available books and students. Once a book is borrowed, it is removed from the list of available books and added to the list of borrowed books.
5.  **Missing Books:** This button displays a list of all books that are currently borrowed by students. Users can select a borrowed book from the list and click the "Bring Back" button to return it to the library. Once a book is returned, it is removed from the list of borrowed books and added back to the list of available books.

## Files

The application stores authors, students, and books in separate XML files located in the "Resources" folder. The "Model" folder contains the classes (Author, Student, Book, and Address) used in the application. These classes contain the necessary functions to add new authors, students, and books, as well as to read data from the XML files. The Address class is a helper class for the Student class and contains separate attributes for the street, house number, city, and postal code.

## Implementation

The application is user-friendly and only accepts valid data. Regular expressions are used to validate most data, such as ensuring that email addresses are in the correct format and that book ISBN numbers contain only 10 or 13 digits. If a book's ISBN number has 13 digits, it must start with 978 or 979 according to international standards.

The application was implemented using C# and WPF (.NET Framework) and was developed using the Visual Studio IDE.

## Installation

1.  Clone the repository to your local machine.
2.  Open the solution file in Visual Studio.
3.  Build the solution and run the application.

## Usage

1.  Click on the appropriate button to create a new author, student, or book.
2.  To borrow a book, select a book and a student from the respective lists and click the "Borrow" button.
3.  To return a borrowed book, select the book from the "Missing Books" list and click the "Bring Back" button.

## Future Improvements

-   Adding a search function for books, students, and authors.
-   Adding a feature to display borrowed books by a specific student or author.
-   Adding a feature to track the borrowing history of books.
-   Adding a feature to generate reports for book rentals.
