using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Test.Controllers.Models;
using Test.Models;
using Test.Services;

namespace TestSkillaz.Controllers
{
    [RoutePrefix("api/links")]
    public class LinksController : ApiController
    {
        private readonly ILinksService _linksService;

        public LinksController(ILinksService linksService)
        {
            _linksService = linksService;
        }

        public LinksController()
        {
            
        }

        [HttpGet]
        public async Task<IEnumerable<Link>> Get()
        {
            var clientId = GetClientId();
            return await _linksService.GetAll(clientId);
        }
        
        [Route("{url}")]
        [HttpGet]
        public async Task<Link> GetUrl(string url)
        {
            return await _linksService.GetUrl(url);
        }

        [HttpPost]
        public async Task<Link> Create([FromBody]UrlModel url)
        {
            if (!CheckURLValid(url.url))
            {
                throw new ArgumentException("Некорректный url");
            }
            
            var baseUrl =  Request.RequestUri.GetLeftPart(UriPartial.Authority);
            var clientId = GetClientId();
            return await _linksService.Create(clientId, url.url);
        }

        private string GetClientId()
        {
            var cookies = Request.Headers.GetCookies("id").FirstOrDefault();
            return cookies?["id"]?.Value;
        }
        
        private bool CheckURLValid(string strURL)
        {
            Uri uriResult;
            return Uri.TryCreate(strURL, UriKind.RelativeOrAbsolute, out uriResult);
        }
    }
}