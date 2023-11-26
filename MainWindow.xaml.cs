using BookStoreInlämning4.Data;
using BookStoreInlämning4.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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

namespace BookStoreInlämning4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        
        //private static BookstoreDbContext DbContext;
        public MainWindow()
        {
            InitializeComponent();
            
            // DbContext = new BookstoreDbContext();
            //AddStores();

        }
        
        public static void AddStores()
        {
            Store store = new Store("Kungälv", "Main office");
            Store store1 = new Store("Stockholm", "We had to have one here i guess");
            Store store2 = new Store("Malmö", "Not sure they can read down there");
            Store store3 = new Store("Göteborg", "The store we are most proud over");

            BookstoreDbContext.DbContext._Stores.Add(store);
            BookstoreDbContext.DbContext._Stores.Add(store1);
            BookstoreDbContext.DbContext._Stores.Add(store2);
            BookstoreDbContext.DbContext._Stores.Add(store3);
            BookstoreDbContext.DbContext.SaveChanges();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWriter addWriter = new AddWriter();
            addWriter.Show();
            this.Close();
        }

        private void EditCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.Show();
            this.Close();
        }

        private void EditBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            BookManager bookManager = new BookManager();
            bookManager.Show();
            this.Close();
        }

        private void StoreManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentStorePage currentStorePage = new CurrentStorePage();
            currentStorePage.Show();
            this.Close();

        }
    }
    
}
