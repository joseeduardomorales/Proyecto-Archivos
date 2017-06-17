<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="charola.aspx.cs" Inherits="ctrlArchivos.vista.charola" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Contenido_Charola {
            height: 520px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido_Charola">

         <h1>Charola</h1>
        <asp:Button ID="btnBuscarCharola" class="btn btn-primary btn-lg btn-block" runat="server" Text="Buscar" OnClick="btnBuscarCharola_Click" />
        &nbsp;<asp:Button ID="btnEliminarCharola" class="btn btn-primary btn-lg btn-block" runat="server" Text="Eliminar" OnClick="btnEliminarCharola_Click" />
        &nbsp;<asp:Button ID="btnActualizarCharola" class="btn btn-primary btn-lg btn-block" runat="server" Text="Actualizar" OnClick="btnActualizarCharola_Click" />
        <br />

         <asp:Label ID="Label1" runat="server" Text="Código de Charola:"></asp:Label>
&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="txtIDCharola" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="txtDescripcionCh" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label3" runat="server" Text="Código de Estante:"></asp:Label>
&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="txtIDEstante" runat="server"></asp:TextBox>
         <br />
         <br />

        <asp:Button ID="btnAgregarCh" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar" OnClick="btnAgregarCh_Click" />

        </div>
</asp:Content>
