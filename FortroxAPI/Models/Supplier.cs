using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace FortnoxAPI.Models
{
	public class Supplier
	{
		public Supplier(string json, bool isFull)
		{
			JObject jobject = JObject.Parse(json);
			JToken jAuth = jobject["Supplier"];
			Active = (string)jAuth["Active"];
			Address1 = (string)jAuth["Address1"];
			Address2 = (string)jAuth["Address2"];
			Bank = (string)jAuth["Bank"];
			BIC = (string)jAuth["BIC"];
			BranchCode = (string)jAuth["BranchCode"];
			City = (string)jAuth["City"];
			ClearingNumber = (string)jAuth["ClearingNumber"];
			Comments = (string)jAuth["Comments"];
			CostCenter = (string)jAuth["CostCenter"];
			Country = (string)jAuth["Country"];
			CountryCode = (string)jAuth["CountryCode"];
			Currency = (string)jAuth["Currency"];
			DisablePaymentFile = (string)jAuth["DisablePaymentFile"];
			Email = (string)jAuth["Email"];
			Fax = (string)jAuth["Fax"];
			IBAN = (string)jAuth["IBAN"];
			Name = (string)jAuth["Name"];
			OrganisationNumber = (string)jAuth["OrganisationNumber"];
			OurCustomerNumber = (string)jAuth["OurCustomerNumber"];
			OurReference = (string)jAuth["OurReference"];
			PG = (string)jAuth["PG"];
			Phone1 = (string)jAuth["Phone1"];
			Phone2 = (string)jAuth["Phone2"];
			PreDefinedAccount = (string)jAuth["PreDefinedAccount"];
			Project = (string)jAuth["Project"];
			SupplierNumber = (string)jAuth["SupplierNumber"];
			TermsOfPayment = (string)jAuth["TermsOfPayment"];
			url = (string)jAuth["url"];
			VATNumber = (string)jAuth["VATNumber"];
			VisitingAddress = (string)jAuth["VisitingAddress"];
			VisitingCity = (string)jAuth["VisitingCity"];
			VisitingCountry = (string)jAuth["VisitingCountry"];
			VisitingCountryCode = (string)jAuth["VisitingCountryCode"];
			VisitingZipCode = (string)jAuth["VisitingZipCode"];
			WorkPlace = (string)jAuth["WorkPlace"];
			WWW = (string)jAuth["WWW"];
			YourReference = (string)jAuth["YourReference"];
			ZipCode = (string)jAuth["ZipCode"];
		}

		public Supplier()
		{

		}
		public string Active { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Bank { get; set; }
		public string BankAccountNumber { get; set; }
		public string BG { get; set; }
		public string BIC { get; set; }
		public string BranchCode { get; set; }
		public string City { get; set; }
		public string ClearingNumber { get; set; }
		public string Comments { get; set; }
		public string CostCenter { get; set; }
		public string Country { get; set; }
		public string CountryCode { get; set; }
		public string Currency { get; set; }
		public string DisablePaymentFile { get; set; }
		public string Email { get; set; }
		public string Fax { get; set; }
		public string IBAN { get; set; }
		public string Name { get; set; }
		public string OrganisationNumber { get; set; }
		public string OurCustomerNumber { get; set; }
		public string OurReference { get; set; }
		public string PG { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string PreDefinedAccount { get; set; }
		public string Project { get; set; }
		public string SupplierNumber { get; set; }
		public string TermsOfPayment { get; set; }
		public string url { get; set; }
		public string VATNumber { get; set; }
		public string VisitingAddress { get; set; }
		public string VisitingCity { get; set; }
		public string VisitingCountry { get; set; }
		public string VisitingCountryCode { get; set; }
		public string VisitingZipCode { get; set; }
		public string WorkPlace { get; set; }
		public string WWW { get; set; }
		public string YourReference { get; set; }
		public string ZipCode { get; set; }
	}
}