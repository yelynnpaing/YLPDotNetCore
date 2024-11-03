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
            blogList();
        }

        private void blogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogListQuery);
            dgvData.DataSource = lst;
        }
        
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)ENumFormControlType.Edit)
            {
                FrmBlog blog = new FrmBlog(blogId);
                blog.ShowDialog();

                blogList();
            }
            else if(e.ColumnIndex == (int)ENumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
               
                delete(blogId);
                blogList();
            }
        }

        private void delete(int id)
        {
            string query = "DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Delete success." : "Deleting fail.";
            MessageBox.Show(message);
        }
    }
}
