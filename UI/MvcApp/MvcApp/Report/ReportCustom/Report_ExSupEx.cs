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
    public partial class Report_ExSupEx : DevExpress.XtraReports.UI.XtraReport
    {
        Hashtable ht = CommonReport.GetDatadictionary("DataUnit", CommonReport.DataType.Code);

        public Report_ExSupEx() { }

        public Report_ExSupEx(Customs.Entity.Store_in_headInfo CurInHead, List<Customs.Entity.Store_in_listInfo> list, int PageIndex, int PageSize, bool LastPage, int FirstPage, string Title)
        {
            InitializeComponent();

            try
            {
                //初始化表头部分
                if (Title == "OutJG")
                {
                    labTitle.Text = "出 口 监 管 仓 货 物";
                }
                if (Title == "inBS")
                {
                    labTitle.Text = "进 口 保 税 仓 货 物";
                }
                labPage.Text = "第 " + (PageIndex + 1).ToString() + " 续页";
                labWareNO.Text = CurInHead.Bill_id;
                //目的海关
                lbCust_bill_id.Text = CurInHead.Cust_bill_id;
                labCustom.Text = CurInHead.Ie_portName;
                tbRemark.Text = CurInHead.Remark;
                labDate.Text = CurInHead.Ie_date.ToString("yyyy-MM-dd") != "1900-01-01" ? CurInHead.Ie_date.ToString("yyyy-MM-dd") : "";
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

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void init(List<Customs.Entity.Store_in_listInfo> list, int i, int j)
        {
            #region 给table赋值
            DevExpress.XtraReports.UI.XRTableCell seq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cseq" + i, false);
            seq.Text = list[j].G_no.ToString();
            DevExpress.XtraReports.UI.XRTableCell cCode = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCode" + i, false);
            cCode.Text = list[j].Code_t;
            //货物名称和规格
            DevExpress.XtraReports.UI.XRTableCell cName = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cName" + i, false);
            cName.Text = list[j].Mg_name + "\n" + list[j].Mg_spec + "\n" + list[j].Pkgs + "件";
            //数量
            string temp = PublicMethod.RemoveZero(list[j].Qty_2.ToString())=="0" ? "" : PublicMethod.RemoveZero(list[j].Qty_2.ToString());
            DevExpress.XtraReports.UI.XRTableCell cNum = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cNum" + i, false);
            //cNum.Text = PublicMethod.RemoveZero(list[j].G_qty.ToString())+"\n"+PublicMethod.RemoveZero(list[j].Qty_1.ToString())+"\n"+temp;
            cNum.Text = PublicMethod.RemoveZero(list[j].Qty_1.ToString()) + "\n" + temp + "\n" + PublicMethod.RemoveZero(list[j].G_qty.ToString());
            //单位
            DevExpress.XtraReports.UI.XRTableCell cUnit = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cUnit" + i, false);
            //cUnit.Text =PublicMethod.GetHashValue(ht,list[j].G_unit).ToString() + "\n" + PublicMethod.GetHashValue(ht,list[j].Unit_code1).ToString() + "\n"+PublicMethod.GetHashValue(ht,list[j].Unit_code2).ToString();//list[j].G_unit;
            cUnit.Text = CommonReport.GetHashValue(ht, list[j].Unit_code1).ToString() + "\n" + CommonReport.GetHashValue(ht, list[j].Unit_code2).ToString() + "\n" + CommonReport.GetHashValue(ht, list[j].G_unit).ToString();//list[j].G_unit;

            DevExpress.XtraReports.UI.XRTableCell cWeight = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cWeight" + i, false);
            cWeight.Text = list[j].Gross + "\n" + list[j].Net;
            //币值
            DevExpress.XtraReports.UI.XRTableCell cCoin = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCoin" + i, false);
            cCoin.Text = CommonReport.GetCode("118", list[j].Curr_code.ToString(), true);

            DevExpress.XtraReports.UI.XRTableCell cPrice = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPrice" + i, false);
            cPrice.Text = list[j].Unit_price.ToString();

            DevExpress.XtraReports.UI.XRTableCell cTotal = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cTotal" + i, false);
            cTotal.Text = list[j].Trade_ttl.ToString();
            #endregion
        }


    }
}
