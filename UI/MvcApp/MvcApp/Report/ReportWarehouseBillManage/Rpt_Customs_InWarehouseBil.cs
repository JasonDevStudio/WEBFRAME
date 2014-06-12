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
    public partial class Rpt_Customs_InWarehouseBil : DevExpress.XtraReports.UI.XtraReport
    {
        /// <summary>
        /// 表头数据
        /// </summary>
        private Customs.Entity.Store_in_headInfo _Store_in_head;
        /// <summary>
        /// 明细数据
        /// </summary>
        private DataTable _Store_in_lists;
        /// <summary>
        /// 编码
        /// </summary>
        private DataTable _dtbSPBCODES;
        /// <summary>
        /// 入仓方式
        /// </summary>
        private DataTable _dtbEnterprise001 = new DataTable();     //监管仓仓租企业
        private DataTable _dtbInType001 = new DataTable();        //监管仓入仓方式

        private DataTable _c_complexys = null;


        public Rpt_Customs_InWarehouseBil(Customs.Entity.Store_in_headInfo Store_in_head, DataTable Store_in_lists,

            DataTable dtbSPBCODES, DataTable dtbEnterprise001, DataTable dtbInType001,DataTable c_complexys)
        {
            InitializeComponent();
            this._Store_in_head = Store_in_head;
            this._Store_in_lists = Store_in_lists;
            this._dtbSPBCODES = dtbSPBCODES;
            this._dtbEnterprise001 = dtbEnterprise001;
            this._dtbInType001 = dtbInType001;
       
            DetailReport.DataSource = Store_in_lists;

            _c_complexys = c_complexys;
        }

        private int i = 0;
        /// <summary>
        /// 打印之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rpt_Customs_InWarehouseBil_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            try
            {
                
                String DecType = CommonReport.GetDecCodeName(_Store_in_head.Dec_type);
                xrLabel1.Text = "（" + _Store_in_head.Lading_type + "） 核增表--" + DecType + "    复核表";

                bStore_in_list.DataSource = _Store_in_head;
             
                xrTableCell_TAX_FLAG.Text = _Store_in_head.Tax_flag.Trim() == "1" ? "是" : (_Store_in_head.Tax_flag.Trim() == "0" ? "否" : "");//退税标志xrTableCell_SFDZBH
                xrTableCell_YUNF.Text = GetToValue(_Store_in_head.Yunf) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Yunf2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_in_head.Yunf3);
                //保费3
                xrTableCell_BAOF.Text = GetToValue(_Store_in_head.Baof) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Baof2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_in_head.Baof3);
                xrTableCell_ZAF.Text = GetToValue(_Store_in_head.Zaf) + "/" + ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Zaf2.ToString()) + "/" + GetCodeFromName(_dtbSPBCODES, _Store_in_head.Zaf3);
                //报关单类型
                xrTableCell10.Text = DecType;
                //运输方式 
                xrTableCell_TRAF_MODE.Text = "(" + _Store_in_head.Traf_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "116", _Store_in_head.Traf_mode.Trim());
                //贸易方式 
                xrTableCell_TRADE_MODE.Text = "(" + _Store_in_head.Trade_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "112", _Store_in_head.Trade_mode.Trim());
                //结汇方式
                xrTableCell_JHFS.Text ="("+ _Store_in_head.Jhfs_code.Trim()+")"+ GetCodeFromName(_dtbSPBCODES, "125", _Store_in_head.Jhfs_code.Trim());
                //启运国
                xrTableCell_TRADE_COUN.Text = "(" + _Store_in_head.Trade_coun.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "102", _Store_in_head.Trade_coun.Trim());
                //装货港
                xrTableCell_TRADE_PORT.Text = "(" + _Store_in_head.Trade_port.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "100", _Store_in_head.Trade_port.Trim());
                //境地货源/目的地
                xrTableCell_TRADE_AREA.Text = "(" + _Store_in_head.Trade_area.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "121", _Store_in_head.Trade_area.Trim());

                //经营单位
                xrTableCell_TRADE.Text = "(" + _Store_in_head.Trade_code + ")" + CommonReport.GetCompanyName(_Store_in_head.Trade_code.Trim());
                xrTableCell_RS.Text = "(" + _Store_in_head.Rs_code + ")" + CommonReport.GetCompanyName(_Store_in_head.Rs_code.Trim());
                //进出口岸
                xrTableCell_IE_PORT.Text = "(" + _Store_in_head.Ie_port.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "108", _Store_in_head.Ie_port.Trim());
                //入仓方式
                xrTableCell93.Text = GetCName(_dtbInType001, _Store_in_head.In_type.Trim());
                //币制
                xrTableCell_CURR.Text = GetCodeFromName(_dtbSPBCODES, _Store_in_head.Curr_code.Trim());
                //
                xrTableCell_CNTNR.Text = _Store_in_head.Cntnr_spec;

                xrTableCell_CZQY.Text =GetSIGN_NAME(_dtbEnterprise001,_Store_in_head.Lease_holder); //仓租企业名称
                //货物类型
                xrTableCell57.Text = _Store_in_head.Lading_type;

                xrTableCell_SFDZBH.Text = _Store_in_head.Sfdz; ;//随附单证编号

                //征免性质
                xrTableCell_ZMXZ.Text = "(" + _Store_in_head.Zmxz_code.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "119", _Store_in_head.Zmxz_code.Trim());
                //成交方式
                xrTableCell_TRANS_MODE.Text = "(" + _Store_in_head.Trans_mode.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "115", _Store_in_head.Trans_mode.Trim());
                //生产厂家及用途
                xrTableCell_PU_CODE.Text = _Store_in_head.Pu_name + "/" + GetCodeFromName(_dtbSPBCODES, "117", _Store_in_head.Pu_code.Trim()); ;
                //包装种类
                xrTableCell99.Text = "(" + _Store_in_head.Bzzl_code.Trim() + ")" + GetCodeFromName(_dtbSPBCODES, "133", _Store_in_head.Bzzl_code.Trim());
                xrPkgs_num.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Pkgs_num.ToString());
                xrGross_Wt.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Gross_wt.ToString());
                xrNet_wt.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.Net_wt.ToString());
                xrAll_value.Text = ILIMS.Common.PublicMethod.RemoveZero(_Store_in_head.All_value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
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
            if (string.IsNullOrEmpty(cCODE))
            {
                return string.Empty;
            }
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
        /// 明细打印之前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_Store_in_lists == null || _Store_in_lists.Rows.Count <= 0)
            {
                return;
            }

            DataRow dr = _Store_in_lists.Rows[i];
            string strspbcomplexy = GetStrSpec(_c_complexys,dr["Code_t"].ToString(), dr["Mg_spec"].ToString());
            xrTableCell_Name.Text = dr["Mg_name"].ToString().Trim() + "\r\n";
            xrTableCell_Name.Text += string.IsNullOrEmpty(strspbcomplexy) ? dr["Mg_spec"].ToString().Trim() : strspbcomplexy;
            xrTableCell_QTY.Text =ILIMS.Common.PublicMethod.RemoveZero(dr["QTY_1"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES,"111",dr["UNIT_CODE1"].ToString().Trim());

            if (!string.IsNullOrEmpty(dr["UNIT_CODE2"].ToString()))
            {
                if (decimal.Parse(dr["QTY_2"].ToString().Trim()) == 0)
                {
                    xrTableCell_QTY.Text += "\r\n" + "     "  +GetCodeFromName(_dtbSPBCODES, "111", dr["UNIT_CODE2"].ToString().Trim()); ;
                }
                else
                {

                    xrTableCell_QTY.Text += "\r\n" + "     " + ILIMS.Common.PublicMethod.RemoveZero(dr["QTY_2"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES, "111", dr["UNIT_CODE2"].ToString().Trim());
                }
            }
            else
            {
                xrTableCell_QTY.Text += "\r\n";
            }

            xrTableCell_QTY.Text += "\r\n"  +ILIMS.Common.PublicMethod.RemoveZero(dr["G_QTY"].ToString().Trim()) + " " + GetCodeFromName(_dtbSPBCODES, "111", dr["G_UNIT"].ToString().Trim()); 

            xrTableCell_Weight.Text = "\r\n"+ ILIMS.Common.PublicMethod.RemoveZero(dr["GROSS"].ToString().Trim()) + "\r\n" +  ILIMS.Common.PublicMethod.RemoveZero(dr["NET"].ToString().Trim()) + "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["PKGS"].ToString().Trim())+"件"+ "\r\n" +"PCS:"+ dr["PCS"].ToString().Trim();
            xrTableCell_NO.Text = dr["G_NO"].ToString().Trim() + "\r\n" + GetCodeFromName(_dtbSPBCODES, "103", dr["Zm_code"].ToString());
            if (!string.IsNullOrEmpty(dr["BAXH"].ToString()))
            {
                xrTableCell_NO.Text += "\r\n" + "(" + dr["BAXH"].ToString().Trim() + ")";
            }
            //xrTableCell_Total.Text = dr["UNIT_PRICE"].ToString().Trim() + "\r\n" +Math.Round (decimal.Parse(dr["TRADE_TTL"].ToString().Trim()),2).ToString() + "\r\n" + dr["CURR_NAME"].ToString().Trim()+"\r\n"+
            //    "美元单价：" + dr["USD_UNIT_PRICE"].ToString().Trim() + "\r\n" + "美元总价：" + Math.Round(decimal.Parse(dr["USD_TRADE_TTL"].ToString().Trim()), 2).ToString();//单价总价币制
            if (!string.IsNullOrEmpty(dr["Curr_code"].ToString()))
            {
                xrTableCell_Total.Text = "\r\n" + ILIMS.Common.PublicMethod.RemoveZero(dr["UNIT_PRICE"].ToString().Trim()) + "  " + ILIMS.Common.PublicMethod.RemoveZero(Math.Round(decimal.Parse(dr["TRADE_TTL"].ToString().Trim()), 2).ToString()) + " " + GetCodeFromName(_dtbSPBCODES, dr["Curr_code"].ToString()); //单价总价币制
            }
            else
            {
                xrTableCell_Total.Text = "\r\n" + dr["UNIT_PRICE"].ToString().Trim() + "  " + Math.Round(decimal.Parse(dr["TRADE_TTL"].ToString().Trim()), 2).ToString() + " " + GetCodeFromName(_dtbSPBCODES, "103", _Store_in_head.Zmxz_code);
            }

            string codet = dr["Code_t"]== null ? "" : dr["Code_t"].ToString();
            xrTableCell_Code.Text = codet.Length > 2 ? codet.Insert(codet.Length - 2, ".") : codet; //商品编号
            if (dr["ORIGN_COUN"].ToString().Trim().Length > 0)
            {
                xrTableCell_cou.Text = GetCodeFromName(_dtbSPBCODES, "102", dr["ORIGN_COUN"].ToString().Trim()) + "\r\n" + "(" + dr["ORIGN_COUN"].ToString().Trim() + ")";//原产国
            }
            else
            {
                xrTableCell_cou.Text = "";
            }
        

            i++;

            // 控制每页报表显示的条数
            if (_Store_in_head.Lading_type == "MCC" && _Store_in_lists.Rows.Count > 20)
            {
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
            if (CODE_T==null||CODE_T=="")
            {
                return str;
            }
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

        private void xrTableCell_CNTNR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
