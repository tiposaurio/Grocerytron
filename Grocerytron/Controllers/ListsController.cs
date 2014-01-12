using Grocerytron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Grocerytron.Controllers
{
    public class ListsController : ApiController
    {
        private IGrocerytronRepository _repo;
        public ListsController(IGrocerytronRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<List> Get()
        {
            return _repo.GetLists();
        }
    }
}
