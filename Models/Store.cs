using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreInlämning4.Models
{
    internal class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Store (string name, string description)
        {
            Name = name;
            Description = description;

        }
    }
}
