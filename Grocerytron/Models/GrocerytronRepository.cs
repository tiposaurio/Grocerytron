using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocerytron.Models
{
    public class GrocerytronRepository : IGrocerytronRepository
    {
        GrocerytronContext _ctx;
        public GrocerytronRepository(GrocerytronContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<List> GetLists()
        {
            return _ctx.Lists;
        }

        public IQueryable<Item> GetItemsByList(int listId)
        {
            return _ctx.Items.Where(r => r.ListId == listId);
        }


        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO Log this error
                return false;
            }

        }

        public bool AddList(List newList)
        {
            try
            {
                _ctx.Lists.Add(newList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public IQueryable<List> GetListsIncludingItems()
        {
            return _ctx.Lists.Include("Items");
        }


        public bool AddItem(Item newItem)
        {
            try
            {
                _ctx.Items.Add(newItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            };
        }
    }
}