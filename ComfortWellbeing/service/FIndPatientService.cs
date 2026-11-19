using Mentorsoft.Winform.Framework.Core.Extension;
using Mentorsoft.Winform.Framework.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing
{
    public class FIndPatientService : BaseService
    {
        public PatientDto FindPatientInfo(string ptNo)
        {
            PatientDto item = new PatientDto();
            try
			{
				using (MySqlConnection mysql = new MySqlConnection(_connectionAddress))
				{
					mysql.Open();                            
                    string strSQL = string.Empty;
                    strSQL += "SELECT PtNo                 ";
                    strSQL += "     , PtKorNm              ";
                    strSQL += "     , HpNo                 ";
                    strSQL += "     , Addr                 ";
                    strSQL += "     , DetlAddr             ";
                    strSQL += "  FROM pam.pmcmptif         ";
                    strSQL += " WHERE 1 = 1                ";
                    strSQL += "   AND PtNo = '" + ptNo.LPAD(8, "0") + "'";
                                        
					MySqlCommand command = new MySqlCommand(strSQL, mysql);
					MySqlDataReader table = command.ExecuteReader();

					while (table.Read())
					{						
						item.PtNo = table["PtNo"].ToString();
                        item.PtKorNm = table["PtKorNm"].ToString();
						item.TEL = table["HpNo"].ToString();                        
                        item.ADDR = table["Addr"].ToString();			
                        item.ADDRDTL = table["DetlAddr"].ToString();			                        
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
