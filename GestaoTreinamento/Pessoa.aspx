<%@ Page Title="Pessoas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pessoa.aspx.cs" Inherits="GestaoTreinamento.Pessoa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Pessoas</h2>
            <div style="width:100%;">
                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            </div>
            <br />
            <asp:GridView 
                ID="gridPessoas" runat="server"  CssClass="table table-bordered table-striped"
                AutoGenerateColumns="false" OnRowUpdating="gridPessoas_RowUpdating" OnRowDeleting="gridPessoas_RowDeleting" >
                <RowStyle CssClass="data-row" />
                <AlternatingRowStyle CssClass="alt-data-row" />
                <HeaderStyle CssClass="header-row" />
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="NOME" DataField="NOME" />
                    <asp:BoundField HeaderText="SOBRENOME" DataField="SOBRENOME" />
                    <asp:TemplateField>  
                        <ItemTemplate>  
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Update" />  
                        </ItemTemplate>                         
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>  
                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Delete" />  
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
