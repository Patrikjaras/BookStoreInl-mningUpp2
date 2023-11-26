using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreInlämning4.Models
{
    internal class Books
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public Author? AuthorID { get; set; }
        public Categories? Category { get; set; }
        public Store? StoreID { get; set; }
    }
}
