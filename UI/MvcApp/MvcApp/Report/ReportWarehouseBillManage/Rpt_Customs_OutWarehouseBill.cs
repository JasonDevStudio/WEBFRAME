using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using MvcApp.Report.Common;

namespace ILIMS.DxUI.UI.Report.ReportWarehouseBillManage
{
    public partial class Rpt_Customs_OutWarehouseBill : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// 表头数据
        /// </summary>
        private Customs.Entity.Store_out_headInfo _Store_Out_head;
        /// <summary>
        /// 明细数据
        /// </summary>
        private DataTable _Store_Outs_lists;
        /// <summary>
        /// 编码
        /// </summary>
        private DataTable _dtbSPBCODES;


        /// <summary>
        /// 入仓方式
        /// </summary>
        private DataTable _dtbEnterprise001 = new DataTable();     //监管仓仓租企业
        private DataTable _dtbInType001 = new DataTable();        //监管仓入仓方式
        private DataTable _dtbOutType500 = new DataTable();
        private DataTable _c_complexys = null;

      

        public Rpt_Customs_OutWarehouseBill(Customs.Entity.Store_out_headInfo Store_Out_head, DataTable Store_Outs_lists,

            DataTable dtbSPBCODES, DataTable dtbEnterprise001, DataTable dtbInType001,DataTable dtbOutType500, DataTable c_complexys)
        {
            InitializeComponent();

            this._Store_Out_head = Store_Out_head;
            this._Store_Outs_lists = Store_Outs_lists;
            this._dtbSPBCODES = dtbSPBCODES;
            this._dtbEnterprise001 = dtbEnterprise001;
            this._dtbInType001 = dtbInType001;
            this._dtbOutType500 = dtbOutType500;

            DetailReport.DataSource = _Store_Outs_lists;

            _c_complexys = c_complexys;
        }

        private int i = 0;
        /// <summary>
        ///  明细打印之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //计算汇总信息
            if (_Store_Outs_lists==null||_Store_Outs_lists.Rows.Count<=0)
            {
                return;
            }

            DataRow dr = _Store_Outs_lists.Rows[i];
            string strspbcomplexy = GetStrSpec(_c_complexys, dr["Code_t"].ToString(), dr["Mg_spec"].ToString());
            xrTableCell_Name.Text = dr["Mg_name"].ToString().Trim() + "\r\n";
            xrTableCell_Name.Text += string.IsNullOrEmpty(strspbcomplexy) ? dr["Mg_spec"].ToString().Trim() : strspbcomplexy;

