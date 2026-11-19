using DevExpress.Data.Linq.Helpers;
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
    public class BasHerbCdService : BaseService
    {        
        internal MTSCollection<BHERBCDMODEL> FindList()
        {
            MTSCollection<BHERBCDMODEL> list = new MTSCollection<BHERBCDMODEL>();

            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();                          
                    string strSQL = string.Empty;                                        
                    strSQL += "SELECT a.HerbCd                                  ";
                    strSQL += "	    , a.AplFrDate                               ";
                    strSQL += "     , a.AplToDate                               ";
                    strSQL += "     , a.HerbNm                                  ";
                    strSQL += "     , a.Company                                 ";
                    strSQL += "  FROM pam.wb_bherbcd a                          ";
                    strSQL += "INNER JOIN(SELECT HerbCd                         ";
                    strSQL += "                , MAX(AplFrDate) AplFrDate       ";             
                    strSQL += "             FROM pam.wb_bherbcd                 ";
                    strSQL += "            WHERE 1 = 1                          ";
                    strSQL += "            GROUP BY HerbCd) b                   ";
                    strSQL += "   ON a.HerbCd = b.HerbCd                        ";
                    strSQL += "  AND a.AplFrDate = b.AplFrDate                  ";
                    strSQL += " WHERE 1 = 1                                     ";
                    strSQL += "ORDER BY a.HerbCd                                ";

                    MySqlCommand command = new MySqlCommand(strSQL, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    list.Clear();
                    while (table.Read())
                    {
                        BHERBCDMODEL item = new BHERBCDMODEL();
                        item.HerbCd = table["HerbCd"].ToString();
                        item.AplFrDate = table["AplFrDate"].ToString();
                        item.AplToDate = table["AplToDate"].ToString();
                        item.HerbNm = table["HerbNm"].ToString();                        
                        item.Company = table["Company"].ToString();
                        
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

        internal bool SaveData(BHERBCDMODEL param)
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

                    DateTime dtpFrDate = param.AplFrDate.FormatStrToDate("D").To<DateTime>();
                    if (param.AplDate != param.AplFrDate)
                    {
                        if (param.AplDate.NotEmpty())
                        {
                            #region // UPDATE
                            strSQL = string.Empty;
                            strSQL += "UPDATE pam.wb_bherbcd";
                            strSQL += "   SET AplToDate = '" + dtpFrDate.AddDays(-1).ToString("yyyyMMdd") + "'";                            
                            strSQL += " WHERE 1=1";
                            strSQL += "   AND HerbCd = '" + param.HerbCd + "'";
                            strSQL += "   AND AplFrDate = " + param.AplDate;
                            command.CommandText = strSQL;
                            command.ExecuteNonQuery();
                            #endregion

                            #region // INSERT
                            strSQL = string.Empty;
                            strSQL += "INSERT INTO pam.wb_bherbcd           ";
                            strSQL += "(                                    ";
                            strSQL += "       HerbCd                        ";
                            strSQL += "     , AplFrDate                     ";
                            strSQL += "     , AplToDate                     ";
                            strSQL += "     , HerbNm                        ";
                            strSQL += "     , BasAmt                        ";
                            strSQL += "     , Company                       ";
                            strSQL += "     , Ingredient                    ";
                            strSQL += "     , TotalQty                      ";
                            strSQL += "     , Qty                           ";
                            strSQL += "     , Cnt                           ";
                            strSQL += "     , RegDate                       ";
                            strSQL += "     , RegTime                       ";
                            strSQL += "     , ModifyDate                    ";
                            strSQL += "     , ModifyTime                    ";
                            strSQL += ") VALUES (                           ";
                            strSQL += "     '" + param.HerbCd + "'          ";                            
                            strSQL += "   , '" + param.AplFrDate + "'       ";
                            strSQL += "   , '" + param.AplToDate + "'       ";
                            strSQL += "   , '" + param.HerbNm + "'          ";
                            strSQL += "   , " + param.BasAmt;
                            strSQL += "   , '" + param.Company + "'         ";
                            strSQL += "   , '" + param.Ingredient + "'      ";
                            strSQL += "   , " + param.TotalQty;
                            strSQL += "   , " + param.Qty;
                            strSQL += "   , " + param.Cnt;
                            strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'      ";
                            strSQL += "   , '" + dtm.ToString("HHmmss") + "'        ";
                            strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'      ";
                            strSQL += "   , '" + dtm.ToString("HHmmss") + "'        ";
                            strSQL += ")                                    ";
                            command.CommandText = strSQL;
                            command.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region // INSERT
                            strSQL += "INSERT INTO pam.wb_bherbcd           ";
                            strSQL += "(                                    ";
                            strSQL += "       HerbCd                        ";
                            strSQL += "     , AplFrDate                     ";
                            strSQL += "     , AplToDate                     ";
                            strSQL += "     , HerbNm                        ";
                            strSQL += "     , BasAmt                        ";
                            strSQL += "     , Company                       ";
                            strSQL += "     , Ingredient                    ";
                            strSQL += "     , TotalQty                      ";
                            strSQL += "     , Qty                           ";
                            strSQL += "     , Cnt                           ";
                            strSQL += "     , RegDate                       ";
                            strSQL += "     , RegTime                       ";
                            strSQL += "     , ModifyDate                    ";
                            strSQL += "     , ModifyTime                    ";
                            strSQL += ") VALUES (                           ";
                            strSQL += "     '" + param.HerbCd + "'          ";
                            strSQL += "   , '" + param.AplFrDate + "'       ";
                            strSQL += "   , '" + param.AplToDate + "'       ";
                            strSQL += "   , '" + param.HerbNm + "'          ";
                            strSQL += "   , " + param.BasAmt;
                            strSQL += "   , '" + param.Company + "'         ";
                            strSQL += "   , '" + param.Ingredient + "'      ";
                            strSQL += "   , " + param.TotalQty;
                            strSQL += "   , " + param.Qty;
                            strSQL += "   , " + param.Cnt;
                            strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'      ";
                            strSQL += "   , '" + dtm.ToString("HHmmss") + "'        ";
                            strSQL += "   , '" + dtm.ToString("yyyyMMdd") + "'      ";
                            strSQL += "   , '" + dtm.ToString("HHmmss") + "'        ";
                            strSQL += ")                                    ";
                            command.CommandText = strSQL;
                            command.ExecuteNonQuery();
                            #endregion
                        }
                    }
                    else 
                    {
                        #region // UPDATE
                        strSQL = string.Empty;
                        strSQL += "UPDATE pam.wb_bherbcd                                ";
                        strSQL += "   SET AplToDate     = '" + param.AplToDate + "'     ";
                        strSQL += "     , HerbNm        = '" + param.HerbNm + "'        ";
                        strSQL += "     , BasAmt           " + param.BasAmt;
                        strSQL += "     , Company       = '" + param.Company + "'       ";
                        strSQL += "     , Ingredient    = '" + param.Ingredient + "'    ";
                        strSQL += "     , TotalQty      =  " + param.TotalQty;
                        strSQL += "     , Qty           =  " + param.Qty;
                        strSQL += "     , Cnt           =  " + param.Cnt;                
                        strSQL += "     , ModifyDate    = '" + dtm.ToString("yyyyMMdd") + "'      ";
                        strSQL += "     , ModifyTime    = '" + dtm.ToString("HHmmss") + "'        ";
                        strSQL += " WHERE 1=1";
                        strSQL += "   AND HerbCd = '" + param.HerbCd + "'";
                        strSQL += "   AND AplFrDate = " + param.AplDate;
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

        internal bool DeleteData(BHERBCDMODEL param)
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

                    #region // DELETE
                    strSQL = string.Empty;
                    strSQL += "DELETE FROM pam.wb_bherbcd";                    
                    strSQL += " WHERE 1=1";
                    strSQL += "   AND HerbCd = '" + param.HerbCd + "'";
                    strSQL += "   AND AplFrDate = " + param.AplDate;
                    command.CommandText = strSQL;
                    command.ExecuteNonQuery();
                    #endregion

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

        internal MTSCollection<COMBODTO> FindAplData(BHERBCDMODEL selectedRow)
        {
            MTSCollection<COMBODTO> list = new MTSCollection<COMBODTO>();

            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string strSQL = string.Empty;
                    strSQL += "SELECT HerbCd                                ";
                    strSQL += "     , AplFrDate                             ";
                    strSQL += "     , AplToDate                             ";
                    strSQL += "     , HerbNm                                ";                    
                    strSQL += "  FROM pam.wb_bherbcd                        ";
                    strSQL += " WHERE 1 = 1                                 ";
                    strSQL += "   AND HerbCd = '" + selectedRow.HerbCd + "' ";
                    strSQL += " ORDER BY AplFrDate DESC                     ";

                    MySqlCommand command = new MySqlCommand(strSQL, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    list.Clear();
                    while (table.Read())
                    {
                        COMBODTO item = new COMBODTO();
                        item.DISPLAYMEMBER = table["AplFrDate"].ToString();
                        item.VALUEMEMBER = table["AplFrDate"].ToString();
                        
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

        internal BHERBCDMODEL FindData(string herbCd, string aplDate)
        {            
            BHERBCDMODEL item = new BHERBCDMODEL();
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
                {
                    mysql.Open();
                    string strSQL = string.Empty;
                    strSQL += "SELECT HerbCd                                ";
                    strSQL += "     , AplFrDate                             ";
                    strSQL += "     , AplToDate                             ";
                    strSQL += "     , AplFrDate as AplDate                  ";
                    strSQL += "     , HerbNm                                ";
                    strSQL += "     , BasAmt                                ";
                    strSQL += "     , Company                               ";
                    strSQL += "     , Ingredient                            ";
                    strSQL += "     , TotalQty                              ";
                    strSQL += "     , Qty                                   ";
                    strSQL += "     , Cnt                                   ";
                    strSQL += "     , RegDate                               ";
                    strSQL += "     , RegTime                               ";
                    strSQL += "     , ModifyDate                            ";
                    strSQL += "     , ModifyTime                            ";
                    strSQL += "  FROM pam.wb_bherbcd                        ";
                    strSQL += " WHERE 1 = 1                                 ";
                    strSQL += "   AND HerbCd    = '" + herbCd + "'          ";
                    strSQL += "   AND AplFrDate = '" + aplDate + "'         ";
                    
                    MySqlCommand command = new MySqlCommand(strSQL, mysql);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        item.HerbCd = table["HerbCd"].ToString();
                        item.AplFrDate = table["AplFrDate"].ToString();
                        item.AplToDate = table["AplToDate"].ToString();
                        item.AplDate = table["AplDate"].ToString();
                        item.HerbNm = table["HerbNm"].ToString();
                        item.BasAmt = table["BasAmt"].To<long>(0);
                        item.Company = table["Company"].ToString();
                        item.Ingredient = table["Ingredient"].ToString();
                        item.TotalQty = table["TotalQty"].To<long>(0);
                        item.Qty = table["Qty"].To<long>(0);
                        item.Cnt = table["Cnt"].To<long>(0);
                    }

                    table.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            return item;
        }
    }
}
