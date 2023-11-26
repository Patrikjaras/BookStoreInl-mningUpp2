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
    /// Interaction logic for AddWriter.xaml
    /// </summary>
    public partial class AddWriter : Window
    {
        private static BookstoreDbContext DbContext;
        public AddWriter()
        {
            InitializeComponent();
            DbContext = new BookstoreDbContext();
            WriterToDeleteListBox.ItemsSource = DbContext._Authors.ToList();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AddWriterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddWriterFirstNameTextbox.Text != "" && AddWriterLastNameTextbox.Text != "")
            {
                Author addWriter = new Author();
                addWriter.FirstName = AddWriterFirstNameTextbox.Text;
                addWriter.LastName = AddWriterLastNameTextbox.Text;
                DbContext._Authors.Add(addWriter);
                DbContext.SaveChanges();
                AddWriterLastNameTextbox.Clear();
                AddWriterFirstNameTextbox.Clear();
                WriterToDeleteListBox.ItemsSource = DbContext._Authors.ToList();

            }
            else
            {
                MessageBox.Show("A writer must have a First and last name");
            }
        }

        private void DeleteWriterBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = WriterToDeleteListBox.SelectedItem as Author;
            if (selectedAuthor != null)
            {
                var editBookAuthor = DbContext._Books.ToList();
                foreach (var book in editBookAuthor)
                {
                    if (book.AuthorID == selectedAuthor)
                    {
                        book.AuthorID = null;
                    }
                }
                DbContext._Authors.Remove(selectedAuthor);
                DbContext.SaveChanges();
                MessageBox.Show("Author has been deleted");
                WriterToDeleteListBox.ItemsSource = DbContext._Authors.ToList();
            }
            else
            {
                MessageBox.Show("An author must be selected");
            }

        }
    }
}
