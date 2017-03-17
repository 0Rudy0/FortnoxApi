using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Connectors;

namespace FortnoxAPI
{
	public partial class _Default : Page
	{
		protected string authCode = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			string userID = "123";
			Page.Title = "Download data";
			if (Helper.IsCurrTokenInvalid(userID))
			{
				Response.Redirect("InitConnection.aspx");
			}
			else
			{

			}
		}

		[WebMethod]
		[ScriptMethod(UseHttpGet = true, XmlSerializeString = false)]
		public static string GetStuffListServiceHttpGet()
		{
			XmlSerializer xsSubmit = new XmlSerializer(typeof(Models.ReturnDataModel));
			var subReq = GetData();
			var xml = "";

			using (var sww = new StringWriter())
			{
				using (XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, subReq);
					xml = sww.ToString(); // Your XML
				}
			}
			System.Threading.Thread.Sleep(2000);
			return xml;
		}

		public static Models.ReturnDataModel GetData()
		{
			DateTime dateConstraint = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
			string userID = "123";
			string token = DAL.GetActiveToken(userID);
			ConnectionCredentials.AccessToken = token;
			ConnectionCredentials.ClientSecret = Helper.GetClientSecret();
			List<Customer> data = new List<Customer>();

			try
			{
				Models.ReturnDataModel returnModel = new Models.ReturnDataModel();
				returnModel.Accounts = GetAccounts();
				returnModel.AccountCharts = GetAccountCharts();
				returnModel.CompanySettings = GetCompanySettings(token);
				returnModel.FinancialYears = GetFinancialYears(token, dateConstraint);
				returnModel.Invoices = GetInvoices(dateConstraint);
				returnModel.SupplierInvoices = GetSupplierInvoices(token, dateConstraint);
				returnModel.Suppliers = GetSuppliers(token);

				return returnModel;
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return new Models.ReturnDataModel();
			}
		}

		public static List<AccountSubset> GetAccounts() 
		{
			AccountConnector connector = new AccountConnector();
			Accounts accountsResult = connector.Find();
			List<AccountSubset> filteredAccs = new List<AccountSubset>();
			foreach (AccountSubset acc in accountsResult.AccountSubset)
			{
				filteredAccs.Add(acc);
				//if (int.Parse(acc.Year) >= DateTime.Now.Year)
				//{
				//	filteredAccs.Add(acc);
				//}
			}

			return filteredAccs;
		}

		public static List<AccountChartSubset> GetAccountCharts()
		{
			AccountChartConnector acConnector = new AccountChartConnector();
			AccountCharts accountChartsResult = acConnector.Find();

			return accountChartsResult.AccountChartSubset;
		}

		public static Models.CompanySettings GetCompanySettings(string token)
		{
			string compSettingsString = Helper.GetRequest("settings/company", token);
			Models.CompanySettings compSettings = new Models.CompanySettings(compSettingsString);

			return compSettings;
		}

		public static List<Models.FinancialYear> GetFinancialYears(string token, DateTime dateConstraint)
		{
			string financialYearsString = Helper.GetRequest("financialyears", token);
			Models.FinancialYears financialYears = new Models.FinancialYears(financialYearsString);
			List<Models.FinancialYear> filteredFinancialYears = new List<Models.FinancialYear>();
			foreach (Models.FinancialYear finYear in financialYears.FinancialYearList)
			{
				if (Helper.ParseDateString(finYear.FromDate) >= dateConstraint)
				{
					filteredFinancialYears.Add(finYear);
				}
			}
			return filteredFinancialYears;
		}

		public static List<InvoiceSubset> GetInvoices (DateTime dateConstraint)
		{
			InvoiceConnector invConnector = new InvoiceConnector();
			Invoices invoicesResult = invConnector.Find();
			List<InvoiceSubset> filteredInvoices = new List<InvoiceSubset>();
			foreach (InvoiceSubset inv in invoicesResult.InvoiceSubset)
			{
				if (Helper.ParseDateString(inv.InvoiceDate) >= dateConstraint)
				{
					filteredInvoices.Add(inv);
				}
			}
			return filteredInvoices;
		}

		public static List<Models.SupplierInvoice> GetSupplierInvoices(string token, DateTime dateConstraint)
		{
			string supplierInvoicesString = Helper.GetRequest("supplierinvoices", token);
			Models.SupplierInvoices supInv = new Models.SupplierInvoices(supplierInvoicesString);
			List<Models.SupplierInvoice> filteredSupInvs = new List<Models.SupplierInvoice>();
			foreach (Models.SupplierInvoice sInv in supInv.SupplierInvoiceList)
			{
				if (Helper.ParseDateString(sInv.InvoiceDate) >= dateConstraint)
				{
					filteredSupInvs.Add(sInv);
				}
			}
			return filteredSupInvs;
		}

		public static List<Models.Supplier> GetSuppliers(string token)
		{
			string suppliersString = Helper.GetRequest("suppliers", token);
			Models.Suppliers sups = new Models.Suppliers(suppliersString);
			return sups.SupplierList;
		}
	}
}