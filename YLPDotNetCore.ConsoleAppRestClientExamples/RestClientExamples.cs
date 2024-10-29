using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YLPDotNetCore.ConsoleAppRestClientExamples;

internal class RestClientExamples
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7044"));
    private readonly string _blogEndpoint = "api/blog";

    public async Task RunAsync()
    {
        //await GetAsync();
        // await EditAsync(5);
        //await DeleteAsync(5);
        await PostAsync("nString", "nString", "nString");
        await UpdateAsync(27, "nString9", "nString9", "nString9");
    }

    private async Task GetAsync()
    {
        RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
        var response =  await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string str = response.Content!;
            List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(str)!;
            foreach(var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
    }

    private async Task EditAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            string str = response.Content!;
            var item = JsonConvert.DeserializeObject<BlogDto>(str);
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task PostAsync(string title, string author, string content)
    {
        BlogDto blog = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Post);
        restRequest.AddJsonBody(blog);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        BlogDto blog = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest restRequst = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
        restRequst.AddJsonBody(blog);
        var response = await _client.ExecuteAsync(restRequst);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}" , Method.Delete);
        var response = await _client.ExecuteAsync(restRequest);
        if (response.IsSuccessStatusCode)
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
        else
        {
            var message = response.Content!;
            Console.WriteLine(message);
        }
    }
}
 