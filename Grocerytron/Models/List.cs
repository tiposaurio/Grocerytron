using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocerytron.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}