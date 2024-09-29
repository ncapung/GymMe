using CrystalDecisions.Web;
using GymMe.Controller;
using GymMe.DataSet;
using GymMe.Model;
using GymMe.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport3 report = new CrystalReport3();
            CrystalReportViewer1.ReportSource = report;
            List<TransactionHeader> tl= TransactionController.getTransactionHeaders();
            List<MsSupplement> sl = SupplementController.getAllSupplements();
            report.SetDataSource(GetDataSet(tl,sl));
        }

        public DataSet1 GetDataSet(List<TransactionHeader> transactionHeaders, List<MsSupplement> supplements)
        {
            DataSet1 transactionDataset = new DataSet1();
            var transactionHeaderTable = transactionDataset.TransactionHeader;
            var transactionDetailTable = transactionDataset.TransactionDetails;
            var supplementTable = transactionDataset.MsSupplement;




            foreach (TransactionHeader x in transactionHeaders)
            {
                var transactionHeaderTableRow = transactionHeaderTable.NewRow();
                transactionHeaderTableRow["TransactionID"] = x.TransactionID;
                transactionHeaderTableRow["UserID"] = x.UserID;
                transactionHeaderTableRow["TransactionDate"] = x.TransactionDate;
                transactionHeaderTableRow["Status"] = x.Status;
                transactionHeaderTable.Rows.Add(transactionHeaderTableRow);

                foreach (TransactionDetail y in x.TransactionDetails)
                {
                    var transactionDetailRow = transactionDetailTable.NewRow();
                    transactionDetailRow["TransactionID"] = x.TransactionID;
                    transactionDetailRow["SupplementID"] = y.SupplementID;
                    transactionDetailRow["Quantity"] = y.Quantity;
                    transactionDetailTable.Rows.Add(transactionDetailRow);

                    var xe = y.MsSupplement;
                    var supplementTableRow = supplementTable.NewRow();
                    supplementTableRow["SupplementID"] = xe.SupplementID;
                    supplementTableRow["SupplementName"] = xe.SupplementName;
                    supplementTableRow["SupplementExpiryDate"] = xe.SupplementExpiryDate;
                    supplementTableRow["SupplementPrice"] = xe.SupplementPrice;
                    supplementTableRow["SupplementTypeID"] = xe.SupplementTypeID;
                    supplementTable.Rows.Add(supplementTableRow);
                    
                }
            }

            return transactionDataset;
        }
    }
}