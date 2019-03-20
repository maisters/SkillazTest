using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class LinksService : ILinksService
    {
        private readonly ILinksRepository _linksRepository;

        public LinksService(ILinksRepository linksRepository)
        {
            _linksRepository = linksRepository;
        }

        public async Task<Link> GetUrl(string shortUrl)
        {
            var link = await _linksRepository.getByShortUrl(shortUrl) 
                       ?? throw new ArgumentException("Ссылка не найдена");
            link.Count++;
            await _linksRepository.Update(link);
            
            return link;
        }

        public async Task<IEnumerable<Link>> GetAll(string id)
        {
            return await _linksRepository.GetClientsUrls(id);
        }

        public async Task<Link> Create(string clientId, string url)
        {
            var link = await _linksRepository.getByUrl(clientId, url);
            
            if (link != null)
            {
                link.ShortUrl = getShortUrl();
                await _linksRepository.Update(link);
                
                return link;
            }
            
            var newLink = new Link(clientId, url, getShortUrl());
            await _linksRepository.Insert(newLink);

            return link;
        }

        private string getShortUrl()
        {
            return Guid.NewGuid().ToString("N").Substring(0,7);
        }
    }
}