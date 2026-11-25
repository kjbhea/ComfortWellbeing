using ComfortWellbeing.model;
using DevExpress.Utils.Extensions;
using Mentorsoft.Winform.Framework.Controls;
using Mentorsoft.Winform.Framework.Core;
using Mentorsoft.Winform.Framework.Core.Enums;
using Mentorsoft.Winform.Framework.Core.Extension;
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
    public partial class HerbMain : Form
    {
        public HerbMainService Biz = null;
        public HerbMainModel Model = null;

        public FIndPatientService PatBiz = null;
        public SetCodeService SetCdBiz = null;
        public Tab1Service Tab1Biz = null;
        public Tab2Service Tab2Biz = null;
        public Tab3Service Tab3Biz = null;

        public HerbMain()
        {
            InitializeComponent();

            Biz = new HerbMainService();
            Model = new HerbMainModel();

            PatBiz = new FIndPatientService();
            SetCdBiz = new SetCodeService();
            Tab1Biz = new Tab1Service();
            Tab2Biz = new Tab2Service();
            Tab3Biz = new Tab3Service();

            InitControls();
        }

        private void InitControls()
        {

            TxtPtNo.SetOption(nameof(PatientDto.PtNo), Model.Patient);
            TxtPtKorNm.SetOption(nameof(PatientDto.PtKorNm), Model.Patient);
            TxtAddr.SetOption(nameof(PatientDto.ADDR), Model.Patient);
            TxtAddrDtl.SetOption(nameof(PatientDto.ADDRDTL), Model.Patient);
            TxtTel.SetOption(nameof(PatientDto.TEL), Model.Patient);


            #region // Tab2
            GrdAARCP.Columns.Clear();
            GrdAARCP.AddColumn("C", nameof(AARCPDTO.CHK), 40, EditbleType.True, MTSGridColumnType.Check, checkValue:"1", unCheckValue:"0");
            GrdAARCP.AddColumn("수납일자", nameof(AARCPDTO.RcpDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMMDD);
            GrdAARCP.AddColumn("처방일자", nameof(AARCPDTO.OrdDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMMDD);
            GrdAARCP.AddColumn("계산총액", nameof(AARCPDTO.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("감액금액", nameof(AARCPDTO.MinusAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("카드", nameof(AARCPDTO.CardAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("현금", nameof(AARCPDTO.CashAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("계좌이체", nameof(AARCPDTO.OnLineAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.DataSource = Model.AARCPList;

            GrdAAORD.Columns.Clear();
            GrdAAORD.AddColumn("처방일자", nameof(OrderModel.OrdDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMMDD);
            GrdAAORD.AddColumn("처방코드", nameof(OrderModel.HerbCd), 150, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdAAORD.AddColumn("처방명", nameof(OrderModel.HerbNm), 300, EditbleType.False, MTSGridColumnType.Text, Align.Left);
            GrdAAORD.AddColumn("수량", nameof(OrderModel.Qty), 80, EditbleType.False, MTSGridColumnType.Text, Align.Right);
            GrdAAORD.AddColumn("무료", nameof(OrderModel.FREEYN), 40, EditbleType.False, MTSGridColumnType.Check, checkValue: "1", unCheckValue: "0");
            GrdAAORD.AddColumn("단가", nameof(OrderModel.BasAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAAORD.AddColumn("계산금액", nameof(OrderModel.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAAORD.DataSource = Model.AAORDList;
            #endregion


            #region Tab3
            // 처방일자
            DtpOrderDate.SetOption(nameof(SEARCHDTO.OrderDate), Model.Param);

            // 약속처방
            GrdSetCd.Columns.Clear();
            GrdSetCd.AddColumn("처방코드", nameof(SetCdModel.HerbCd), 80, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdSetCd.AddColumn("처방명",nameof(SetCdModel.HerbNm), 200, EditbleType.False, MTSGridColumnType.Text, Align.Left);            
            GrdSetCd.AddColumn("재고\r\n수량", nameof(SetCdModel.StockCnt), 60, EditbleType.False, MTSGridColumnType.Text, Align.Right);
            GrdSetCd.DataSource = Model.SetCdList;

            // 처방리스트
            GrdOrder.Columns.Clear();
            GrdOrder.AddColumn("처방코드", nameof(OrderModel.HerbCd), 80, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdOrder.AddColumn("처방명", nameof(OrderModel.HerbNm), 200, EditbleType.False, MTSGridColumnType.Text, Align.Left);            
            GrdOrder.AddColumn("수량", nameof(OrderModel.Qty), 80, EditbleType.True, MTSGridColumnType.Text, Align.Right);
            GrdOrder.AddColumn("재고\r\n수량", nameof(OrderModel.StockCnt), 60, EditbleType.False, MTSGridColumnType.Text, Align.Right);
            GrdOrder.AddColumn("무료", nameof(OrderModel.FREEYN), 40, EditbleType.True, MTSGridColumnType.Check, checkValue:"1", unCheckValue:"0");
            GrdOrder.AddColumn("단가", nameof(OrderModel.BasAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdOrder.AddColumn("계산금액", nameof(OrderModel.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdOrder.DataSource = Model.OrderList;

            // 총계산금액
            TxtTotalAmt.SetOption(nameof(PayModel.CalcAmt), Model.PayInfo, isReadOnly: true, minValue:0, maxValue:99999999);
            // 감액금액
            TxtMinusAmt.SetOption(nameof(PayModel.MinusAmt), Model.PayInfo, isReadOnly: false, minValue: 0, maxValue: 99999999);
            // 계정코드
            RdoCard.SetOption(nameof(PayModel.AccCd), Model.PayInfo, valueChecked: "CARD", isRadio:true);
            RdoCash.SetOption(nameof(PayModel.AccCd), Model.PayInfo, valueChecked: "CASH", isRadio: true);
            RdoOnline.SetOption(nameof(PayModel.AccCd), Model.PayInfo, valueChecked: "ONLINE", isRadio: true);
            Model.PayInfo.AccCd = "CARD";
            // 수납금액
            TxtPayAmt.SetOption(nameof(PayModel.PayAmt), Model.PayInfo, isReadOnly: true, minValue: 0, maxValue: 99999999);

            TxtMinusAmt.Font = new Font("맑은 나눔", 15);
            #endregion

        }
        private void HerbMain_Load(object sender, EventArgs e)
        {
            
        }

        private void TxtPtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Model.Patient = PatBiz.FindPatientInfo(Model.Patient.PtNo);

                // 영수내역 클리어
                ClearAARCP();
                // 영수내역 조회
                FindAARCP();
                // 처방 클리어
                ClearOrderList();
            }
        }

        private void TabGroup_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (TabGroup.SelectedTabPage.Name.Equals("mTab1"))
            { 
            }
            else if (TabGroup.SelectedTabPage.Name.Equals("mTab2"))
            {
                FindAARCP();
            }
            else if (TabGroup.SelectedTabPage.Name.Equals("mTab3"))
            {                
                // 처방 그리드 초기화
                ClearOrderList();
            }

        }

        private void GrdSetCd_DoubleClick(object sender, EventArgs e)
        {
            if (GrdSetCd.FocusedRowHandle < 0)
            {
                return;
            }

            // 약속처방 => 처방
            AddSetCd();
            // 수납금액계산
            CalcPayAmt();
            // 로우추가
            AddOrderList();
            
        }

        private void GrdOrder_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals(nameof(OrderModel.Qty)))
            {
                OrderModel selectedRow = GrdOrder.GetRow(GrdOrder.FocusedRowHandle) as OrderModel;
                selectedRow.CalcAmt = selectedRow.BasAmt * selectedRow.Qty;

                // 수납금액계산
                CalcPayAmt();
            }
        }

        private void clearAll()
        { 
            Model.Patient = new PatientDto();

            ClearAARCP();
            ClearOrderList();

            TxtPtNo.Focus();
        }

        private void ClearAARCP()
        {
            Model.AARCPList.Clear();
            Model.AAORDList.Clear();
        }

        /// <summary>
        /// 약속처방 조회
        /// </summary>
        private void FindSetCdList()
        {
            Model.SetCdList = SetCdBiz.FindList();
        }

        private void AddSetCd()
        {
            SetCdModel item = GrdSetCd.GetRow(GrdSetCd.FocusedRowHandle) as SetCdModel;
            OrderModel row = Model.OrderList.FirstOrDefault(r => r.HerbNm.Empty());

            row.HerbCd = item.HerbCd;
            row.HerbNm = item.HerbNm;
            row.Qty = 1;
            row.BasAmt = item.BasAmt;
            row.CalcAmt = item.BasAmt * row.Qty;
        }

        private void ClearOrderList()
        {
            DateTime dtm = DateTime.Now;
            Model.Param.OrderDate = dtm.ToString("yyyyMMdd");

            Model.OrderList.Clear();
            Model.OrderList.AddNew(1);

            // 약속처방조회
            FindSetCdList();

            // 수납금액계산
            CalcPayAmt();
        }

        private void AddOrderList()
        {
            Model.OrderList.AddNew(1);
        }

        private void GrdOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {
                OrderModel selectedRow = GrdOrder.GetRow(GrdOrder.FocusedRowHandle) as OrderModel;
                Model.OrderList.Remove(selectedRow);

                // 수납금액계산
                CalcPayAmt();
            }
        }

        /// <summary>
        /// 수납금액계산
        /// </summary>
        private void CalcPayAmt()
        {
            Model.PayInfo.CalcAmt = Model.OrderList.Sum(r => r.CalcAmt);
            Model.PayInfo.PayAmt = Model.PayInfo.CalcAmt - Model.PayInfo.MinusAmt;
        }

        private void TxtMinusAmt_EditValueChanged(object sender, EventArgs e)
        {
            if (Model.PayInfo.CalcAmt < TxtMinusAmt.EditValue.To<long>(0))
            {
                MTSMessageBox.Show("감액금액은 총계산금액보다 클수 없습니다.");
                TxtMinusAmt.EditValue = 0;
                Model.PayInfo.MinusAmt = 0;
                return;
            }

            //수납금액계산
            CalcPayAmt();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (Tab3Biz.SaveData(Model.Patient, Model.Param, Model.OrderList, Model.PayInfo))
            {
                MessageBox.Show("수납완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 처방 그리드 초기화
                ClearOrderList();
            }
            else
            {
                MessageBox.Show("수납오류", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindAARCP()
        {
            Model.AARCPList = Tab2Biz.FindAARCPList(Model.Patient);
        }

        private void GrdAARCP_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (GrdAARCP.FocusedRowHandle < 0)
            {
                return;
            }

            AARCPDTO selectedRow = GrdAARCP.GetRow(GrdAARCP.FocusedRowHandle) as AARCPDTO;
            Model.AAORDList = Tab2Biz.FindAAORDList(selectedRow);
        }

        private void HerbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                clearAll();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // 영수내역 클리어
            ClearAARCP();
            // 영수내역 조회
            FindAARCP();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("정말 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                List<AARCPDTO> list = Model.AARCPList.ToList().FindAll(r => r.StsCls.Equals("0") && r.CHK.Equals("1"));
                if (Tab2Biz.DeleteData(list))
                {
                    MessageBox.Show("수납취소완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnSearch.PerformClick();
                }
                else
                {
                    MessageBox.Show("수납취소오류", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }                
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            AARCPDTO selectedRow = GrdAARCP.GetRow(e.RowHandle) as AARCPDTO;
            // 수납취소영수증 색상표기
            if (selectedRow.StsCls != "0")
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }
    }
}
