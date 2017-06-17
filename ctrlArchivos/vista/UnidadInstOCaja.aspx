<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="UnidadInstOCaja.aspx.cs" Inherits="ctrlArchivos.vista.UnidadInstOCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Contenido_UnidadInstOCaja">

         <h1>Unidad, Instalación o Caja</h1>
        <asp:Button ID="btnBuscarUoC" class="btn btn-primary btn-lg btn-block" runat="server" Text="Buscar" OnClick="btnBuscarUoC_Click" />
        &nbsp;<asp:Button ID="btnEliminarUoC" class="btn btn-primary btn-lg btn-block" runat="server" Text="Eliminar" OnClick="btnEliminarUoC_Click" />
        &nbsp;<asp:Button ID="btnActualizarUoC" class="btn btn-primary btn-lg btn-block" runat="server" Text="Actualizar" OnClick="btnActualizarUoC_Click" />
        <br />

         <asp:Label ID="Label1" runat="server" Text="Código de Unidad/Caja:"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
         <asp:TextBox ID="txtIDUoC" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
         <asp:TextBox ID="txtDescripcionUoC" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label3" runat="server" Text="Código de Charola:"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
         <asp:TextBox ID="txtIDCharolaUoC" runat="server"></asp:TextBox>
         <br />
         <br />

        <asp:Button ID="btnAgregarUoC" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar" OnClick="btnAgregarUoC_Click" />

        </div>
</asp:Content>

