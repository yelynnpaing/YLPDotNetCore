using System.Data;
using YLPDotNetCore.Shared;
using YLPDotNetCore.WinFormsApp.Models;
using YLPDotNetCore.WinFormsApp.Queries;

namespace YLPDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        public static DapperService _dapperService;
        private readonly int _blogId;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var model = _dapperService.QueryFirstOrDefault<BlogModel>("SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId", new { BlogId = _blogId });
            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnUpdate.Visible = true;
            btnSave.Visible = false;
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
                if (result > 0)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel()
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };

                string query = @"UPDATE [dbo].[Tbl_Blog]
                SET [BlogTitle] = @BlogTitle
                  ,[BlogAuthor] = @BlogAuthor
                  ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";

                int result = _dapperService.Execute(query, item);
                string message = result > 0 ? "Update success." : "Updating fail.";
                MessageBox.Show(message);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
