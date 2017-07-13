using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("token", _appKey),
                new KeyValuePair<string, string>("user", userKey),
                new KeyValuePair<string, string>("message", message)
            });

            using (var client = new HttpClient())
            {
                await client.PostAsync("https://api.pushover.net/1/messages.json", content);
            }
        }
    }
}
