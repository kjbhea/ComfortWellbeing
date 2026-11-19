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
        public HerbMain()
        {
            InitializeComponent();

            Biz = new HerbMainService();
            Model = new HerbMainModel();

            PatBiz = new FIndPatientService();

            InitControls();
        }

        private void InitControls()
        {
            TxtPtNo.SetOption(nameof(PatientDto.PtNo), Model.Patient);
            TxtPtKorNm.SetOption(nameof(PatientDto.PtKorNm), Model.Patient);
            TxtAddr.SetOption(nameof(PatientDto.ADDR), Model.Patient);
            TxtAddrDtl.SetOption(nameof(PatientDto.ADDRDTL), Model.Patient);
            TxtTel.SetOption(nameof(PatientDto.TEL), Model.Patient);

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
    }
}
