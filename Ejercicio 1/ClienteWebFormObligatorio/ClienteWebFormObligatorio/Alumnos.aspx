<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="ClienteWebFormObligatorio.Alumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
        <fieldset>
        <legend><h3 style="color:darkred; font-family:Century">Complete el formulario para agregar un alumno</h3></legend>
        Número <asp:TextBox ID="TxtNumero" runat="server"></asp:TextBox>
        <br />
        <br />
        Cédula <asp:TextBox ID="TxtDocumento" runat="server"></asp:TextBox>
        <br />
        <br />
        Nombre <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        Apellido <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />
        &nbsp;<asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
        <br />
        <hr />
            <br />
        <asp:Button ID="BtnListar" runat="server" Text="Listar" OnClick="BtnListar_Click" />
        &nbsp;<asp:Button ID="btnDescargar" runat="server" Text="Descargar Archivo" OnClick="btnDescargar_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </fieldset>

    
    </form>
</body>
</html>
