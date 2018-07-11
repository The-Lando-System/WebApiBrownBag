using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBrownBag.Models;

namespace WebApiBrownBag.Providers
{
	public static class BeerProvider
	{
		private static Dictionary<string, Beer> beers = new Dictionary<string, Beer>();

		static BeerProvider()
		{
			InitBeer("Compass", BeerType.IPA, 6.7, "Bristol");
			InitBeer("Milk Stout", BeerType.Stout, 5.5, "Left Hand");
			InitBeer("Avalanche", BeerType.Amber, 4.3, "Breckenridge");
			InitBeer("Easy Street", BeerType.Wheat, 5.2, "Odell");
			InitBeer("Ten-Fidy", BeerType.Porter, 10.5, "Oskar Blues");
		}

		private static Beer InitBeer(string name, BeerType type, double abv, string brewery)
		{
			Beer beer = new Beer(name, type, abv, brewery);
			beers.Add(beer.Id, beer);
			return beer;
		}
		
		public static List<Beer> GetAllBeers()
		{
			return beers.Values.ToList();
		}

		public static Beer GetBeerById(string id)
		{
			return beers[id];
		}

		public static Beer CreateBeer(Beer beer)
		{
			return InitBeer(beer.Name, beer.Type, beer.Abv, beer.Brewery);
		}

		public static Beer UpdateBeer(Beer updatedBeer)
		{
			if (beers[updatedBeer.Id] != null)
			{
				beers[updatedBeer.Id] = updatedBeer;
			}

			return beers[updatedBeer.Id];
		}

		public static void DeleteBeer(string id)
		{
			beers.Remove(id);
		}
	}
}