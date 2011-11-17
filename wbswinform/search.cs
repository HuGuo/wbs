using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Wbs.BLL;
using Wbs.Entity;

namespace wbswinform
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
        }

        private void search_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“wbsDataSet.users”中。您可以根据需要移动或移除它。
            this.usersTableAdapter.Fill(this.wbsDataSet.users);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BLLUser bll = new BLLUser();
            DataTable dt = null;
            switch (cbType.SelectedIndex)
            {
                case 0:
                    dt = bll.Get().Tables[0];
                    break;
                case 1:
                    dt = bll.GetByName(tbWhile.Text.Trim()).Tables[0];
                    break;
                case 2:
                    dt = bll.GetByCode(tbWhile.Text.Trim()).Tables[0];
                    break;
            }
            usersBindingSource.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.usersTableAdapter.Update(wbsDataSet);
        }


    }
}