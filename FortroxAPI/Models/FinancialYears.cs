using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FortnoxAPI.Models
{
	public class FinancialYears
	{
		public FinancialYears(string json)
		{
			json = System.Text.RegularExpressions.Regex.Replace(json, "(?<=\")(@)(?!.*\":\\s )", String.Empty);
			JObject jObject = JObject.Parse(json);
			JToken jToken = jObject["FinancialYears"];
			FinancialYearList = JsonConvert.DeserializeObject<List<Models.FinancialYear>>(jToken.ToString());
		}
		public List<Models.FinancialYear> FinancialYearList { get; set; }
	}
}