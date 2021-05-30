using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using TakeApi.Models;
using TakeApi.Controllers;

namespace TakeApi.Controllers
{
    public class RepositoryController : ControllerBase
    {

        [HttpGet("take")]
        public IEnumerable<RepositoryModel> Get()
        {
            var response = GetRepo();
            return response;

        }

        public List<RepositoryModel> GetRepo()
        {
            string url = "https://api.github.com/users/takenet/repos";
            string urlParameters = "";
            var response = APICall.RunAsync<RepositoryModel>(url, urlParameters).GetAwaiter().GetResult();
            response = RepoCSharp(response);
            return response;
        }

        public List<RepositoryModel> RepoCSharp(List<RepositoryModel> list)
        {
            var correctlist = new List<RepositoryModel>();
            foreach(var item in list)
            {
                if (item.Language == "C#")
                    correctlist.Add(item);
            }
            correctlist.OrderBy(c => c.Created_at);

            return correctlist;
        }

        [HttpGet("take/{id}")]
        public RepositoryModel Getitem(int id)
        {
            var response = GetRepo();
            var item = response[id];

            return item;

        }

    }
}
