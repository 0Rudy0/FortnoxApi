using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Connectors;
using System.Net;
using System.IO;
using System.Web.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FortnoxAPI.Models;

namespace FortnoxAPI
{
	public static class Helper
	{
		public static bool IsCurrTokenInvalid(string userID)
		{
			//return true;
			string token = DAL.GetActiveToken(userID);
			string clientSecret = Helper.GetClientSecret();
			if (token.Trim().Length == 0)
			{
				return true;
			}
			else
			{
				return Helper.GetRequest(WebConfigurationManager.AppSettings["TestApiSuffix"], token) == null;
			}
		}

		public static string GetNewToken(string apiCode, string userID)
		{
			if (Helper.IsCurrTokenInvalid(userID))
			{
				string clientSecret = Helper.GetClientSecret();
				if (apiCode.Trim().Length == 0)
				{
					throw new Exception("Missing authorization code");
				}
				else
				{
					string html = string.Empty;
					string url = @WebConfigurationManager.AppSettings["ApiUrl"];
					try
					{
						HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
						request.Method = "GET";
						request.Headers.Add("Authorization-Code", apiCode);
						request.Headers.Add("Client-Secret", clientSecret);
						request.ContentType = "application/json";
						request.Accept = "application/json";

						FortnoxAPI.Models.Authorization authToken;
						using (WebResponse response = request.GetResponse())
						{
							var responseStream = response.GetResponseStream();
							if (responseStream != null)
							{
								var reader = new StreamReader(responseStream);
								var responseContent = reader.ReadToEnd();
								reader.Close();
								authToken = new FortnoxAPI.Models.Authorization(responseContent);
								return authToken.AccessToken;
							}
						}
						return "";
					}
					catch (WebException ex)
					{
						var reader = new StreamReader(ex.Response.GetResponseStream());
						var content = reader.ReadToEnd();
						ErrorInformation err = new ErrorInformation(content);
						return null;
					}
				}
			}
			else
			{
				return DAL.GetActiveToken(userID);
			}
		}

		public static string GetClientSecret()
		{
			return WebConfigurationManager.AppSettings["ClientSecret"];
		}

		public static string GetRequest(string urlSuffix, string token)
		{
			string html = string.Empty;
			string url = @WebConfigurationManager.AppSettings["ApiUrl"] + urlSuffix;
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.AutomaticDecompression = DecompressionMethods.GZip;
				request.Headers.Add("Access-Token:  " + token);
				request.Headers.Add("Client-Secret: " + Helper.GetClientSecret());
				request.ContentType = "application/json";
				request.Accept = "application/json";

				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					html = reader.ReadToEnd();
				}
				return html;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}