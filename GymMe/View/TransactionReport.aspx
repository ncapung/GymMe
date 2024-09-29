<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header_Admin.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="GymMe.View.TransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Transaction Report
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
