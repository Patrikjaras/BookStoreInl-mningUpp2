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
    /// Interaction logic for CategoryManager.xaml
    /// </summary>
    public partial class CategoryManager : Window
    {
        private static BookstoreDbContext DbContext;
        public CategoryManager()
        {
            InitializeComponent();
            LoadModels();
            DbContext = new BookstoreDbContext();


            CategoryToDeleteCombobox.ItemsSource = DbContext._Categories.ToList();
        }
        private void LoadModels()
        {
            BookstoreDbContext.DbContext._Authors.ToList();
            BookstoreDbContext.DbContext._Books.ToList();
            BookstoreDbContext.DbContext._Categories.ToList();
            BookstoreDbContext.DbContext._Stores.ToList();
        }

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
               

        private void AddCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewCateGoryTextBox.Text != "" && NewCateGoryTextBox != null)
            {
                Categories newCategory = new Categories();
                newCategory.Category = NewCateGoryTextBox.Text;
                DbContext._Categories.Add(newCategory);
                DbContext.SaveChanges();
                NewCateGoryTextBox.Clear();
                MessageBox.Show("New Category has been added");
                CategoryToDeleteCombobox.ItemsSource = DbContext._Categories.ToList();
            }
            else
            {
                MessageBox.Show("Please enter a new category");
            }
        }

        private void DeleteCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var category = CategoryToDeleteCombobox.SelectedItem as Categories;
            if (category != null)
            {
                var editQuestionCategory = DbContext._Books.ToList();
                foreach (var book in editQuestionCategory)
                {
                    if (book.Category == category)
                    {
                        book.Category = null;
                    }
                }
                DbContext._Categories.Remove(category);
                DbContext.SaveChanges();
                MessageBox.Show("New Category has been Deleted");
                CategoryToDeleteCombobox.ItemsSource = DbContext._Categories.ToList();
            }
            else
            {
                MessageBox.Show("A Category must be selected");
            }
        }
    }
}
