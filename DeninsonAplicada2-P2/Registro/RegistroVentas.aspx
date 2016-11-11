<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroVentas.aspx.cs" Inherits="DeninsonAplicada2_P2.Registro.RegistroVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Articulo ID:"></asp:Label>
    <asp:TextBox ID="ArticuloIdTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="buscarArticuloButton" runat="server" Text="BUSCAR" OnClick="buscarArticuloButton_Click" />
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat="server" Height="21px" Width="243px"></asp:TextBox>
   <br/>
    <asp:Label ID="Label3" runat="server" Text="Existencia"></asp:Label>
    <asp:TextBox ID="existenciaTextBox" runat="server"></asp:TextBox>
       <br/>
    <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
    <asp:TextBox ID="precioTextBox" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="Label5" runat="server" Text="Venta Id"></asp:Label>
    <asp:TextBox ID="idVentaTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="buscarButton" runat="server" Text="Buscar" />
     <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>
    <asp:TextBox ID="FechaTexBox" runat="server"></asp:TextBox>
    <br/>
   
    <asp:Label ID="Label7" runat="server" Text="Monto"></asp:Label>
    <asp:TextBox ID="montoTextBox" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="Label9" runat="server" Text="Articulo"></asp:Label>
    <asp:DropDownList ID="articuloDropDownList" runat="server" Height="16px" Width="155px"></asp:DropDownList>
    <asp:Label ID="Label8" runat="server" Text="Cantidad"></asp:Label>
    <asp:TextBox ID="cantidadTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="Label10" runat="server" Text="Precio"></asp:Label>
    <asp:DropDownList ID="precioDropDownList" runat="server" Height="23px" Width="159px"></asp:DropDownList>
    <asp:Button ID="agregarButton" runat="server" Text="Agregar" OnClick="agregarButton_Click" />
    <asp:GridView ID="ventasGridView" runat="server" AutoGenerateColumns="False" Height="20px">
        <Columns>
            <asp:BoundField HeaderText="Articulo" DataField="Articulo" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </Columns>
    </asp:GridView>
    <br/>
    <br/>
    <asp:Button ID="nuevoButton" Class="btn btn-Success" runat="server" Text="Nuevo" />
    <asp:Button ID="guardarButton" Class="btn btn-primary" runat="server" Text="Guardar" Width="106px" OnClick="guardarButton_Click" />
    <asp:Button ID="eliminarButton" Class="btn btn-danger" runat="server" Text="Eliminar" />

</asp:Content>
