<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="PrepareTemplate.Maps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
          <div class="col-md-12">
            <div class="card ">
              <div class="card-header ">
                Google Maps
              </div>
              <div class="card-body ">
                <div id="map" class="map"></div>
              </div>
            </div>
          </div>
        </div>
</asp:Content>
