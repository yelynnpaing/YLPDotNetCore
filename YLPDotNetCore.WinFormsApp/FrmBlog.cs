using System.Data;
using YLPDotNetCore.Shared;
using YLPDotNetCore.WinFormsApp.Models;
using YLPDotNetCore.WinFormsApp.Queries;

namespace YLPDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        public static DapperService _dapperService;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlog_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim(),
                };

                int result = _dapperService.Execute(BlogQuery.BlogCreateQuery, blog);
                string message = result > 0 ? "Saving Successful." : "Saving Fail.";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
                if(result > 0)
                    ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        public void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}
