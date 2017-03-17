using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FortnoxAPI.Models
{
	public class Suppliers
	{
		public Suppliers(string json)
		{
			JObject jobject = JObject.Parse(json);
			JToken jSups = jobject["Suppliers"];
			SupplierList = JsonConvert.DeserializeObject<List<Models.Supplier>>(jSups.ToString());
		}
		public List<Models.Supplier> SupplierList { get; set; } 
	}
}