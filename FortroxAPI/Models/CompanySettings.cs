using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class CompanySettings
	{
		public CompanySettings(string json)
		{
			JObject jobject = JObject.Parse(json);
			JToken jAuth = jobject["CompanySettings"];
			Address = (string)jAuth["AccessToken"];
			BG = (string)jAuth["BG"];
			BIC = (string)jAuth["BIC"];
			BranchCode = (string)jAuth["BranchCode"];
			City = (string)jAuth["City"];
			ContactFirstName = (string)jAuth["ContactFirstName"];
			ContactLastName = (string)jAuth["ContactLastName"];
			Country = (string)jAuth["Country"];
			CountryCode = (string)jAuth["CountryCode"];
			DatabaseNumber = (string)jAuth["DatabaseNumber"];
			Domicile = (string)jAuth["Domicile"];
			Email = (string)jAuth["Email"];
			Fax = (string)jAuth["Fax"];
			IBAN = (string)jAuth["IBAN"];
			Name = (string)jAuth["Name"];
			OrganizationNumber = (string)jAuth["OrganizationNumber"];
			PG = (string)jAuth["PG"];
			Phone1 = (string)jAuth["Phone1"];
			Phone2 = (string)jAuth["Phone2"];
			TaxEnabled = (string)jAuth["TaxEnabled"];
			VATNumber = (string)jAuth["VATNumber"];
			VisitAddress = (string)jAuth["VisitAddress"];
			VisitCity = (string)jAuth["VisitCity"];
			VisitCountry = (string)jAuth["VisitCountry"];
			VisitCountryCode = (string)jAuth["VisitCountryCode"];
			VisitName = (string)jAuth["VisitName"];
			VisitZipCode = (string)jAuth["VisitZipCode"];
			WWW = (string)jAuth["WWW"];
			ZipCode = (string)jAuth["ZipCode"];
		}
		public string Address { get; set; }
		public string BG { get; set; }
		public string BIC { get; set; }
		public string BranchCode { get; set; }
		public string City { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public string DatabaseNumber { get; set; }
		public string Domicile { get; set; }
		public string Email { get; set; }
		public string Fax { get; set; }
		public string IBAN { get; set; }
		public string Name { get; set; }
		public string OrganizationNumber { get; set; }
		public string PG { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string TaxEnabled { get; set; }
		public string VATNumber { get; set; }
		public string VisitAddress { get; set; }
		public string VisitCity { get; set; }
		public string VisitCountry { get; set; }
		public string VisitCountryCode { get; set; }
		public string VisitName { get; set; }
		public string VisitZipCode { get; set; }
		public string WWW { get; set; }
		public string ZipCode { get; set; }
	}
}