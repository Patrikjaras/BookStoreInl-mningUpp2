using BookStoreInlämning4.Data;
using BookStoreInlämning4.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for CurrentStorePage.xaml
    /// </summary>
    public partial class CurrentStorePage : Window
    {
        private Store CurrentStore = null;
        public CurrentStorePage()
        {
            InitializeComponent();
            CurrentStoreListBox.ItemsSource = BookstoreDbContext.DbContext._Stores.ToList();
            AllBooksInlibrayListBox.ItemsSource = BookstoreDbContext.DbContext._Books.ToList();
            LoadModels();
                                    
        }
        private static void LoadModels()
        {
            BookstoreDbContext.DbContext._Authors.ToList();
            BookstoreDbContext.DbContext._Books.ToList();
            BookstoreDbContext.DbContext._Categories.ToList();
            BookstoreDbContext.DbContext._Stores.ToList();
        }
               
        private void ReturnToMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CurrentStoreListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentStore = CurrentStoreListBox.SelectedItem as Store;
            
            if (CurrentStore != null)
            {
                 BooksInStoreListBox.ItemsSource = BookstoreDbContext.DbContext._InventoryBalance.Where(store => store.StoreID == CurrentStore).ToList();
            }
                                     
        }

        private void AddBookToStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EnterCopiesToAddTextBox.Text != "" && AllBooksInlibrayListBox.SelectedItem != null && CurrentStore != null)
            {
                InventoryBalance newInventory = new InventoryBalance();
                try 
                { 
                  newInventory.StockBalance = int.Parse(EnterCopiesToAddTextBox.Text);
                
                  var bookISBN = AllBooksInlibrayListBox.SelectedItem as Books;
                  var choosenStore = CurrentStore;
                
                  newInventory.ISBN = bookISBN.ISBN;
                  newInventory.Book = bookISBN;
                  newInventory.StoreID = CurrentStore;
                
                  var existingInventory = BookstoreDbContext.DbContext._InventoryBalance.FirstOrDefault(inv => inv.ISBN == newInventory.ISBN && inv.StoreID == newInventory.StoreID);

                    if (existingInventory == null)
                    {
                        BookstoreDbContext.DbContext.Add(newInventory);
                        BookstoreDbContext.DbContext.SaveChanges();
                        ClearEnterCopiesToAddTextBox();
                        BooksInStoreListBox.ItemsSource = BookstoreDbContext.DbContext._InventoryBalance.Where(store => store.StoreID == CurrentStore).ToList();

                    }
                    else
                    {
                        
                        var totalCopies = existingInventory.StockBalance + newInventory.StockBalance;

                        if (totalCopies >= 0) 
                        {
                        existingInventory.StockBalance = totalCopies;
                        BookstoreDbContext.DbContext._InventoryBalance.Update(existingInventory);
                        BookstoreDbContext.DbContext.SaveChanges();
                        MessageBox.Show("The book already exists in the store the stockbalance have been updated");
                        ClearEnterCopiesToAddTextBox();
                        BooksInStoreListBox.ItemsSource = BookstoreDbContext.DbContext._InventoryBalance.Where(store => store.StoreID == CurrentStore).ToList();
                        }
                        else
                        {
                            MessageBox.Show("There isnt enough books in the store, enter a different amount");
                            
                            ClearEnterCopiesToAddTextBox();
                        }
                    }
             
                }
                catch (Exception)
                {
                    MessageBox.Show("Input must be a number");
                    
                }
               
            }
            else
            {
                MessageBox.Show("All fields must be properly choosen to add a book, make sure you have selected a store, book and how many you would like to order");
            }
        }
        private void ClearEnterCopiesToAddTextBox()
        {
            EnterCopiesToAddTextBox.Clear();    
        }

        private void RemoveBookFromStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var book = BooksInStoreListBox.SelectedItem as InventoryBalance;
            if (book != null) 
            {
                MessageBox.Show($"Book has been removed from the store");
                BookstoreDbContext.DbContext._InventoryBalance.Remove(book);
                BookstoreDbContext.DbContext.SaveChanges(); 
                BooksInStoreListBox.SelectedItem = null;
                BooksInStoreListBox.ItemsSource = BookstoreDbContext.DbContext._InventoryBalance.Where(store => store.StoreID == CurrentStore).ToList();
            }
            else
            {
                MessageBox.Show("A store and book must be selected");
            }
        }
    }
}
