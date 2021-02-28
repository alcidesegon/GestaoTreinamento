<%@ Page Title="Pessoas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="GestaoTreinamento.Consulta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Consultas</h2>
            <br />
            <br />
            <h4>Consulta de pessoas</h4>
            <div style="width:100%;">
                Pessoa:
                <asp:DropDownList ID="cbPessoas" runat="server" DataTextField="Nome" DataValueField="ID"></asp:DropDownList>
                <asp:Button ID="btnBuscarPessoas" runat="server" Text="Buscar" OnClick="btnBuscarPessoas_Click" />
            </div>
            <br />
            <asp:GridView 
                ID="gridPessoas" runat="server" 
                AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <RowStyle CssClass="data-row" />
                <AlternatingRowStyle CssClass="alt-data-row" />
                <HeaderStyle CssClass="header-row" />
                <Columns>
                    <asp:BoundField HeaderText="NOME" DataField="NOME" />
                    <asp:BoundField HeaderText="SOBRENOME" DataField="SOBRENOME" />
                    <asp:BoundField HeaderText="TREINAMENTO" DataField="TREINAMENTO" />
                    <asp:BoundField HeaderText="SALA" DataField="SALA" />
                    <asp:BoundField HeaderText="ESPAÇO" DataField="ESPACO" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <h4>Consulta de salas</h4>
            <div style="width:100%;">
                Sala:
                <asp:DropDownList ID="cbSala" runat="server" DataTextField="Nome" DataValueField="ID"></asp:DropDownList>
                <asp:Button ID="btnBuscarSala" runat="server" Text="Buscar" OnClick="btnBuscarSala_Click" />
            </div>
            <br />
            <asp:GridView 
                ID="gridSalas" runat="server" 
                AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                <RowStyle CssClass="data-row" />
                <AlternatingRowStyle CssClass="alt-data-row" />
                <HeaderStyle CssClass="header-row" />
                <Columns>
                    <asp:BoundField HeaderText="PARTICIPANTE" DataField="NOME" />
                    <asp:BoundField HeaderText="TREINAMENTO" DataField="TREINAMENTO" />
                    <asp:BoundField HeaderText="ESPAÇO DE CAFÉ" DataField="ESPACO" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
