#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using FastReport;
using FastReport.Utils;
using FastReport.Export.Image;
using FastReport.Export.Html;
using FastReport.Export.PdfSimple;

#endregion

namespace RT2020.Reports
{
    public partial class FastReportViewer : UserControl
    {
        public string ReportFilePath { get; set; }
        public DataSet DataSource { get; set; }
        public MimeType ReportType { get; set; }

        public FastReportViewer()
        {
            InitializeComponent();
        }

        private void FastReportViewer_Load(object sender, EventArgs e)
        {
            //LoadReport();
        }

        public void LoadReport()
        {
            var result = "";
            //var report = new GeneralResourceHandle("");
            //var reportUrl = new Gizmox.WebGUI.Common.Resources.
            var reportFilePath = Path.Combine(VWGContext.Current.Config.GetDirectory("FastReport"), "reportname.frx");
            string mime = "";

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    Config.WebMode = true;

                    using (Report report = new Report())
                    {
                        report.Load(reportFilePath);
                        //report.RegisterData(this.DataSource, "NorthWind");
                        report.RegisterData(this.DataSource);

                        /**
                        if (query.Parameter != null)
                        {
                            report.SetParameterValue("Parameter", query.Parameter); // Defines the value of the report parameter, if the parameter value is set in the URL
                        }
                        */

                        report.Prepare();   //Prepare the report

                        switch (this.ReportType)
                        {
                            case MimeType.PNG:
                                #region if the selected format is png
                                ImageExport img = new ImageExport();
                                img.ImageFormat = ImageExportFormat.Png;
                                img.SeparateFiles = false;
                                img.ResolutionX = 96;
                                img.ResolutionY = 96;
                                report.Export(img, stream);
                                mime = "image/png";
                                break;
                                #endregion
                            case MimeType.PDF:
                                #region export as PDF
                                var pdf = new PDFSimpleExport();
                                pdf.Export(report.Report, "filename");
                                mime = "application/pdf";
                                break;
                                #endregion
                            case MimeType.HMTL:
                            default:
                                #region report export to HTML
                                HTMLExport html = new HTMLExport();
                                html.SinglePage = true;     //report on the one page
                                html.Navigator = false;     //navigation panel on top
                                html.EmbedPictures = true;  //build in images to the document
                                report.Export(html, stream);
                                mime = "text/html";
                                break;
                                #endregion
                        }

                        // result = stream to string
                        var reader = new StreamReader(stream);
                        result = reader.ReadToEnd();

                        stream.Flush();
                    }
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    stream.Dispose();
                }
            }
        }
    }

    public enum MimeType
    {
        HMTL,
        PDF,
        PNG
    }
}