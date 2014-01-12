﻿using Grocerytron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Grocerytron.Controllers
{
    public class ItemsController : ApiController
    {
        private IGrocerytronRepository _repo;
        public ItemsController(IGrocerytronRepository repo) {
            _repo = repo;
        }

        public IEnumerable<Item> Get(int listId)
        {
            return _repo.GetItemsByList(listId);
        }
    }
}