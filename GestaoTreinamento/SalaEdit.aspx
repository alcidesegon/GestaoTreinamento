﻿<%@ Page Title="Pessoas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalaEdit.aspx.cs" Inherits="GestaoTreinamento.SalaEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Sala</h2>
            <div style="width:100%;">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        Nome
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Nome é obrigatório!" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
