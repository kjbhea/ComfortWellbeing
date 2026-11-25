using Mentorsoft.Winform.Framework.Core.DTO;
using Mentorsoft.Winform.Framework.Core.Extension;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing
{
    public class SetCodeService : BaseService
    {
        internal MTSCollection<SetCdModel> FindList()
        {
            MTSCollection<SetCdModel> list = new MTSCollection<SetCdModel>();

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
                    strSQL += "     , a.BasAmt                                  ";
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
                        SetCdModel item = new SetCdModel();
                        item.HerbCd = table["HerbCd"].ToString();
                        item.AplFrDate = table["AplFrDate"].ToString();
                        item.AplToDate = table["AplToDate"].ToString();
                        item.HerbNm = table["HerbNm"].ToString();
                        item.Company = table["Company"].ToString();
                        item.BasAmt = table["BasAmt"].To<long>(0);

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
    }
}
