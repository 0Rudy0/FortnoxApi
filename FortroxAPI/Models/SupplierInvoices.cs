using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FortnoxAPI.Models
{
	public class SupplierInvoices
	{
		public SupplierInvoices(string json)
		{
			JObject jObject = JObject.Parse(json);
			JToken jToken = jObject["SupplierInvoices"];
			SupplierInvoiceList = JsonConvert.DeserializeObject<List<Models.SupplierInvoice>>(jToken.ToString());
		}
		public List<Models.SupplierInvoice> SupplierInvoiceList { get; set; }
	}
}