
//using Refit;
//using YLPDotNetCore.ConsoleAppRefitExamples;

//var service = RestService.For<IBlogApi>("https://localhost:7065");
//var lst = await service.GetBlog();
//foreach(var blog in lst)
//{
//    Console.WriteLine(blog.BlogId);
//    Console.WriteLine(blog.BlogTitle);
//    Console.WriteLine(blog.BlogAuthor);
//    Console.WriteLine(blog.BlogContent);
//    Console.WriteLine("----------------------------------");
//}

using YLPDotNetCore.ConsoleAppRefitExamples;

RefitExamples refitExamples = new RefitExamples();
await refitExamples.RunAsync();

Console.ReadLine();