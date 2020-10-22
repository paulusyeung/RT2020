using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Microsoft.Reporting.WebForms;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

namespace RT2020.Controls.Reporting
{
    public class RdlExport
    {

        #region Properties
        public enum ReportDestinations { Preview, Printer, ExcelFile, PdfFile }

        private DataTable dataSource = null;
        private string reportName = string.Empty;
        private string reportDatasourceName = string.Empty;
        private ReportDestinations reportDestination = ReportDestinations.Preview;
        private string[,] parameters;

        /// <summary>
        /// Data Source Name of the Main Report
        /// </summary>
        public DataTable Datasource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                this.dataSource = value;
            }
        }

        /// <summary>
        /// the class name of the report
        /// </summary>
        public string ReportName
        {
            get
            {
                return this.reportName;
            }
            set
            {
                this.reportName = value;
            }
        }

        public string ReportDatasourceName
        {

            get
            {
                return this.reportDatasourceName;
            }
            set
            {
                this.reportDatasourceName = value;
            }
        }

        /// <summary>
        /// Assigned to one of the following:
        /// Preview = screen (default)
        /// Printer = redirect to printer
        /// ExcelFile = generate Excel file
        /// PdfFile = generate PDF file
        /// </summary>
        public ReportDestinations ReportDestination
        {
            get
            {
                return this.reportDestination;
            }
            set
            {
                this.reportDestination = value;
            }
        }

        /// <summary>
        /// parameters used in the report
        /// string array: name, value
        /// e.g. string [,] param = {{"FromDate", "2008-08-01 00:00:00"}, {"ToDate", "2008-08-31 23:59:59"}}
        /// </summary>
        public string[,] Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
            }
        }
        #endregion

        #region Export To Excel
        private void ExportToExcel()
        {
            Microsoft.Reporting.WebForms.ReportViewer oViewer = new Microsoft.Reporting.WebForms.ReportViewer();

            if (reportName != string.Empty)
            {
                oViewer.LocalReport.ReportEmbeddedResource = reportName;
            }
            oViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(RptSubreportProcessingEventHandler);
            oViewer.LocalReport.DataSources.Clear();

            ReportDataSource ds = new ReportDataSource(reportDatasourceName, dataSource);
            oViewer.LocalReport.DataSources.Add(ds);

            int paramCount = this.parameters.GetLength(0);
            if (paramCount > 0)
            {
                ReportParameter[] param = new ReportParameter[paramCount];
                for (int i = 0; i < paramCount; i++)
                {
                    param[i] = new ReportParameter(parameters[i, 0], parameters[i, 1]);
                }
                oViewer.LocalReport.SetParameters(param);
            }

            oViewer.ProcessingMode = ProcessingMode.Local;
            oViewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = oViewer.LocalReport.Render(
               "Excel", null, out mimeType, out encoding, out extension,
               out streamids, out warnings
               );

            HttpResponse response = VWGContext.Current.HttpContext.Response;

            response.Clear();
            response.ClearHeaders();

            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("content-disposition", "attachment; filename=\"Export.xls\"");
            response.BinaryWrite(bytes);
            response.Flush();
            response.End();

        }
        #endregion

        #region Export To PDF
        private void ExportToPdf()
        {
            Microsoft.Reporting.WebForms.ReportViewer oViewer = new Microsoft.Reporting.WebForms.ReportViewer();

            if (reportName != string.Empty)
            {
                oViewer.LocalReport.ReportEmbeddedResource = reportName;
            }
            oViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(RptSubreportProcessingEventHandler);
            oViewer.LocalReport.DataSources.Clear();

            ReportDataSource ds = new ReportDataSource(reportDatasourceName, dataSource);
            oViewer.LocalReport.DataSources.Add(ds);

            // David [2008-10-27] : In case some reports using extrenal images, the Property 'EnableExternalImages' should be enabled.
            oViewer.LocalReport.EnableExternalImages = true;

            int paramCount = this.parameters.GetLength(0);
            if (paramCount > 0)
            {
                ReportParameter[] param = new ReportParameter[paramCount];
                for (int i = 0; i < paramCount; i++)
                {
                    param[i] = new ReportParameter(parameters[i, 0], parameters[i, 1]);
                }
                oViewer.LocalReport.SetParameters(param);
            }

            oViewer.ProcessingMode = ProcessingMode.Local;
            oViewer.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = oViewer.LocalReport.Render(
               "PDF", null, out mimeType, out encoding, out extension,
               out streamids, out warnings
               );

            HttpResponse response = VWGContext.Current.HttpContext.Response;

            response.Clear();
            response.ClearHeaders();

            response.ContentType = "application/pdf";
            response.AddHeader("content-disposition", "attachment; filename=\"Export.pdf\"");
            response.BinaryWrite(bytes);
            response.Flush();
            response.End();
        }
        #endregion

        void RptSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource(reportDatasourceName, dataSource));
        }

        public void ToExcel()
        {
            ExportToExcel();
        }

        public void ToPdf()
        {
            ExportToPdf();
        }
    }
}
