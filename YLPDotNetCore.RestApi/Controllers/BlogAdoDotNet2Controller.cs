using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using YLPDotNetCore.RestApi.Models;
using YLPDotNetCore.Shared;
using static YLPDotNetCore.Shared.AdoDotNetService;

namespace YLPDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        public BlogAdoDotNet2Controller()
        {

        }
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "SELECT * FROM Tbl_Blog";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //connection.Close();

            ////One
            ////List<BlogModel> lst = new List<BlogModel>();
            ////foreach(DataRow dr in dt.Rows)
            ////{
            ////    BlogModel blog = new BlogModel();
            ////    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            ////    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            ////    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            ////    blog.BlogContent = Convert.ToString(dr["BlogContent"]);
            ////    lst.Add(blog);

            ////}

            ////Two
            //List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //}).ToList();
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlog(int id)
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //connection.Close();

            //if(dt.Rows.Count == 0)
            //{
            //    return NotFound("No Data Found.");
            //}

            //DataRow dr = dt.Rows[0];
            //var item = new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //};
           
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            if(item is null)
            {
                return NotFound("No Data Found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogTitle", title);
            //cmd.Parameters.AddWithValue("@BlogAuthor", author);
            //cmd.Parameters.AddWithValue("@BlogContent", content);
            //int result = cmd.ExecuteNonQuery();
            //connection.Close();

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", title),
                new AdoDotNetParameter("@BlogAuthor", author),
                new AdoDotNetParameter("@BlogContent", content)
                );
            string message = result > 0 ? "Create Successful." : "Creating fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand checkCmd = new SqlCommand(query, connection);
            checkCmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if(dt.Rows.Count == 0)
            {
                return NotFound("No Data Found.");
            }
            string updateQuery = @"UPDATE [dbo].[Tbl_Blog]
                SET [BlogTitle] = @BlogTitle
                  ,[BlogAuthor] = @BlogAuthor
                  ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";
           
            SqlCommand cmd = new SqlCommand(updateQuery, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Update Success." : "Updating fail.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand checkCmd = new SqlCommand(query, connection);
            checkCmd.Parameters.AddWithValue("@BlogId", id);           
            SqlDataAdapter adapter = new SqlDataAdapter(checkCmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) 
            {
                return NotFound("No data to update.");
            }

            List<BlogModel> lst = new List<BlogModel>();
            DataRow dr = dt.Rows[0];
            BlogModel item = new BlogModel{
                BlogId = Convert.ToInt32(dr["BlogId"]), 
                BlogTitle = Convert.ToString(dr["BlogTitle"]),  
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),    
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
            lst.Add(item);
            string conditions = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!String.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
                parameters.Add(new SqlParameter("@BlogTitle", SqlDbType.VarChar){ Value = blog.BlogTitle});
                item.BlogTitle = blog.BlogTitle;
            }
            if (!String.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
                parameters.Add(new SqlParameter("@BlogAuthor", SqlDbType.VarChar) { Value = blog.BlogAuthor});
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!String.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
                parameters.Add(new SqlParameter("@BlogContent", SqlDbType.VarChar) { Value = blog.BlogContent });
                item.BlogContent = blog.BlogContent;
            }

            if(conditions.Length == 0)
            {
                return NotFound("No Data Found.");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            item.BlogId = id;
            string updateQuery = $@"UPDATE [dbo].[Tbl_Blog]
                SET {conditions}
                WHERE BlogId = @BlogId";
            SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
            updateCmd.Parameters.AddWithValue("@BlogId", id);
            updateCmd.Parameters.AddRange(parameters.ToArray());
            int result = updateCmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Update success." : "Updating fail.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = "DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //int result = cmd.ExecuteNonQuery();
            //connection.Close();
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            string message = result > 0 ? "Delete Successful." : "Deleting fail.";
            return Ok(message);
        }

    }
}
