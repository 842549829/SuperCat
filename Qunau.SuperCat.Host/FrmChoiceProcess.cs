using Dongger.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qunau.SuperCat
{
    public partial class FrmChoiceProcess : DForm
    {
        public FrmChoiceProcess()
        {
            InitializeComponent();
        }

        public Process Result { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.SelectedRows == null || dgvProcesses.SelectedRows.Count != 1)
            {
                MessageBoxEx.Show("您至少需要选择一个进程进行监控", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var id = Convert.ToInt32(dgvProcesses.SelectedRows[0].Tag);
            this.Result = Process.GetProcessById(id);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmChoiceProcess_Load(object sender, EventArgs e)
        {
            var ps = Process.GetProcesses();

            foreach (var item in ps)
            {
                if (item.ProcessName.ToLower() != "droid4x")
                {
                    continue;
                }
                var row = this.dgvProcesses.Rows[this.dgvProcesses.Rows.Add()];
                row.Cells["colID"].Value = item.Id;
                row.Cells["colName"].Value = item.ProcessName;
                row.Cells["colTitle"].Value = item.MainWindowTitle;
                row.Tag = item.Id;
                item.Dispose();
            }
        }
    }
}
