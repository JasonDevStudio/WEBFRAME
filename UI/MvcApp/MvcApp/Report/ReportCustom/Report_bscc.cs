using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using MvcApp.Report.Common;
using ILIMS.Common;

namespace ILIMS.UI
{
    public partial class Report_bscc : DevExpress.XtraReports.UI.XtraReport
    {
        private Hashtable ht = CommonReport.GetDatadictionary("DataUnit", CommonReport.DataType.Code);

        public Report_bscc() { }

        public Report_bscc(Customs.Entity.Store_out_headInfo CurOutHead, List<Customs.Entity.Store_out_listInfo> list, int PageIndex, int PageSize, bool LastPage, int FirstPage, string Title)
        {
            InitializeComponent();
            //初始化表头
            try
            {
                #region 表头部分
                //初始化表头部分
                if (Title == "监管")
                {
                    labTitle.Text = "出 口 监 管 仓 货 物";
                }
                if (Title == "保税" || Title == "MCC")
                {
                    labTitle.Text = "进 口 保 税 仓 货 物";
                }
                labPage.Text = "第 " + (PageIndex + 1).ToString() + " 续页";

                labCustom.Text = CurOutHead.Ie_port;
                if (CurOutHead.Ie_date.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    labDate.Text = CurOutHead.Ie_date.ToString("yyyy-MM-dd");
                }
                lbcust_bill_id.Text = CurOutHead.Cust_bill_id;
                lbBill_id.Text = CurOutHead.Bill_id;
                #endregion

                #region 明细项
                if (!LastPage)
                {
                    for (int i = 1; i <= PageSize; i++)
                    {
                        int j = i + PageIndex * PageSize + FirstPage - 1;
                        init(list, i, j);
                    }
                }
                else
                {
                    for (int i = 1; i <= list.Count - FirstPage - PageIndex * PageSize; i++)
                    {
                        int j = i + PageIndex * PageSize + FirstPage - 1;
                        init(list, i, j);
                    }
                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region 初始化明细表格
        /// <summary>
        /// 初始化明细
        /// </summary>
        private void init(List<Customs.Entity.Store_out_listInfo> List, int i, int j)
        {
            //初始化每列的数据
            DevExpress.XtraReports.UI.XRTableCell COldBill_id = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("COldBill_id" + i, false);
            COldBill_id.Text = List[j].Cust_in_bill_id;

            DevExpress.XtraReports.UI.XRTableCell cInseq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cInseq" + i, false);
            cInseq.Text = List[j].In_g_no.ToString();

            DevExpress.XtraReports.UI.XRTableCell cOutseq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cOutseq" + i, false);
            cOutseq.Text = List[j].G_no.ToString();

            DevExpress.XtraReports.UI.XRTableCell cPlace = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPlace" + i, false);
            cPlace.Text = List[j].Loc;

            DevExpress.XtraReports.UI.XRTableCell cCode = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCode" + i, false);
            cCode.Text = List[j].Code_t;

            DevExpress.XtraReports.UI.XRTableCell cName = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cName" + i, false);
            cName.Text = List[j].Mg_name + "\n" + List[i - 1].Mg_spec + "\n" + List[i - 1].Pkgs + "件";

            DevExpress.XtraReports.UI.XRTableCell cNum = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cNum" + i, false);
            string temp = PublicMethod.RemoveZero(List[j].Qty_2.ToString()) == "0" ? "" : PublicMethod.RemoveZero(List[j].Qty_2.ToString());
            //cNum.Text = PublicMethod.RemoveZero(List[j].G_qty.ToString()) + "\n" + PublicMethod.RemoveZero(List[j].Qty_1.ToString()) + "\n" + temp;
            cNum.Text = PublicMethod.RemoveZero(List[j].Qty_1.ToString()) + "\n" + temp + "\n" + PublicMethod.RemoveZero(List[j].G_qty.ToString());

            DevExpress.XtraReports.UI.XRTableCell cUnit = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cUnit" + i, false);
            //cUnit.Text =PublicMethod.GetHashValue(ht, List[j].G_unit.ToString()) +"\n"+ PublicMethod.GetHashValue(ht,List[j].Unit_code1).ToString() + "\n" + PublicMethod.GetHashValue(ht,List[j].Unit_code2).ToString();
            cUnit.Text = CommonReport.GetHashValue(ht, List[j].Unit_code1).ToString() + "\n" + CommonReport.GetHashValue(ht, List[j].Unit_code2).ToString() + "\n" + CommonReport.GetHashValue(ht, List[j].G_unit).ToString();

            DevExpress.XtraReports.UI.XRTableCell cWeight = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cWeight" + i, false);
            cWeight.Text = List[j].Gross + "\n" + List[i - 1].Net;

            DevExpress.XtraReports.UI.XRTableCell cCoin = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCoin" + i, false);
            cCoin.Text = CommonReport.GetCode("118", List[j].Curr_code, true); ;

            DevExpress.XtraReports.UI.XRTableCell cPrice = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPrice" + i, false);
            cPrice.Text = List[j].Unit_price.ToString();

            DevExpress.XtraReports.UI.XRTableCell cTotal = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cTotal" + i, false);
            cTotal.Text = List[j].Trade_ttl.ToString();
        }
        #endregion

    }
}
