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
    public partial class Report_ckjgcc : DevExpress.XtraReports.UI.XtraReport
    {
        private Hashtable ht = CommonReport.GetDatadictionary("DataUnit", CommonReport.DataType.Code);
        Hashtable htCustom = CommonReport.GetCustom();

        public Report_ckjgcc() { }
        public Report_ckjgcc(Customs.Entity.Store_out_headInfo CurOutHead, List<Customs.Entity.Store_out_listInfo> CurOutList, string Type)
        {
            InitializeComponent();
            //Type = "保税";
            try
            {
                #region 表头项
                if (Type == "监管")
                {
                    tbWareName.Text = "华南物流监管仓";
                    tbVar.Text = "集装箱号";
                    tbTitle.Text = "出 口 监 管 仓 货 物";
                    labCustomCode.Text = CurOutHead.Bill_id;
                    //labWareNO.Text = CurOutHead.Store_code;
                    //tbSum.Visible = false;
                }
                if (Type == "保税" || Type == "MCC")
                {
                    xrPictureBox1.Visible = false;
                    labCustomCode.Visible = false;
                    xrLabel3.Visible = false;
                    tbTitle.Text = "进 口 保 税 仓 货 物";
                    tbWareName.Text = "华南物流保税仓";
                    tbVar.Text = "载货清单号";
                    xrLabel2.Text = "出仓单编号:";
                    //labWareNO.Text = CurOutHead.Bill_id;
                }
                //总的件数合计
                BarCode.Text = CurOutHead.Bill_id;

                lbJZXH.Text = CurOutHead.Cntnr_spec;
                labWareNO.Text = CurOutHead.Cust_bill_id;
                lbCnsNo.Text = CurOutHead.Cns_no;

                tbTotalPkgs.Text = CurOutHead.Pkgs_num.ToString();
                tbreferdoc.Text = CurOutHead.Refer_doc;
                tbLoadCarCode.Text = CurOutHead.Shipping_no;
                tbdeliverUnit.Text = htCustom[ CurOutHead.Lease_holder]!=null?htCustom[ CurOutHead.Lease_holder].ToString():"";
                tbOut.Text = CurOutHead.Ie_port;
                tbFZCode.Text = CurOutHead.Seal_no;
                //司机本海关编号
                tbcarCcode.Text = CurOutHead.Driver_no;
                tbOutCountry.Text = CommonReport.GetCode("102", CurOutHead.Trade_coun, false);
                tbCarNO.Text = CurOutHead.Car_no;
                tbOutType.Text = CurOutHead.Out_type;
                lbRemark.Text = CurOutHead.Remark;
                if (CurOutHead.Ie_date.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    labDate.Text = CurOutHead.Ie_date.ToString("yyyy-MM-dd");    
                }
                //labCustom.Text = CurOutHead.Ie_port;
                tbTotal.Text = CurOutHead.All_value.ToString();
                tbTotalW.Text = "毛重:" + CurOutHead.Gross_wt.ToString() + "\n" + "净重:" + CurOutHead.Net_wt.ToString();
                #endregion

                #region 明细项
                if (CurOutList.Count <= 5)
                {
                    for (int i = 1; i <= CurOutList.Count; i++)
                    {
                        init(i, CurOutList);
                    }
                }
                if (CurOutList.Count > 5)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        init(i, CurOutList);
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
        private void init(int i, List<Customs.Entity.Store_out_listInfo> List)
        {
            //初始化每列的数据
            DevExpress.XtraReports.UI.XRTableCell COldBill_id = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("COldBill_id" + i, false);
            COldBill_id.Text = List[i - 1].Cust_in_bill_id ;

            DevExpress.XtraReports.UI.XRTableCell cInseq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cInseq" + i, false);
            cInseq.Text = List[i - 1].In_g_no.ToString();

            DevExpress.XtraReports.UI.XRTableCell cOutseq = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cOutseq" + i, false);
            cOutseq.Text = List[i - 1].G_no.ToString();

            DevExpress.XtraReports.UI.XRTableCell cPlace = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPlace" + i, false);
            cPlace.Text = List[i - 1].Loc;

            DevExpress.XtraReports.UI.XRTableCell cCode = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCode" + i, false);
            cCode.Text = List[i - 1].Code_t;

            DevExpress.XtraReports.UI.XRTableCell cName = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cName" + i, false);
            cName.Text = List[i - 1].Mg_name + "\n" + List[i - 1].Mg_spec + "\n" + List[i - 1].Pkgs + "件";

            string temp = PublicMethod.RemoveZero(List[i-1].Qty_2.ToString()) == "0" ? "" : PublicMethod.RemoveZero(List[i-1].Qty_2.ToString());
            DevExpress.XtraReports.UI.XRTableCell cNum = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cNum" + i, false);
            //cNum.Text = PublicMethod.RemoveZero(List[i - 1].G_qty.ToString())+"\n"+PublicMethod.RemoveZero(List[i-1].Qty_1.ToString())+"\n"+temp;
            cNum.Text = PublicMethod.RemoveZero(List[i - 1].Qty_1.ToString()) + "\n" + temp + "\n" + PublicMethod.RemoveZero(List[i - 1].G_qty.ToString());

            DevExpress.XtraReports.UI.XRTableCell cUnit = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cUnit" + i, false);
            //cUnit.Text = PublicMethod.GetHashValue(ht,List[i - 1].G_unit.ToString()).ToString() + "\n" + PublicMethod.GetHashValue(ht,List[i - 1].Unit_code1).ToString() + "\n" + PublicMethod.GetHashValue(ht,List[i - 1].Unit_code2).ToString();
            cUnit.Text = CommonReport.GetHashValue(ht, List[i - 1].Unit_code1).ToString() + "\n" + CommonReport.GetHashValue(ht, List[i - 1].Unit_code2).ToString() + "\n" + CommonReport.GetHashValue(ht, List[i - 1].G_unit.ToString()).ToString();
            DevExpress.XtraReports.UI.XRTableCell cWeight = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cWeight" + i, false);
            cWeight.Text = List[i - 1].Gross + "\n" + List[i - 1].Net;

            DevExpress.XtraReports.UI.XRTableCell cCoin = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cCoin" + i, false);
            cCoin.Text = CommonReport.GetCode("118", List[i - 1].Curr_code, true);

            DevExpress.XtraReports.UI.XRTableCell cPrice = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cPrice" + i, false);
            cPrice.Text = List[i - 1].Unit_price.ToString();

            DevExpress.XtraReports.UI.XRTableCell cTotal = (DevExpress.XtraReports.UI.XRTableCell)Detail.FindControl("cTotal" + i, false);
            cTotal.Text = List[i - 1].Trade_ttl.ToString();
        }
        #endregion

    }
}
