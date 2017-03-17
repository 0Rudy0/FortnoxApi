<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="InitConnection.aspx.cs" Inherits="FortnoxAPI.InitConnection" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        #downloadXmlBtn {
            display: inline-block;
        }

        #buttonContainer {
            width: 100%;
            height: auto;
            margin-top: 20px;
            /*text-align: center;*/
        }

        .error {
            color: darkred;
            font-size: 15px;
        }

        #MainContent_apiCode {
            width: 310px;
            max-width: none;
            font-family: Consolas;
        }
    </style>

    <div id="buttonContainer">
        <asp:Panel runat="server" ID="errorPanel">
            <div class="alert alert-danger" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <asp:Label runat="server" ID="errorText" Text=""></asp:Label>
            </div>
        </asp:Panel>
        <p>
            Login to your Fortnox account and go to <i>Manage Users->Add Integration</i> and then type <u>3jE3vYPOSWel</u>. 
            When you type "3jE3vYPOSWel" the Fortnox Integration will show up.
            Just select it, then a API-key will be shown. <br />
            Copy this API-key and paste it into the <b>Fortnox API Code</b> field and press <u>Initiate Fortnox integration</u>. 
            The app only needs this API-key to link your account with your Fortnox account. 
        </p>
        <div class="form-group">
            <label for="apiCode">Fortnox API code:</label>
           <asp:TextBox runat="server" ID="apiCode" CssClass="form-control"></asp:TextBox>
        </div>
        
        <asp:Button CssClass="btn btn-success btn-lg" Text="Initiate Fortnox integration" runat="server" ID="GetNewToken" OnClick="GetNewToken_Click" />
    </div>

</asp:Content>
