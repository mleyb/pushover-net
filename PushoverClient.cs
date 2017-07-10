using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PushoverNet
{
    public class PushoverClient
    {
        private readonly string _appKey;

        public PushoverClient(string appKey)
        {
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
                // TODO
                await client.PostAsync("https://api.pushover.net/1/messages.json", new StringContent(body.ToString()));
            }
        }
    }
}
