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
        IQueryable<List> GetListsIncludingItems();
        IQueryable<Item> GetItemsByList(int listId);

        bool Save();

        bool AddList(List newList);
        bool AddItem(Item newItem);
    }
}
