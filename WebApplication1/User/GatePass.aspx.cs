﻿using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace WebApplication1.User
{
    public partial class GatePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropdownID();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ddlOId.SelectedIndex = 0;
            try
            {
                // GenerateReport();
                GeneratePDF();
                txtWeight.Text = "";
            }
            catch (Exception ex)
            {
                txtWeight.Text = "";
            }
        }
        DataTable dataTable = new DataTable();
        void FillDropdownID()
        {
            //ddlID.Items.Clear();
            ddlOId.Items.Add("--Select--");
            DataTable data;
            data = Logics.MySqlDb.GetOrderId();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string theValue = data.Rows[i].ItemArray[0].ToString();
                ddlOId.Items.Add(theValue);
            }
        }

        //void GenerateReportMathod1()
        //{
        //    //Create a new PDF document
        //    PdfDocument doc = new PdfDocument();

        //    //Add a page
        //    PdfPage page = doc.Pages.Add();

        //    //Create a PdfGrid
        //    PdfGrid pdfGrid = new PdfGrid();

        //    //Create a DataTable
            
        //       dataTable = Logics.clsMySQL.GetPDFData();

        //    //Assign data source
        //    pdfGrid.DataSource = dataTable;

        //    //Initialize grid style.
        //    PdfGridStyle gridStyle = new PdfGridStyle();

        //    //Add cell padding.
        //    gridStyle.CellPadding = new PdfPaddings(5, 5, 5, 5);

        //    //Apply style to grid.
        //    pdfGrid.Style = gridStyle;

        //    //Draw grid to the page of PDF document
        //    pdfGrid.Draw(page, new PointF(10, 10));

        //    //Save the document
        //    doc.Save("~/D:\\Output.pdf");

        //    //Close the document
        //    doc.Close(true);
        //}

        void GeneratePDF()
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                string str = txtWeight.Text;
                Paragraph Text = new Paragraph("This is test file"+str);                                
                pdfDoc.Add(Text);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}