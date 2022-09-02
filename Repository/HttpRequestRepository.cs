using EmployeeRecords.Interface;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace EmployeeRecords.Repositoty
{
    public class HttpRequestRepository : IHttpRequest
    {
        public async Task<object> GetJson(string Uri)
        {
           string Url = "http://localhost:30959/api/" + Uri;
           var client = new HttpClient();
           client.BaseAddress = new Uri(Url);
           HttpResponseMessage httpResponse =
           await client.GetAsync(Url);
           if (httpResponse.IsSuccessStatusCode)
           {
               return httpResponse.Content.ReadAsStringAsync().Result;
           }
            return null;
        }
        public async Task<object> DeleteJson(string Uri)
        {
            try
            {
                string Url = "http://localhost:30959/api/" + Uri;
                var client = new HttpClient();
                client.BaseAddress = new Uri(Url);
                HttpResponseMessage httpResponse =
                await client.DeleteAsync(Url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return httpResponse.Content.ReadAsStringAsync().Result;
                }
            }
            catch
            { }
            return null;
        }
        public async Task<string> PostJson(string Uri, object Emp)
        {

            string Url = "http://localhost:30959/api/" + Uri;
            var client = new HttpClient();
            string Result = null;
            client.BaseAddress = new Uri(Url);
            var json = JsonConvert.SerializeObject(Emp);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse =
            await client.PostAsync(Url, httpcontent);
            if (httpResponse.IsSuccessStatusCode)
            {
                Result = httpResponse.Content.ReadAsStringAsync().Result;
            }
            return Result;

        }
        public async Task<string> PutJson(string Uri, object Emp)
        {

            string Url = "http://localhost:30959/api/" + Uri;
            var client = new HttpClient();
            string Result = null;
            client.BaseAddress = new Uri(Url);
            var json = JsonConvert.SerializeObject(Emp);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse =
             await client.PutAsync(Url, httpcontent);
            if (httpResponse.IsSuccessStatusCode)
            {
                Result = httpResponse.Content.ReadAsStringAsync().Result;
            }
            return Result;

        }
        public async Task<string> PostFile(string Uri, IFormFile Emp)
        {
            string Url = "http://localhost:30959/api/" + Uri;

            var client = new HttpClient();
            string Result = null;
            client.BaseAddress = new Uri(Url);
            var httpcontent = (MultipartFormDataContent)null;
            if (Emp != null)
            {
                 httpcontent = new MultipartFormDataContent();
                var fileContent = new StreamContent(Emp.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(Emp.ContentType);
                httpcontent.Add(fileContent, "file", Emp.FileName);
            }

            HttpResponseMessage httpResponse =
                  await client.PostAsync(Url, httpcontent);
            if (httpResponse.IsSuccessStatusCode)
            {
                Result = httpResponse.Content.ReadAsStringAsync().Result;
            }
            return Result;
        }
    }
}
