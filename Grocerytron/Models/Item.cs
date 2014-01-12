using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grocerytron.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ListId { get; set; }
    }
}
