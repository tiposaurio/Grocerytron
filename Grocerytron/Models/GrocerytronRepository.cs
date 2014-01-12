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
    }
}