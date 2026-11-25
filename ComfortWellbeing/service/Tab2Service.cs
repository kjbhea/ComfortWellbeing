using ComfortWellbeing.model;
using DevExpress.XtraPrinting;
using Mentorsoft.Winform.Framework.Core.DTO;
using Mentorsoft.Winform.Framework.Core.Extension;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing
{
    public class Tab2Service : BaseService
    {
        internal MTSCollection<AARCPDTO> FindAARCPList(PatientDto dto)
        {
            MTSCollection<AARCPDTO> list = new MTSCollection<AARCPDTO>();

            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string strSQL = string.Empty;
                    strSQL += "SELECT a.RcpNo                                   ";
                    strSQL += "     , a.RcpDate                                 ";
                    strSQL += "     , a.PtNo                                    ";
                    strSQL += "     , a.OrdDate                                 ";
                    strSQL += "     , a.CalcAmt                                 ";
                    strSQL += "     , a.MinusAmt                                ";
                    strSQL += "     , a.CardAmt                                 ";
                    strSQL += "     , a.CashAmt                                 ";
                    strSQL += "     , a.OnlineAmt                               ";
                    strSQL += "     , a.StsCls                                  ";
                    strSQL += "     , a.RegDate                                 ";
                    strSQL += "     , a.RegTime                                 ";
                    strSQL += "     , a.ModifyDate                              ";
                    strSQL += "     , a.ModifyTime                              ";
                    strSQL += "  FROM pam.wb_aarcp a                            ";
                    strSQL += " WHERE 1 = 1                                     ";
                    strSQL += "   AND a.PtNo = '" + dto.PtNo +"'";
                    strSQL += "ORDER BY a.RcpNo Desc                          ";

                    MySqlCommand command = new MySqlCommand(strSQL, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    list.Clear();
                    while (table.Read())
                    {
                        AARCPDTO item = new AARCPDTO 
                        {
                            RcpNo = table["RcpNo"].To<long>(0),
                            RcpDate = table["RcpDate"].ToString(),
                            PtNo = table["PtNo"].ToString(),
                            OrdDate = table["OrdDate"].ToString(),
                            CalcAmt = table["CalcAmt"].To<long>(0),
                            MinusAmt = table["MinusAmt"].To<long>(0),
                            CardAmt = table["CardAmt"].To<long>(0),
                            CashAmt = table["CashAmt"].To<long>(0),
                            OnLineAmt = table["OnlineAmt"].To<long>(0),
                            StsCls = table["StsCls"].ToString(),
                            RegDate = table["RegDate"].ToString(),
                            RegTime = table["RegTime"].ToString(),
                            ModifyDate = table["ModifyDate"].ToString(),
                            ModifyTime = table["ModifyTime"].ToString(),
                        };

                        list.Add(item);
                    }

                    table.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            return list;
        }

        internal MTSCollection<OrderModel> FindAAORDList(AARCPDTO dto)
        {
            MTSCollection<OrderModel> list = new MTSCollection<OrderModel>();

            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string strSQL = string.Empty;
                    strSQL += "SELECT a.RcpNo                                   ";
                    strSQL += "     , a.RcpDate                                 ";
                    strSQL += "     , a.PtNo                                    ";
                    strSQL += "     , a.OrdDate                                 ";
                    strSQL += "     , a.HerbCd                                  ";
                    strSQL += "     , b.HerbNm                                  ";
                    strSQL += "     , a.BasAmt                                  ";
                    strSQL += "     , a.Qty                                     ";
                    strSQL += "     , a.CalcAmt                                 ";
                    strSQL += "     , a.FreeYn                                  ";
                    strSQL += "     , a.StsCls                                  ";
                    strSQL += "     , a.RegDate                                 ";
                    strSQL += "     , a.RegTime                                 ";
                    strSQL += "     , a.ModifyDate                              ";
                    strSQL += "     , a.ModifyTime                              ";
                    strSQL += "  FROM pam.wb_aaord a                            ";
                    strSQL += " INNER JOIN pam.wb_bherbcd b                     ";
                    strSQL += "    ON a.HerbCd = b.HerbCd                       ";
                    strSQL += "   AND a.OrdDate BETWEEN b.aplFrDate AND b.AplToDate";
                    strSQL += " WHERE 1 = 1                                     ";
                    strSQL += "   AND a.RcpNo = '" + dto.RcpNo + "'";
                    //strSQL += "ORDER BY a.RcpDate Desc                          ";

                    MySqlCommand command = new MySqlCommand(strSQL, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    list.Clear();
                    while (table.Read())
                    {
                        OrderModel item = new OrderModel
                        {
                            RcpNo = table["RcpNo"].To<long>(0),
                            RcpDate = table["RcpDate"].ToString(),
                            PtNo = table["PtNo"].ToString(),
                            OrdDate = table["OrdDate"].ToString(),
                            HerbCd = table["HerbCd"].ToString(),
                            HerbNm = table["HerbNm"].ToString(),
                            BasAmt = table["BasAmt"].To<long>(0),
                            Qty = table["Qty"].To<long>(0),
                            CalcAmt = table["CalcAmt"].To<long>(0),
                            FREEYN = table["FreeYn"].ToString(),
                            StsCls = table["StsCls"].ToString(),
                            RegDate = table["RegDate"].ToString(),
                            RegTime = table["RegTime"].ToString(),
                            ModifyDate = table["ModifyDate"].ToString(),
                            ModifyTime = table["ModifyTime"].ToString(),
                        };

                        list.Add(item);
                    }

                    table.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            return list;
        }

        internal bool DeleteData(List<AARCPDTO> list)
        {
            string strSQL = string.Empty;
            DateTime dtm = DateTime.Now;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionAddress))
                {
                    conn.Open();

                    MySqlCommand command = conn.CreateCommand();
                    MySqlTransaction myTrans = conn.BeginTransaction(); // 트랜잭션 시작

                    command.Connection = conn;
                    command.Transaction = myTrans;

                    foreach (AARCPDTO item in list)
                    {                        
                        #region // SELECT  AARCP_SEQ
                        long RcpNo_Seq = 0;

                        strSQL = string.Empty;
                        strSQL += "SELECT wb_nextval('AARCP_SEQ') AS SEQ";

                        command.CommandText = strSQL;
                        MySqlDataReader table = command.ExecuteReader();

                        while (table.Read())
                        {
                            RcpNo_Seq = table["SEQ"].To<long>(0);
                        }

                        table.Close();
                        #endregion

                        #region // INSERT AARCP                    
                        strSQL = string.Empty;
                        strSQL += "INSERT INTO pam.wb_aarcp";
                        strSQL += "(";
                        strSQL += "     RcpNo";
                        strSQL += "   , RcpDate";
                        strSQL += "   , PtNo";
                        strSQL += "   , OrdDate";
                        strSQL += "   , CalcAmt";
                        strSQL += "   , MinusAmt";
                        strSQL += "   , CardAmt";
                        strSQL += "   , CashAmt";
                        strSQL += "   , OnLineAmt";
                        strSQL += "   , StsCls";
                        strSQL += "   , RegDate";
                        strSQL += "   , RegTime";
                        strSQL += "   , ModifyDate";
                        strSQL += "   , ModifyTime";
                        strSQL += ")";
                        strSQL += "SELECT  " + RcpNo_Seq + " AS RcpNo";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS RcpDate";
                        strSQL += "     , PtNo";
                        strSQL += "     , OrdDate";
                        strSQL += "     , CalcAmt * -1";
                        strSQL += "     , MinusAmt * -1";
                        strSQL += "     , CardAmt * -1";
                        strSQL += "     , CashAmt * -1";
                        strSQL += "     , OnLineAmt * -1";
                        strSQL += "     , '1' AS StsCls";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS RegDate";
                        strSQL += "     , '" + dtm.ToString("HHmmss") + "' AS RegTime";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS ModifyDate";
                        strSQL += "     , '" + dtm.ToString("HHmmss") + "' AS ModifyTime";
                        strSQL += "  FROM pam.wb_aarcp";
                        strSQL += " WHERE 1=1           ";
                        strSQL += "   AND RcpNo = " + item.RcpNo;

                        command.CommandText = strSQL;
                        command.ExecuteNonQuery();
                        #endregion

                        #region // INSERT AAORD
                        strSQL = string.Empty;
                        strSQL += "INSERT INTO pam.wb_aaord";
                        strSQL += "(";
                        strSQL += "     RcpNo";
                        strSQL += "   , RcpDate";
                        strSQL += "   , PtNo";
                        strSQL += "   , OrdDate";
                        strSQL += "   , HerbCd";
                        strSQL += "   , BasAmt";
                        strSQL += "   , Qty";
                        strSQL += "   , CalcAmt";
                        strSQL += "   , FreeYn";
                        strSQL += "   , StsCls";
                        strSQL += "   , RegDate";
                        strSQL += "   , RegTime";
                        strSQL += "   , ModifyDate";
                        strSQL += "   , ModifyTime";
                        strSQL += ")";
                        strSQL += "SELECT  " + RcpNo_Seq + " AS RcpNo";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS RcpDate";
                        strSQL += "     , PtNo";
                        strSQL += "     , OrdDate";
                        strSQL += "     , HerbCd";
                        strSQL += "     , BasAmt";
                        strSQL += "     , Qty * -1";
                        strSQL += "     , CalcAmt * -1";
                        strSQL += "     , FreeYn";
                        strSQL += "     , '" + "1" + "'";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS RegDate";
                        strSQL += "     , '" + dtm.ToString("HHmmss") + "' AS RegTime";
                        strSQL += "     , '" + dtm.ToString("yyyyMMdd") + "' AS ModifyDate";
                        strSQL += "     , '" + dtm.ToString("HHmmss") + "' AS ModifyTime";
                        strSQL += "  FROM pam.wb_aaord";
                        strSQL += " WHERE 1=1           ";
                        strSQL += "   AND RcpNo = " + item.RcpNo;

                        command.CommandText = strSQL;
                        command.ExecuteNonQuery();
                        #endregion

                        #region // UPDATE CANCEL AARCP 
                        strSQL = string.Empty;
                        strSQL += "UPDATE pam.wb_aarcp  ";
                        strSQL += "   SET StsCls = '1'  ";
                        strSQL += "     , ModifyDate = '" + dtm.ToString("yyyyMMdd") + "'";
                        strSQL += "     , ModifyTime = '" + dtm.ToString("HHmmss") + "'";
                        strSQL += " WHERE 1=1           ";
                        strSQL += "   AND RcpNo = " + item.RcpNo;
                        command.CommandText = strSQL;
                        command.ExecuteNonQuery();
                        #endregion
                    }

                    myTrans.Commit(); // 트랜잭션 끝
                    conn.Close();
                }

                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
        }
    }
}
