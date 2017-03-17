using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class ErrorInformation
	{
		public ErrorInformation(string json)
		{
			JObject jObject = JObject.Parse(json);
			JToken jUser = jObject["ErrorInformation"];
			Message = (string)jUser["Message"];
			Error = (int)jUser["Error"];
			Code = (string)jUser["Code"];
		}
		public int Error { get; set; }
		public string Message { get; set; }
		public string Code { get; set; }
	}
}