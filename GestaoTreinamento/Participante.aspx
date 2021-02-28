<%@ Page Title="Pessoas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Participante.aspx.cs" Inherits="GestaoTreinamento.Participante" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Participantes do Treinamento <%= Treinamento %></h2>
            <div style="width:100%;">
                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
                <asp:Button ID="btnReorganizar" runat="server" Text="Organizar participantes" OnClick="btnReorganizar_Click" />
            </div>
            <br />
            <asp:GridView 
                ID="gridParticipantes" runat="server"  CssClass="table table-bordered table-striped"
                AutoGenerateColumns="false" OnRowDeleting="gridParticipantes_RowDeleting" OnRowDataBound="gridParticipantes_RowDataBound" >
                <RowStyle CssClass="data-row" />
                <AlternatingRowStyle CssClass="alt-data-row" />
                <HeaderStyle CssClass="header-row" />
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="PESSOA" DataField="PESSOA" />
                    <asp:BoundField HeaderText="SALA" DataField="SALA" />
                    <asp:BoundField HeaderText="ESPAÇO" DataField="ESPACO" />
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
