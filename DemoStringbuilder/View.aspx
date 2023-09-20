    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="DemoStringbuilder.View" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style>
            .header-container {
                display: flex;
                position: sticky;
                top: 10px;
                margin: 10px;

            }
            .table-container {
                display: flex;
                width: 50%;
                margin: auto;
            }
            body {
                font-family: 'PT Sans', sans-serif;
                background: #74ebd5;  /* fallback for old browsers */
                background: #74ebd5;  /* fallback for old browsers */
                background: -webkit-linear-gradient(to right, #ACB6E5, #74ebd5);  /* Chrome 10-25, Safari 5.1-6 */
                background: linear-gradient(to right, #ACB6E5, #74ebd5); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            }
            
            td {
                margin: auto;
            }

            table, tr, th, td {
                border: 1px solid black;
                border-collapse: collapse;
            }
        </style>
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
        <link href="https://fonts.googleapis.com/css2?family=PT+Sans&display=swap" rel="stylesheet" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('.btnDelete').click(function () {
                        // console.log('test');
                        var dataid = $(this).attr('data-id')
                        console.log(dataid);
                        $.ajax({
                            method: "POST",
                            url: "View.aspx/DeleteData",
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            data: JSON.stringify({d_id:'"'+dataid+'"'}),
                            success: function (data) {
                                console.log(data);
                                alert("success!");
                               location.reload(true);
                            },
                            error: function (response) {
                                console.log(response);
                                alert("Error: ");

                            }
                        });
                    });
                })
            </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="header-container">
                <h1>Display Records</h1>
            </div>
            <div class ="table-container">
                <asp:Panel ID="recordsPanel" runat="server">
                    <!-- The table will be added dynamically here -->
                </asp:Panel>
            </div>
        </form>

    </body>
    </html>