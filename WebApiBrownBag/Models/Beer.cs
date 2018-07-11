using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace WebApiBrownBag.Models
{
	[DataContract]
	public class Beer
	{
		[DataMember]
		public string Id { get; set; }

		[DataMember]
		[Required]
		public string Name { get; set; }

		[IgnoreDataMember]
		public BeerType Type { get; set; }

		[DataMember]
		[Range(0,15)]
		public double Abv { get; set; }

		[DataMember]
		public string Brewery { get; set; }

		public Beer()
		{
			
		}

		public Beer(string name, BeerType type, double abv, string brewery)
		{
			Id = Guid.NewGuid().ToString();
			Name = name;
			Type = type;
			Abv = abv;
			Brewery = brewery;
		}

		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);
		}

	}

	public enum BeerType
	{
		IPA,
		Stout,
		Amber,
		Porter,
		Wheat,
		Lager
	}
}