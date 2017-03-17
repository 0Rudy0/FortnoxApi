using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FortnoxAPI
{
	public partial class InitConnection : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Page.Title = "Initiate Connection";
			string userID = "123";
			errorPanel.Visible = false;
			errorText.Text = "";
			if (!Helper.IsCurrTokenInvalid(userID))
			{
				Response.Redirect("Default.aspx");
			}
		}

		protected void GetNewToken_Click(object sender, EventArgs e)
		{
			string userID = "123";
			string pattern = @WebConfigurationManager.AppSettings["ApiCodeRegex"];
			System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
			if (rgx.Matches(apiCode.Text).Count == 0)
			{
				errorPanel.Visible = true;
				errorText.Text = "API code is not valid";
			}
			else
			{
				string newToken = Helper.GetNewToken(apiCode.Text, userID);

				if (newToken == null)
				{
					errorPanel.Visible = true;
					errorText.Text = "Error when getting new token!";
				}
				else
				{
					if (DAL.InsertNewToken(newToken, userID))
					{
						Response.Redirect("Default.aspx");
					}
					else
					{
						errorPanel.Visible = true;
						errorText.Text = "Error when inserting new token into database";
					}
				}
			}
		}
	}
}