using Newtonsoft.Json;
using YLPDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7044/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    //Console.WriteLine(jsonStr);
//    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
//    foreach (var blog in lst)
//    {
//        //Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine(blog.BlogId);
//        Console.WriteLine(blog.BlogTitle);
//        Console.WriteLine(blog.BlogAuthor);
//        Console.WriteLine(blog.BlogContent);
//    }
//}

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();
