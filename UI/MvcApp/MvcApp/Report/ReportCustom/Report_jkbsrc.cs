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
    public partial class Report_jkbsrc : DevExpress.XtraReports.UI.XtraReport
    {
        private Hashtable htIn_type = CommonReport.GetDatadictionary("ITYPE", CommonReport.DataType.Code);
        private Hashtable httrade_way = CommonReport.GetAllTradeMode();//WareCommon.GetDatadictionary("trade_way", DataType.Code);
        private Hashtable ht = CommonReport.GetDatadictionary("DataUnit", CommonReport.DataType.Code);
        public Report_jkbsrc()
        {
        }

        public Report_jkbsrc(Customs.Entity.Store_in_headInfo CurInHead, List<Customs.Entity.Store_in_listInfo> list)
        {
            InitializeComponent();

            try
            {

                //初始化表头部分
                //仓库编号

                BarCode.Text = CurInHead.Bill_id;

                labWareNO.Text = CurInHead.Store_code;
                lbHz.Text = CurInHead.Cust_bill_id;
                lbCnsNo.Text = CurInHead.Cns_no;
                labWareNO.Text = CurInHead.Bill_id;
                tbWareName.Text = "深国际华南物流保税仓";
                tbreferdoc.Text = CurInHead.Refer_doc;
                //合计总件数
                tbpkgs.Text = CurInHead.Pkgs_num.ToString();
                //发货单位
                tbdeliverUnit.Text = CommonReport.GetCompanyName(CurInHead.Rs_code);
                tbSumWeight.Text = "毛重:" + CurInHead.Gross_wt.ToString() + "\n" + "净重:" + CurInHead.Net_wt.ToString();//CurInHead.Gross_wt.ToString();
                tbtotalValue.Text = CurInHead.All_value.ToString();
                tbCarNo.Text = CurInHead.Car_no;
                tbOutCountry.Text = list != null ? CommonReport.GetCode("102", list[0].Orign_coun, false) : "";

                //tbtaxRebate.Text = CurInHead.Tax_flag == "1" ? "是" : "否";
                tbTradetype.Text = httrade_way.Contains(CurInHead.Trade_mode) ? httrade_way[CurInHead.Trade_mode].ToString() : "";
                tbInWaretype.Text = htIn_type.Contains(CurInHead.In_type) ? htIn_type[CurInHead.In_type].ToString() : "";
                //目的海关
                labCustom.Text = CurInHead.Ie_portName;
                //报关员
                //labName.Text = "报关员";
                //货主
                //lab.Text = "龙卓公司";
                //仓库员
                //labAdmin.Text = "胡藩";
                tbRemark1.Text = CurInHead.Remark;
                if (CurInHead.Ie_date.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    labDate.Text = CurInHead.Ie_date.ToString("yyyy-MM-dd");   
                }
                if (list.Count <= 5)
                {
                    for (int i = 1; i <= list.Count; i++)
                    {
                        #region 给table赋值
                        DevExpress.XtraReports.UI.XRTableCell seq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cseq" + i, false);
                        seq.Text = list[i - 1].G_no.ToString();
                        DevExpress.XtraReports.UI.XRTableCell cCode = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCode" + i, false);
                        cCode.Text = list[i - 1].Code_t;
                        //货物名称和规格
                        DevExpress.XtraReports.UI.XRTableCell cName = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cName" + i, false);
                        cName.Text = list[i - 1].Mg_name + "\n" + list[i - 1].Mg_spec + "\n" + list[i - 1].Pkgs + "件";
                        //数量
                        string temp = PublicMethod.RemoveZero(list[i - 1].Qty_2.ToString()) == "0" ? "" : PublicMethod.RemoveZero(list[i-1].Qty_2.ToString());
                        DevExpress.XtraReports.UI.XRTableCell cNum = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cNum" + i, false);
                        //cNum.Text = list[i - 1].G_qty.ToString()+"\n"+list[i-1].Qty_1.ToString()+"\n"+temp;
                        cNum.Text = list[i - 1].Qty_1.ToString() + "\n" + temp + "\n" + list[i - 1].G_qty.ToString();
                        //单位
                        DevExpress.XtraReports.UI.XRTableCell cUnit = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cUnit" + i, false);
                        //cUnit.Text =PublicMethod.GetHashValue(ht, list[i - 1].G_unit)+"\n"+PublicMethod.GetHashValue(ht,list[i-1].Unit_code1)+"\n"+PublicMethod.GetHashValue(ht,list[i-1].Unit_code2);
                        cUnit.Text = CommonReport.GetHashValue(ht, list[i - 1].Unit_code1).ToString() + "\n" + CommonReport.GetHashValue(ht, list[i - 1].Unit_code2).ToString() + "\n" + CommonReport.GetHashValue(ht, list[i - 1].G_unit).ToString();

                        DevExpress.XtraReports.UI.XRTableCell cWeight = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cWeight" + i, false);
                        cWeight.Text = list[i - 1].Gross + "\r\n" + list[i - 1].Net;
                        //币值
                        DevExpress.XtraReports.UI.XRTableCell cCoin = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCoin" + i, false);
                        cCoin.Text = CommonReport.GetCode("118", list[i - 1].Curr_code.ToString(), true);

                        DevExpress.XtraReports.UI.XRTableCell cPrice = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPrice" + i, false);
                        cPrice.Text = list[i - 1].Unit_price.ToString();

                        DevExpress.XtraReports.UI.XRTableCell cTotal = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cTotal" + i, false);
                        cTotal.Text = list[i - 1].Trade_ttl.ToString();
                        #endregion
                    }
                }
                if (list.Count > 5)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        #region 给table赋值
                        DevExpress.XtraReports.UI.XRTableCell seq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cseq" + i, false);
                        seq.Text = list[i - 1].G_no.ToString();
                        DevExpress.XtraReports.UI.XRTableCell cCode = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCode" + i, false);
                        cCode.Text = list[i - 1].Code_t;
                        //货物名称和规格
                        DevExpress.XtraReports.UI.XRTableCell cName = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cName" + i, false);
                        cName.Text = list[i - 1].Mg_name + "\n" + list[i - 1].Mg_spec + "\n" + list[i - 1].Pkgs + "件";
                        //数量
                        string temp = PublicMethod.RemoveZero(list[i - 1].Qty_2.ToString()) == "0" ? "" : PublicMethod.RemoveZero(list[i-1].Qty_2.ToString());
                        DevExpress.XtraReports.UI.XRTableCell cNum = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cNum" + i, false);
                        //cNum.Text = PublicMethod.RemoveZero(list[i - 1].G_qty.ToString()) + "\n" + PublicMethod.RemoveZero(list[i - 1].Qty_1.ToString()) + "\n" + temp;//list[i - 1].G_qty.ToString();
                        cNum.Text = PublicMethod.RemoveZero(list[i - 1].Qty_1.ToString()) + "\n" + temp + "\n" +PublicMethod.RemoveZero(list[i - 1].G_qty.ToString()) ;//list[i - 1].G_qty.ToString();
                        //单位
                        DevExpress.XtraReports.UI.XRTableCell cUnit = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cUnit" + i, false);
                        //cUnit.Text = PublicMethod.GetHashValue(ht,list[i - 1].G_unit).ToString() + "\n" + PublicMethod.GetHashValue(ht,list[i - 1].Unit_code1).ToString() + "\n" + PublicMethod.GetHashValue(ht,list[i - 1].Unit_code2).ToString();// ht.Contains(list[i - 1].G_unit) ? ht[list[i - 1].G_unit].ToString() : ""; //list[i - 1].G_unit;
                        cUnit.Text = CommonReport.GetHashValue(ht, list[i - 1].Unit_code1).ToString() + "\n" + CommonReport.GetHashValue(ht, list[i - 1].Unit_code2).ToString() + "\n" + CommonReport.GetHashValue(ht, list[i - 1].G_unit).ToString();// ht.Contains(list[i - 1].G_unit) ? ht[list[i - 1].G_unit].ToString() : ""; //list[i - 1].G_unit;

                        DevExpress.XtraReports.UI.XRTableCell cWeight = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cWeight" + i, false);
                        cWeight.Text = list[i - 1].Gross + "\n" + list[i - 1].Net;
                        //币值
                        DevExpress.XtraReports.UI.XRTableCell cCoin = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCoin" + i, false);
                        cCoin.Text = CommonReport.GetCode("118", list[i - 1].Curr_code.ToString(), true);

                        DevExpress.XtraReports.UI.XRTableCell cPrice = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPrice" + i, false);
                        cPrice.Text = list[i - 1].Unit_price.ToString();

                        DevExpress.XtraReports.UI.XRTableCell cTotal = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cTotal" + i, false);
                        cTotal.Text = list[i - 1].Trade_ttl.ToString();
                        #endregion
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
