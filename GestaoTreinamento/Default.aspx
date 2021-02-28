<%@ Page Title="Treinamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestaoTreinamento._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Treinamentos</h2>
            <div style="width:100%;">
                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            </div>
            <br />
            <asp:GridView 
                ID="gridTreinamentos" runat="server" 
                AutoGenerateColumns="false"  OnRowUpdating="gridTreinamentos_RowUpdating" OnRowDeleting="gridTreinamentos_RowDeleting"
                OnRowCommand="gridTreinamentos_RowCommand" CssClass="table table-bordered table-striped" OnRowDataBound="gridTreinamentos_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="NOME" DataField="NOME" />
                    <asp:BoundField HeaderText="INÍCIO" DataField="DATAINICIO" />
                    <asp:BoundField HeaderText="TÉRMINO" DataField="DATAFIM" />
                    <asp:BoundField HeaderText="SITUAÇÃO" DataField="SITUACAO" />
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
                    <asp:TemplateField>
                        <ItemTemplate>  
                            <asp:Button ID="btnParticipante" runat="server" Text="Participantes" CommandName="Participante" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />  
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
