using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PushoverNet
{
    public interface IPushoverClient
    {
        Task SendAsync(string userKey, string message);
    }

    public class PushoverClient : IPushoverClient
    {
        private readonly string _appKey;

        public PushoverClient(string appKey)
        {
            if (String.IsNullOrEmpty(appKey))
                throw new ArgumentException(nameof(appKey));

            _appKey = appKey;
        }

        public async Task SendAsync(string userKey, string message)
        {
            JObject body = new JObject(new
            {
                token = _appKey,
                user = userKey,
                message = message
            });

            using (var client = new HttpClient())
            {
                await client.PostAsync("https://api.pushover.net/1/messages.json", new StringContent(body.ToString()));
            }
        }
    }
}
