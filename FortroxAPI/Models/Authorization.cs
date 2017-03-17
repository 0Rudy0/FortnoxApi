using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class Authorization
	{
		public Authorization(string json)
		{
			JObject jobject = JObject.Parse(json);
			JToken jAuth = jobject["Authorization"];
			AccessToken = (string)jAuth["AccessToken"];
		}
		public string AccessToken { get; set; }
	}
}