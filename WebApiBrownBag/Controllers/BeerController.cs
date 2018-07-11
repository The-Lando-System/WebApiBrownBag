using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiBrownBag.Filters;
using WebApiBrownBag.Models;
using WebApiBrownBag.Providers;

namespace WebApiBrownBag.Controllers
{
	[LoggingFilter]
    public class BeerController : ApiController
    {
        // GET: api/Beer
        public IEnumerable<Beer> Get()
        {
			return BeerProvider.GetAllBeers();
		}

        // GET: api/Beer/:id
        public Beer Get(string id)
        {
	        return BeerProvider.GetBeerById(id);
        }

        // POST: api/Beer
		[ValidationFilter]
		public IHttpActionResult Post([FromBody]Beer newBeer)
		{
			Beer b = BeerProvider.CreateBeer(newBeer);

			return CreatedAtRoute("DefaultApi", new { id = b.Id }, b);
        }

		// PUT: api/Beer
		[ValidationFilter]
		public IHttpActionResult Put([FromBody]Beer beerToUpdate)
		{
			return Ok(BeerProvider.UpdateBeer(beerToUpdate));
		}

		// DELETE: api/Beer/:id
		public IHttpActionResult Delete(string id)
        {
			BeerProvider.DeleteBeer(id);
	        return Ok();
		}
    }
}
