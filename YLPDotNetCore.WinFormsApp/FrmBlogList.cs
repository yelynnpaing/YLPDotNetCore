using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YLPDotNetCore.Shared;
using YLPDotNetCore.WinFormsApp.Models;
using YLPDotNetCore.WinFormsApp.Queries;

namespace YLPDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            dgvData.AutoGenerateColumns = false;
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogListQuery);
            dgvData.DataSource = lst;   
        }
    }
}
