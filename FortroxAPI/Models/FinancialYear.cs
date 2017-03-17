using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class FinancialYear
	{
		public FinancialYear(string json)
		{
			//json = System.Text.RegularExpressions.Regex.Replace(json, "(?<=\")(@)(?!.*\":\\s )", String.Empty);
			JObject jObject = JObject.Parse(json);
			JToken jUser = jObject["FinancialYears"];
			Url = (string)jUser["@url"];
			Id = (string)jUser["Id"];
			FromDate = (string)jUser["FromDate"];
			ToDate = (string)jUser["ToDate"];
			AccountingMethod = (string)jUser["AccountingMethod"];
		}

		public FinancialYear()
		{

		}
		public string Url { get; set; }
		public string Id { get; set; }
		public string FromDate { get; set; }
		public string ToDate { get; set; }
		public string AccountingMethod { get; set; }
	}
}