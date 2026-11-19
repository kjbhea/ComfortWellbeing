using DevExpress.XtraPrinting.Native.Navigation;
using Mentorsoft.Winform.Framework.Controls;
using Mentorsoft.Winform.Framework.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing
{
    public partial class BasHerbCd : Form
    {
        private BasHerbCdModel Model = new BasHerbCdModel();
        private BasHerbCdService Biz = new BasHerbCdService();

        public BasHerbCd()
        {
            InitializeComponent();

            Biz = new BasHerbCdService();
            Model = new BasHerbCdModel();

            InitControls();
        }

        private void InitControls()
        {
            // 영양제코드
            TxtHerbCd.SetOption(nameof(BHERBCDMODEL.HerbCd), Model.BHerbCd);
            // 적용일자
            CboAplDate.SetOption(nameof(BHERBCDMODEL.AplDate), Model.BHerbCd,
                nameof(COMBODTO.DISPLAYMEMBER),
                nameof(COMBODTO.VALUEMEMBER),
                Model.AplDateList,                
                ImageComboBoxDisplayType.Text);
            // 시작일자
            DtpAplFrDate.SetOption(nameof(BHERBCDMODEL.AplFrDate), Model.BHerbCd, dateFormatType: MTSDateTimeType.YYYY_MM_DD, dateFormatValue: MTSDateTimeType.YYYYMMDD);
            // 종료일자
            DtpAplToDate.SetOption(nameof(BHERBCDMODEL.AplToDate), Model.BHerbCd, dateFormatType: MTSDateTimeType.YYYY_MM_DD, dateFormatValue: MTSDateTimeType.YYYYMMDD);
            // 영양제명칭
            TxtHerbNm.SetOption(nameof(BHERBCDMODEL.HerbNm), Model.BHerbCd);
            // 제조사
            TxtCompany.SetOption(nameof(BHERBCDMODEL.Company), Model.BHerbCd);
            // 단가
            TxtBasAmt.SetOption(nameof(BHERBCDMODEL.BasAmt), Model.BHerbCd, editMask:"n0", minValue:0, maxValue:99999);
            // 총량
            TxtTotalQty.SetOption(nameof(BHERBCDMODEL.TotalQty), Model.BHerbCd, editMask:"n0", minValue:0, maxValue:99999);
            // 1회섭취량
            TxtQty.SetOption(nameof(BHERBCDMODEL.Qty), Model.BHerbCd, editMask:"n0", minValue:0, maxValue:99999);
            // 분량
            TxtCnt.SetOption(nameof(BHERBCDMODEL.Cnt), Model.BHerbCd, editMask:"n0", minValue:0, maxValue:99999);
            // 성분
            TxtIngredient.SetOption(nameof(BHERBCDMODEL.Ingredient), Model.BHerbCd);

            GrdView.Columns.Clear();            
            GrdView.AddColumn("코드", nameof(BHERBCDMODEL.HerbCd), 100, EditbleType.False, MTSGridColumnType.Text, Align.Center);           
            GrdView.AddColumn("명칭", nameof(BHERBCDMODEL.HerbNm), 150, EditbleType.False, MTSGridColumnType.Text, Align.Center);                        
            GrdView.AddColumn("제조사", nameof(BHERBCDMODEL.Company), 200, EditbleType.False, MTSGridColumnType.Text, Align.Center);                        
            GrdView.DataSource = Model.BHerbList;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Model.BHerbCd = new BHERBCDMODEL();
            Model.BHerbCd.AplFrDate = DateTime.Now.ToString("yyyyMMdd");
            Model.BHerbCd.AplToDate = "99991231";
            TxtHerbCd.Focus();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Model.BHerbList = Biz.FindList();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Biz.SaveData(Model.BHerbCd))
            {
                MessageBox.Show("저장완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }
            else
            {
                MessageBox.Show("저장오류", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("정말 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            { 
                if (Biz.DeleteData(Model.BHerbCd))
                {
                    MessageBox.Show("삭제완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("삭제오류", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  
        }

        private void GrdView_Click(object sender, EventArgs e)
        {
            if (GrdView.FocusedRowHandle < 0)
            {
                return;
            }

            BHERBCDMODEL selectedRow = GrdView.GetRow(GrdView.FocusedRowHandle) as BHERBCDMODEL;
            if (selectedRow != null) 
            {
                Model.BHerbCd.HerbCd = selectedRow.HerbCd;
                Model.AplDateList = Biz.FindAplData(selectedRow);
                CboAplDate_SelectionChanged(null, null);
            }            
        }

        private void CboAplDate_SelectionChanged(object sender, DevExpress.XtraEditors.Controls.PopupSelectionChangedEventArgs e)
        {
            Model.BHerbCd = Biz.FindData(Model.BHerbCd.HerbCd, Model.BHerbCd.AplDate);
        }

        private void CboAplDate_EditValueChanged(object sender, EventArgs e)
        {
            Model.BHerbCd = Biz.FindData(Model.BHerbCd.HerbCd, Model.BHerbCd.AplDate);
        }
    }
}
