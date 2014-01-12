using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocerytron.Models
{
    public interface IGrocerytronRepository
    {
        IQueryable<List> GetLists();
        IQueryable<Item> GetItemsByList(int listId);
    }
}