            xrTableCell_QTY.Text = ILIMS.Common.PublicMethod.RemoveZero(dr["QTY_1"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES, "111", dr["UNIT_CODE1"].ToString().Trim());

            if (!string.IsNullOrEmpty(dr["UNIT_CODE2"].ToString()))
            {
                if (decimal.Parse(dr["QTY_2"].ToString().Trim()) == 0)
                {
                    xrTableCell_QTY.Text +="\r\n" + "     "+ GetCodeFromName(_dtbSPBCODES, "111", dr["UNIT_CODE2"].ToString().Trim());
                }
                else
                {

                    xrTableCell_QTY.Text += "\r\n" + "     "+ ILIMS.Common.PublicMethod.RemoveZero(dr["QTY_2"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES, "111", dr["UNIT_CODE2"].ToString().Trim());
                }
            }
            else
            {
                xrTableCell_QTY.Text += "\r\n";
            }

            xrTableCell_QTY.Text += "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["G_QTY"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES, "111", dr["G_UNIT"].ToString().Trim()); 

           
     
            xrTableCell_Weight.Text = ILIMS.Common.PublicMethod.RemoveZero(dr["GROSS"].ToString().Trim()) + "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["NET"].ToString().Trim()) + "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["PKGS"].ToString().Trim()) + "件";

            //xrTableCell_Total.Text = dr["UNIT_PRICE"].ToString().Trim() + "\r\n" +Math.Round (decimal.Parse(dr["TRADE_TTL"].ToString().Trim()),2).ToString() + "\r\n" + dr["CURR_NAME"].ToString().Trim()+"\r\n"+
            //    "美元单价：" + dr["USD_UNIT_PRICE"].ToString().Trim() + "\r\n" + "美元总价：" + Math.Round(decimal.Parse(dr["USD_TRADE_TTL"].ToString().Trim()), 2).ToString();//单价总价币制
            if (!string.IsNullOrEmpty(dr["Curr_code"].ToString()))
            {
                xrTableCell_Total.Text = ILIMS.Common.PublicMethod.RemoveZero(dr["UNIT_PRICE"].ToString().Trim()) + "    " + ILIMS.Common.PublicMethod.RemoveZero(Math.Round(decimal.Parse(dr["TRADE_TTL"].ToString().Trim()), 2).ToString()) + " " + GetCodeFromName(_dtbSPBCODES, dr["Curr_code"].ToString());//单价总价币制
                if (dr["Curr_code"].ToString() != "502")
                { 
                    xrTableCell_Total.Text +="\r\n"+  ILIMS.Common.PublicMethod.RemoveZero(dr["USD_UNIT_PRICE"].ToString().Trim()) + "   " + ILIMS.Common.PublicMethod.RemoveZero(Math.Round(decimal.Parse(dr["USD_TRADE_TTL"].ToString().Trim()), 2).ToString()) + " USD";
                }
            }
            else
            {
                xrTableCell_Total.Text = "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["USD_UNIT_PRICE"].ToString().Trim()) + "    " + ILIMS.Common.PublicMethod.RemoveZero(Math.Round(decimal.Parse(dr["USD_TRADE_TTL"].ToString().Trim()), 2).ToString()) + "  USD";
            }


            string codet = dr["Code_t"] == null ? "" : dr["Code_t"].ToString();
            xrTableCell_Code.Text = codet.Length > 2 ? codet.Insert(codet.Length - 2, ".") : codet; //商品编号
            if (dr["ORIGN_COUN"].ToString().Trim().Length > 0)
            {
                xrTableCell_coun.Text = GetCodeFromName(_dtbSPBCODES, "102", dr["ORIGN_COUN"].ToString().Trim()) + "\r\n" + "(" + dr["ORIGN_COUN"].ToString().Trim() + ")";//原产国
            }
            else
            {
                xrTableCell_coun.Text = "";
            }
            i++;


            //换页s
            // 控制每页报表显示的条数
            if (i % 21 == 0) //每页显示20条 1条是汇总
            {
                //AddTotalNum(ds.Tables["STORE_OUT_LIST"]);
                xrTableCell_NO.Text = "21" + "\r\n" + GetCodeFromName(_dtbSPBCODES, "103", dr["Zm_code"].ToString());
                if (!string.IsNullOrEmpty(dr["BAXH"].ToString()))
                {
                    xrTableCell_NO.Text += "\r\n" + "(" + dr["BAXH"].ToString().Trim() + ")";
                }
                Detail1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            }
            else
            {
                xrTableCell_NO.Text = (i % 21).ToString() + "\r\n" + GetCodeFromName(_dtbSPBCODES, "103", dr["Zm_code"].ToString());
                if (!string.IsNullOrEmpty(dr["BAXH"].ToString()))
                {
                    xrTableCell_NO.Text += "\r\n" + "(" + dr["BAXH"].ToString().Trim() + ")";
                }
                Detail1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            }
        }

