using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class SupplierInvoice
	{
		public SupplierInvoice(string json)
		{
			JObject jObject = JObject.Parse(json);
			JToken jUser = jObject["FinancialYears"];
			url = (string)jUser["@url"];
			Balance = (string)jUser["Balance"];
			Booked = (bool)jUser["Booked"];
			Cancel = (bool)jUser["Cancel"];
			DueDate = (string)jUser["DueDate"];
			GivenNumber = (string)jUser["GivenNumber"];
			InvoiceDate = (string)jUser["InvoiceDate"];
			InvoiceNumber = (string)jUser["InvoiceNumber"];
			SupplierName = (string)jUser["SupplierName"];
			SupplierNumber = (string)jUser["SupplierNumber"];
			Total = (double)jUser["Total"];
		}

		public SupplierInvoice()
		{

		}

		public string url { get; set; }
		public string Balance { get; set; }
		public bool Booked { get; set; }
		public bool Cancel { get; set; }
		public string DueDate { get; set; }
		public string GivenNumber { get; set; }
		public string InvoiceDate { get; set; }
		public string InvoiceNumber { get; set; }
		public string SupplierName { get; set; }
		public string SupplierNumber { get; set; }
		public double Total { get; set; }
	}
}