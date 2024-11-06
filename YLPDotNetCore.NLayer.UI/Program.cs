
using YLPDotNetCore.NLayer.DataAccess.Models;
using YLPDotNetCore.NLayer.BusinessLogic.Services;

//Console.WriteLine("Hello world.");

BL_Blog blBlog = new BL_Blog();

//var lst = blBlog.GetBlogs();
//foreach (var item in lst)
//{
//    Console.WriteLine(item.BlogId);
//    Console.WriteLine(item.BlogTitle);
//    Console.WriteLine(item.BlogAuthor);
//    Console.WriteLine(item.BlogContent);
//    Console.WriteLine("-------------------------------------");
//}

//var item = blBlog.GetBlog(1);
//Console.WriteLine(item.BlogId);
//Console.WriteLine(item.BlogTitle);
//Console.WriteLine(item.BlogAuthor);
//Console.WriteLine(item.BlogContent);
//Console.WriteLine("-------------------------------------");

//BlogModel model = new BlogModel()
//{
//    BlogTitle = "Title1",
//    BlogAuthor = "Author1",
//    BlogContent = "Content"

//};
//int item = blBlog.CreateBlog(model);
//string result = item > 0 ? "Create success." : "Create fail.";
//Console.WriteLine(result);
//Console.WriteLine("-------------------------------------");

//BlogModel model = new BlogModel()
//{
//    BlogTitle = "Title1",
//    BlogAuthor = "Author1",
//    BlogContent = "Content1"

//};
//int item = blBlog.UpdateBlog(1, model);
//string result = item > 0 ? "Update success." : "Update fail.";
//Console.WriteLine(result);
//Console.WriteLine("-------------------------------------");

BlogModel model = new BlogModel()
{
    BlogTitle = "Title1 Patch"
};

int item  = blBlog.PatchBlog(34, model);
string result = item > 0 ? "Patch success." : "Patching fail.";
Console.WriteLine(result);
Console.WriteLine("-------------------------------------");

//int item = blBlog.DeleteBlog(33);
//string result = item > 0 ? "Delete success." : "No data found.";
//Console.WriteLine(result);

Console.ReadLine();