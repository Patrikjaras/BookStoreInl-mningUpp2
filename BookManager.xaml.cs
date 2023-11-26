using BookStoreInlämning4.Data;
using BookStoreInlämning4.Models;
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

namespace BookStoreInlämning4
{
    /// <summary>
    /// Interaction logic for BookManager.xaml
    /// </summary>
    public partial class BookManager : Window
    {
        public BookManager()
        {
            InitializeComponent();
            LoadModels();
            CategoryListBox.ItemsSource = BookstoreDbContext.DbContext._Categories.ToList();
            AuthorListBox.ItemsSource = BookstoreDbContext.DbContext._Authors.ToList();
            ChooseBookToRemoveListBox.ItemsSource = BookstoreDbContext.DbContext._Books.ToList();

        }

        private void ReturnToMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public static void LoadModels()
        {
            BookstoreDbContext.DbContext._Authors.ToList();
            BookstoreDbContext.DbContext._Books.ToList();
            BookstoreDbContext.DbContext._Categories.ToList();
            BookstoreDbContext.DbContext._Stores.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {            
                              
                Books newBook = new Books();

                newBook.Title = TitleTextBox.Text;
                newBook.ISBN = ISBNtextBox.Text;
                newBook.Price = double.Parse(PriceTextBox.Text);
                var selectedAuthor = AuthorListBox.SelectedItem as Author;
                newBook.AuthorID = selectedAuthor;
                var selectedCategory = CategoryListBox.SelectedItem as Categories;
                newBook.Category = selectedCategory;

                var ISBN_Exists = BookstoreDbContext.DbContext._Books.FirstOrDefault(Exists => Exists.ISBN == newBook.ISBN);
                if (ISBN_Exists == null)
                {
                    BookstoreDbContext.DbContext._Books.Add(newBook);
               
                BookstoreDbContext.DbContext.SaveChanges();
                MessageBox.Show("Books have been added");
                ClearInputFields();
                ChooseBookToRemoveListBox.ItemsSource = BookstoreDbContext.DbContext._Books.ToList();
                }
                else
                {
                    MessageBox.Show("The ISBN you have entered already exists, ISBN is a unice number and the book is already in the the database");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Store couldnt be found");
            }

        }
       
        private void ClearInputFields()
        {
            TitleTextBox.Clear();
            ISBNtextBox.Clear();
            PriceTextBox.Clear();
            AuthorListBox.SelectedItem = null;
            CategoryListBox.SelectedItem = null;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var book = ChooseBookToRemoveListBox.SelectedItem as Books;
            if (book != null)
            {
                MessageBox.Show($"{book.Title} has been deleted from our inventory");
                BookstoreDbContext.DbContext._Books.Remove(book);
                BookstoreDbContext.DbContext.SaveChanges();
                ChooseBookToRemoveListBox.SelectedItem = null;
                ChooseBookToRemoveListBox.ItemsSource = BookstoreDbContext.DbContext._Books.ToList();
            }
            else
            {
                MessageBox.Show("A book must be selected");
            }
        }
        private void ChooseBookToRemoveListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChooseBookToRemoveListBox.SelectedItem != null)
            { 
            var book = ChooseBookToRemoveListBox.SelectedItem as Books;
            TitleTextBox.Text = book.Title;
            ISBNtextBox.Text = book.ISBN;
            PriceTextBox.Text = book.Price.ToString();
            AuthorListBox.SelectedItem = book.AuthorID;
            CategoryListBox.SelectedItem = book.Category;
            
            }
        }
        private void EditBookBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookToEdit = ChooseBookToRemoveListBox.SelectedItem as Books;
                bookToEdit.Title = TitleTextBox.Text;
                bookToEdit.ISBN = ISBNtextBox.Text;
                bookToEdit.Price = double.Parse(PriceTextBox.Text);
                
                var selectedAuthor = AuthorListBox.SelectedItem as Author;
                bookToEdit.AuthorID = selectedAuthor;
                var selectedCategory = CategoryListBox.SelectedItem as Categories;
                bookToEdit.Category = selectedCategory;

                BookstoreDbContext.DbContext._Books.Update(bookToEdit);
                BookstoreDbContext.DbContext.SaveChanges();
                MessageBox.Show($"{bookToEdit.Title}s information has been updated");
                ClearInputFields();
                ChooseBookToRemoveListBox.ItemsSource = BookstoreDbContext.DbContext._Books.ToList();
            }
            catch (Exception)
            { MessageBox.Show("All fields must be properly filled out."); }
        }
    }
}
