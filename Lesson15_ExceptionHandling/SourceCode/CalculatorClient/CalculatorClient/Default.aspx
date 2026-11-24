<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CalculatorClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <table style="font-family:Arial; border:1px solid black">
    <tr>
        <td>
            <b>Numerator:</b>
        </td>
        <td>
            <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>Denominator:</b>
        </td>
        <td>
            <asp:TextBox ID="txtDenominator" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnDivide" runat="server" Text="Divide" Font-Bold="True" onclick="btnDivide_Click" />
        </td>  
        <td>
            <asp:Label ID="lblResult" runat="server" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
</table>

</asp:Content>
