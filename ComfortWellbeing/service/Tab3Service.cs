using ComfortWellbeing.model;
using Mentorsoft.Winform.Framework.Core.DTO;
using Mentorsoft.Winform.Framework.Core.Extension;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing
{
    public class Tab3Service : BaseService
    {
        internal bool SaveData(PatientDto patInfo,SEARCHDTO param, MTSCollection<OrderModel> orderList, PayModel payInfo)
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
                    strSQL += ") VALUES (";
                    strSQL += "      " + RcpNo_Seq;
                    strSQL += "   , '" + dtm.ToString("yyyyMMdd") +"'"; // RcpDate
                    strSQL += "   , '" + patInfo.PtNo + "'";    // PtNo
                    strSQL += "   , '" + param.OrderDate + "'";
                    strSQL += "   ,  " + payInfo.CalcAmt;
                    strSQL += "   ,  " + payInfo.MinusAmt;
                    strSQL += "   ,  " + payInfo.CardAmt;
                    strSQL += "   ,  " + payInfo.CashAmt;
                    strSQL += "   ,  " + payInfo.OnLineAmt;
                    strSQL += "   , '" + "0" + "'";
                    strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'";
                    strSQL += "   , '" + dtm.ToString("HHmmss") + "'";
                    strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'";
                    strSQL += "   , '" + dtm.ToString("HHmmss") + "'";
                    strSQL += ")";                    
                    command.CommandText = strSQL;
                    command.ExecuteNonQuery();
                    #endregion

                    foreach (var item in orderList)
                    {
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
                        strSQL += ") VALUES (";
                        strSQL += "      " + RcpNo_Seq;
                        strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'"; // RcpDate
                        strSQL += "   , '" + patInfo.PtNo + "'";    // PtNo
                        strSQL += "   , '" + param.OrderDate + "'";
                        strSQL += "   , '" + item.HerbCd + "'";
                        strSQL += "   ,  " + item.BasAmt;
                        strSQL += "   ,  " + item.Qty;
                        strSQL += "   ,  " + item.CalcAmt;
                        strSQL += "   , '" + item.FREEYN + "'";
                        strSQL += "   , '" + "0" + "'";
                        strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'";
                        strSQL += "   , '" + dtm.ToString("HHmmss") + "'";
                        strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'";
                        strSQL += "   , '" + dtm.ToString("HHmmss") + "'";
                        strSQL += ")";
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
