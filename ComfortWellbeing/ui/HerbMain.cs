using ComfortWellbeing.model;
using DevExpress.Utils.Extensions;
using Mentorsoft.Winform.Framework.Controls;
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

        public HerbMain()
        {
            InitializeComponent();

            Biz = new HerbMainService();
            Model = new HerbMainModel();

            PatBiz = new FIndPatientService();
            SetCdBiz = new SetCodeService();

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
            GrdAARCP.AddColumn("수납일자", nameof(AARCPDTO.RcpDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMM);
            GrdAARCP.AddColumn("처방일자", nameof(AARCPDTO.OrdDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMM);
            GrdAARCP.AddColumn("계산총액", nameof(AARCPDTO.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("감액금액", nameof(AARCPDTO.MinusAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("카드", nameof(AARCPDTO.CardAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("현금", nameof(AARCPDTO.CashAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.AddColumn("계좌이체", nameof(AARCPDTO.OnLineAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAARCP.DataSource = Model.AARCPList;

            GrdAAORD.Columns.Clear();
            GrdAAORD.AddColumn("처방일자", nameof(OrderModel.OrdDate), 120, EditbleType.False, MTSGridColumnType.Date, MTSDateTimeType.YYYY_MM_DD, MTSDateTimeType.YYYYMM);
            GrdAAORD.AddColumn("처방코드", nameof(OrderModel.HerbCd), 150, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdAAORD.AddColumn("처방명", nameof(OrderModel.HerbNm), 300, EditbleType.False, MTSGridColumnType.Text, Align.Left);
            GrdAAORD.AddColumn("수량", nameof(OrderModel.Qty), 80, EditbleType.True, MTSGridColumnType.Text, Align.Right);
            GrdAAORD.AddColumn("무료", nameof(OrderModel.FREEYN), 40, EditbleType.True, MTSGridColumnType.Check, checkValue: "1", unCheckValue: "0");
            GrdAAORD.AddColumn("단가", nameof(OrderModel.BasAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAAORD.AddColumn("계산금액", nameof(OrderModel.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdAAORD.DataSource = Model.AAORDList;
            #endregion


            #region Tab3
            // 처방일자
            DtpOrderDate.SetOption(nameof(SEARCHDTO.OrderDate), Model.Param);

            // 약속처방
            GrdSetCd.Columns.Clear();
            GrdSetCd.AddColumn("처방명",nameof(SetCdModel.HerbNm), 250, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdSetCd.AddColumn("처방코드", nameof(SetCdModel.HerbCd), 100, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdSetCd.DataSource = Model.SetCdList;

            // 처방리스트
            GrdOrder.Columns.Clear();
            GrdOrder.AddColumn("처방코드", nameof(OrderModel.HerbCd), 150, EditbleType.False, MTSGridColumnType.Text, Align.Center);
            GrdOrder.AddColumn("처방명", nameof(OrderModel.HerbNm), 300, EditbleType.False, MTSGridColumnType.Text, Align.Left);            
            GrdOrder.AddColumn("수량", nameof(OrderModel.Qty), 80, EditbleType.True, MTSGridColumnType.Text, Align.Right);
            GrdOrder.AddColumn("무료", nameof(OrderModel.FREEYN), 40, EditbleType.True, MTSGridColumnType.Check, checkValue:"1", unCheckValue:"0");
            GrdOrder.AddColumn("단가", nameof(OrderModel.BasAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdOrder.AddColumn("계산금액", nameof(OrderModel.CalcAmt), 120, EditbleType.False, MTSGridColumnType.Spin, Align.Right);
            GrdOrder.DataSource = Model.OrderList;
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
            }
        }

        

        private void TabGroup_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (TabGroup.SelectedTabPage.Name.Equals("mTab1"))
            { 
            }
            else if (TabGroup.SelectedTabPage.Name.Equals("mTab2"))
            {
            }
            else if (TabGroup.SelectedTabPage.Name.Equals("mTab3"))
            {
                // 약속처방조회
                FindSetCdList();

                // 처방 그리드 초기화
                ClearOrderList();

                // 로우 추가
                AddOrderList();
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
            // 로우추가
            AddOrderList();
        }

        private void GrdOrder_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals(nameof(OrderModel.Qty)))
            {
                OrderModel selectedRow = GrdOrder.GetRow(GrdOrder.FocusedRowHandle) as OrderModel;
                selectedRow.CalcAmt = selectedRow.BasAmt * selectedRow.Qty;
            }
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
            Model.OrderList.Clear();
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
            }
        }
    }
}
