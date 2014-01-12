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

        public IEnumerable<List> Get(bool includeItems = false)
        {
            IQueryable<List> results;

            if (includeItems == true)
            {
                results = _repo.GetListsIncludingItems();
            }
            else
            {
                results = _repo.GetLists();
            }

            return results;
        }

        public HttpResponseMessage Post([FromBody]List newList)
        {
            if (_repo.AddList(newList) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newList);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
