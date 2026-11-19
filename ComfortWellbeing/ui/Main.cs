using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComfortWellbeing.ui
{
    public partial class Main : Form
    {
        private HerbMain HerbMainX = null;
        private BasHerbCd BasHerbCdX = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            메인업무ToolStripMenuItem.PerformClick();
            this.WindowState = FormWindowState.Maximized;
        }

        private void 메인업무ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HerbMainX != null)
            {
                HerbMainX.Dispose();
                HerbMainX = null;
            }

            HerbMainX = new HerbMain();
            HerbMainX.MdiParent = this;
            HerbMainX.Show();
            HerbMainX.BringToFront();
        }

        private void 코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BasHerbCdX != null)
            {
                BasHerbCdX.Dispose();
                BasHerbCdX = null;
            }
            
            BasHerbCdX = new BasHerbCd();
            BasHerbCdX.StartPosition = FormStartPosition.CenterParent;
            BasHerbCdX.ShowDialog();
        }
    }
}
