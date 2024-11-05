using YLPDotNetCore.Shared;

namespace YLPDotNetCore.WindowFormAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;

        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //string query = $"SELECT * FROM Tbl_User WHERE Email = '{txtEmail.Text.Trim()}' AND Password = '{txtPassword.Text.Trim()}'";
            //var model = _dapperService.QueryFirstOrDefault<UserModel>(query);

            string query = $"SELECT * FROM Tbl_User WHERE Email = @Email AND Password = @Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });

            if(model is null)
            {
                MessageBox.Show("No User found.");
                return;
            }

            MessageBox.Show("Admin mail - " + model.Email);
        }

        public class UserModel
        {
            public string Email { get; set; }
            public bool IsAdmin { get; set; }   
        }
    }
}
