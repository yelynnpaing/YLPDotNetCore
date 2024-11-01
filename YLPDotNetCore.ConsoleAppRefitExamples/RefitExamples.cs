using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static YLPDotNetCore.ConsoleAppRefitExamples.IBlogApi;

namespace YLPDotNetCore.ConsoleAppRefitExamples;

public class RefitExamples
{
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7065");
    public async Task RunAsync()
    {
        //await GetAsync();
        //await EditAsync(1);
        //await EditAsync(100);
        //await CreateAsync("RString", "RString", "RString");
        //await DeleteAsync(200);
        //await DeleteAsync(4);
        await UpdateBlog(7, "RString", "RString", "RString");
        await UpdateBlog(100, "RString", "RString", "RString");
    }
    
    private async Task GetAsync()
    {
        var lst = await _service.GetBlogs();
        foreach (var blog in lst)
        {
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
            Console.WriteLine("----------------------------------");
        }
    }

    private async Task EditAsync(int id)
    {
        //Refit.ApiException: 'Response status code does not indicate success: 404 (Not Found).'
        try
        {
            var item = await _service.GetBlog(id);
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("----------------------------------");
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex) 
        {
                Console.WriteLine(ex.ToString());
        } 
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogModel blog = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,
        };

        string message = await _service.CreateBlog(blog);
        Console.WriteLine(message);
    }

    private async Task UpdateBlog(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private async Task DeleteAsync(int id)
    {
        try
        {
            string message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (Refit.ApiException ex)
        {
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
