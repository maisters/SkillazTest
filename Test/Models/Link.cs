
namespace Test.Models
{
    public class Link : BaseEntity
    {
        public string ClientID { get; set; } 
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public int Count { get; set; }

        public Link(string clientID, string url, string shortUrl)
        {
            ClientID = clientID;
            Url = url;
            ShortUrl = shortUrl;
        }
    }
}