<%@ Page Language="VB" AutoEventWireup="false" CodeFile="gestion.aspx.vb" Inherits="gestion"%>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<form runat="server" id="s1"> 

TICKET:<asp:TextBox id="idticket" runat="server"/>

<asp:SqlDataSource id="datasource1" runat="server" 
ConnectionString="<%$ ConnectionStrings:CRM_CorporativoConnectionString %>" 
    SelectCommand="SELECT [id_archivo], [nombre], [id_ticket] FROM [tbl_archivo]" />


   <asp:GridView id="grid1" runat="server" AutoGenerateColumns="False" 
    OnRowCommand="grid1_RowCommand"
     enableEventValidation="false"
    PageSize="10" AllowPaging="True" AllowSorting="True" DataSourceID="datasource1" >
    <Columns>
    <asp:TemplateField HeaderText="Cabecera">
    <ItemTemplate>
    <asp:Label id="labelcampo" runat="server" Text='<%#Eval("nombre") %>'/>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Cabecera">
    <ItemTemplate>
    <asp:Button id="descargar" runat="server" text="Descargar!" CommandName="Descargar" CommandArgument='<%#Eval("id_archivo") %>'/>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
   </asp:GridView>
</form>