        /// <summary>
        /// 文本框转换：（率价）
        /// </summary>
        /// <param name="txtCurrentOperate"></param>        
        /// <returns></returns>
        private string GetToValue(string txtCurrentOperate)
        {
            string sResult = "";
            switch (txtCurrentOperate)
            {
                case "率":
                    {
                        sResult = "率";
                        break;
                    }
                case "单价":
                    {
                        sResult = "单价";
                        break;
                    }
                case "总价":
                    {
                        sResult = "总价";
                        break;
                    }
                case "1":
                    {
                        sResult = "率";
                        break;
                    }
                case "2":
                    {
                        sResult = "单价";
                        break;
                    }
                case "3":
                    {
                        sResult = "总价";
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            return sResult;
        }

        private void Rpt_Customs_OutWarehouseBill_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string DecType = CommonReport.GetDecCodeName(_Store_Out_head.Dec_type);
                xrLabel1.Text = "（" + _Store_Out_head.Lading_type + "） 核扣表--" + DecType + "    复核表";
                //bStore_Out_list.DataSource = _Store_Out_head;
                //条码
                xrBarCode1.Text = _Store_Out_head.Bill_id;
                //出仓单号
                xtcClp_No.Text = _Store_Out_head.Bill_id;
                //出仓日期
                xrLabel_IEDate.Text = _Store_Out_head.Out_date.ToString("yyyy-MM-dd");
                //创建人
                xtcCreate_name.Text = _Store_Out_head.Creater_name;
                //车牌号
                xtcCar_no.Text = _Store_Out_head.Car_no;
                //司机本编号
                xtDriver_no.Text = _Store_Out_head.Driver_no;
                //报关单号
                xtRefer_doc.Text = _Store_Out_head.Refer_doc;
                //客户订单号
                xtClient_no.Text = _Store_Out_head.Client_no;
                //MCC号
                xtMcc_no.Text = _Store_Out_head.Mcc_no;
                //封条
                xtSeal_no.Text = _Store_Out_head.Seal_no;
                //备注
                xtRemark.Text = _Store_Out_head.Remark;
                //备案号
                xtBah.Text = _Store_Out_head.Bah;
                //进出口日期
                xrTableCell_IE_DATE.Text = _Store_Out_head.Ie_date.ToString("yyyy-MM-dd");
                //运输工具
                xtTraf_name.Text = _Store_Out_head.Traf_name;
                //提运单号
                xtTydh.Text = _Store_Out_head.Tydh;
                //许可证号
                xtPermission_no.Text = _Store_Out_head.Permission_no;
                //批准文号
                xtPzwh.Text = _Store_Out_head.Pzwh;
                //合同协议号
                xtHtxyh.Text = _Store_Out_head.Htxyh;
                //
                xtNote_s.Text = _Store_Out_head.Note_s;

                //转关单号
                xrTableCell29.Text = _Store_Out_head.Trans_doc;

                xrTableCell_YUNF.Text = GetToValue(_Store_Out_head.Yunf) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Yunf2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_Out_head.Yunf3);
                //保费3
                xrTableCell_BAOF.Text = GetToValue(_Store_Out_head.Baof) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Baof2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_Out_head.Baof3);
                xrTableCell_ZAF.Text = GetToValue(_Store_Out_head.Zaf) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Zaf2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_Out_head.Zaf3);
                //报关单类型
                xrTableCell91.Text = CommonReport.GetDecCodeName(_Store_Out_head.Dec_type);
                //运输方式 
                xrTableCell_TRAF_MODE.Text = "(" + _Store_Out_head.Traf_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "116", _Store_Out_head.Traf_mode.Trim());
                //贸易方式 
                xrTableCell_TRADE_MODE.Text = "(" + _Store_Out_head.Trade_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "112", _Store_Out_head.Trade_mode.Trim());
                //结汇方式
                xrTableCell_JHFS.Text = "(" + _Store_Out_head.Jhfs_code.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "125", _Store_Out_head.Jhfs_code.Trim());
                //启运国
                xrTableCell_TRADE_COUN.Text = "(" + _Store_Out_head.Trade_coun.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "102", _Store_Out_head.Trade_coun.Trim());
                //装货港
                xrTableCell_TRADE_PORT.Text = "(" + _Store_Out_head.Trade_port.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "100", _Store_Out_head.Trade_port.Trim());
                //境地货源/目的地
                xrTableCell_TRADE_AREA.Text = "(" + _Store_Out_head.Trade_area.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "121", _Store_Out_head.Trade_area.Trim());
                //成交方式 
                xrTableCell_TRANS_MODE.Text = "(" + _Store_Out_head.Trans_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "115", _Store_Out_head.Trans_mode.Trim());

                //经营单位
                xrTableCell_TRADE.Text = "(" + _Store_Out_head.Trade_code + ")" + CommonReport.GetCompanyName(_Store_Out_head.Trade_code.Trim());
                xrTableCell_RS.Text = "(" + _Store_Out_head.Rs_code + ")" + CommonReport.GetCompanyName(_Store_Out_head.Rs_code.Trim());
                //进出口岸
                xrTableCell_IE_PORT.Text = "(" + _Store_Out_head.Ie_port.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "108", _Store_Out_head.Ie_port.Trim());
                //出仓方式
                if (_Store_Out_head.Lading_type.ToString() == "保税")
                {//保税仓出仓方式dtbOutWarehouseWay500  
                    DataRow[] drdtbOutWarehouseWay500 = _dtbOutType500.Select("outtype_id=" + _Store_Out_head.Out_type);
                    xrTableCell65.Text = drdtbOutWarehouseWay500[0]["outtype"].ToString();

                }
                else
                {//监管仓出仓方式dtbOutWarehouseWay001
                    DataRow[] drdtbOutWarehouseWay001 = _dtbInType001.Select("outtype_id=" + _Store_Out_head.Out_type);
                    xrTableCell65.Text = drdtbOutWarehouseWay001[0]["outtype"].ToString();
                }


                //币制
                xrTableCell_CURR.Text = "(" + _Store_Out_head.Curr_code.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, _Store_Out_head.Curr_code.Trim());
                //包装种类
                xrTableCell73.Text = "(" + _Store_Out_head.Bzzl_code.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "133", _Store_Out_head.Bzzl_code.Trim());
                //货物类型
                xrTableCell96.Text = _Store_Out_head.Lading_type;

                xrTableCell_CNTNR.Text = _Store_Out_head.Cntnr_spec;

                xrTableCell_CZQY.Text = GetSIGN_NAME(_dtbEnterprise001, _Store_Out_head.Lease_holder); //仓租企业名称
                xrTableCell_SFDZBH.Text = _Store_Out_head.Sfdz;//随附单证编号
                //生产厂家用途
                xrTableCell_PU_CODE.Text = _Store_Out_head.Pu_name + "/" + GetCodeFromName(_dtbSPBCODES, "117", _Store_Out_head.Pu_code.Trim()); ;
                //证免
                xrTableCell_ZMXZ.Text = GetCodeFromName(_dtbSPBCODES, "119", _Store_Out_head.Zmxz_code.Trim());

                xrPkgs_num.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Pkgs_num.ToString());
                xrGross_Wt.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Gross_wt.ToString());
                xrNet_wt.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.Net_wt.ToString());
                xrAll_value.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_Out_head.All_value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在参数表中根据名字得到代码
        /// </summary>
        /// <param name="iPCCODE"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        private string GetSIGN_NAME(DataTable tab, string SIGN_ID)
        {
            foreach (DataRow drw in tab.Rows)
            {
                if (drw["SIGN_ID"].ToString() == SIGN_ID)
                {
                    return drw["SIGN_NAME"].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 获取CName
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="cCode"></param>
        /// <returns></returns>
        private string GetCName(DataTable tab, string cCode)
        {
            if (tab == null || tab.Rows.Count <= 0)
            {
                return string.Empty;
            }
            foreach (DataRow dr in tab.Rows)
            {
                if (dr["INTYPE_ID"].ToString() == cCode)
                {
                    return dr["INTYPE"].ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 在参数表中根据名字得到代码
        /// </summary>
        /// <param name="iPCCODE"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        private string GetCodeFromName(DataTable tab, string iPCCODE, string cCODE)
        {
            DataRow[] drwTemp = tab.Select("PCCODE = " + iPCCODE, "CCODE");
            foreach (DataRow drw in drwTemp)
            {
                if (drw["ccode"].ToString() == cCODE)
                {
                    return drw["CNAME"].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 在参数表中根据名字得到代码
        /// </summary>
        /// <param name="iPCCODE"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        private string GetCodeFromName(DataTable tab, string cCODE)
        {
            DataRow[] drwTemp = tab.Select("PCCODE = 118", "CCODE");
            foreach (DataRow drw in drwTemp)
            {
                if (drw["ccode"].ToString() == cCODE)
                {
                    return drw["ENAME"].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 获取商品规格
        /// </summary>
        /// <param name="dt">表格</param>
        /// <param name="dr">当前行</param>
        /// <returns></returns>
        private string GetStrSpec(DataTable dt, string CODE_T, string MG_SPEC)
        {
            string str = "";
            DataRow[] drs = dt.Select("CODE_TS='" + CODE_T + "'", "YS_NO asc");
            string[] listSpec = MG_SPEC.ToString().Trim().Split('|');
            for (int i = 0; i < drs.Length; i++)
            {

                str += GetStrDel(drs[i]["YS_CONTENT"].ToString()) + "：";
                if (listSpec.Length > i)
                {
                    if (listSpec[i] != null)
                    {
                        str += listSpec[i];
                    }
                }
                str += "\r\n";
            }
            if (drs.Length < listSpec.Length)
            {
                for (int i = drs.Length; i < listSpec.Length; i++)
                {
                    if (listSpec[i] != null)
                    {
                        str += listSpec[i];
                    }
                }
            }
            return str;
        }

        public string GetStrDel(string str)
        {
            str = str.Replace('（', '(');
            str = str.Replace('）', ')');
            if (str.Contains("(") && str.Contains(")"))
            {
                return str.Substring(0, str.IndexOf('(')) + str.Substring(str.IndexOf(')') + 1);
            }
            else
            {
                return str;
            }
        }

    }
}
