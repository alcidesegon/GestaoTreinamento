<%@ Page Title="Pessoas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TreinamentoNew.aspx.cs" Inherits="GestaoTreinamento.TreinamentoNew" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Treinamento</h2>
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

                <tr>
                    <td>
                        Início
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtInicio" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Início é obrigatório!" ControlToValidate="txtInicio"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Término
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtTermino" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Término é obrigatório!" ControlToValidate="txtTermino"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
