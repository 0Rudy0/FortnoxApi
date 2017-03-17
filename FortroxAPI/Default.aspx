<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FortnoxAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #downloadXmlBtn {
            display: inline-block;
        }

        #buttonContainer {
            width: 100%;
            height: auto;
            margin-top: 20px;
            text-align: center;
        }
    </style>

    <div id="buttonContainer">
        <button id="downloadXmlBtn" type="button" class="btn btn-primary btn-lg" 
            data-loading-text="<span class='glyphicon glyphicon-repeat' aria-hidden='true'></span> Fetching data...">
            <span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span>
            Download XML
        </button>
    </div>

    <script type="text/javascript" src="Scripts/FileSaver.min.js"></script>
    <script type="text/javascript" src="Scripts/vkbeautify.0.99.00.beta.js"></script>
    <script type="text/javascript">

        var btn;

        function GetStuffListHttpGet(category, successCallback, failureCallback) {
            $.ajax({
                type: "GET",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetStuffListServiceHttpGet",
                success: function (data) {
                    successCallback(data);
                    btn.button('reset');
                },
                error: function (data) {
                    failureCallback(data);
                }
            });
        }

        $(function () {
            $('#downloadXmlBtn').click(function () {
                btn = $(this);
                btn.button('loading');
                GetStuffListHttpGet(4, saveToFile, function (data) { console.log(data); });
            });
        });

        function saveToFile(data) {
            var text = vkbeautify.xml(data.d);
            var filename = 'file';
            var blob = new Blob([text], { type: "text/plain;charset=utf-8" });
            saveAs(blob, filename + ".xml");
        }

    </script>

</asp:Content>
