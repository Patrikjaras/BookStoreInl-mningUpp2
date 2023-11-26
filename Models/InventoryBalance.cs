using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreInlämning4.Models
{
    internal class InventoryBalance
    {
        public int ID { get; set; }
        public Store StoreID { get; set; }
        public Books Book { get; set; }
        public string ISBN { get; set; }
        public int? StockBalance { get; set; }
    }
}
