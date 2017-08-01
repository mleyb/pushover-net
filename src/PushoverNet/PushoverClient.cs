using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PushoverNet
{
    public interface IPushoverClient
    {
        Task SendAsync(string userKey, string message, string title = null, Uri url = null);
    }

    public class PushoverClient : IPushoverClient, IDisposable
    {
        private readonly string _appKey;

        private readonly HttpClient _client = new HttpClient();

        public PushoverClient(string appKey)
        {
            if (String.IsNullOrEmpty(appKey))
                throw new ArgumentException(nameof(appKey));

            _appKey = appKey;
        }

        public async Task SendAsync(string userKey, string message, string title = null, Uri url = null)
        {
            if (String.IsNullOrEmpty(userKey))
                throw new ArgumentException(nameof(userKey));

            if (String.IsNullOrEmpty(message))
                throw new ArgumentException(nameof(message));

            var content = new FormUrlEncodedContent(BuildContentParams(userKey, message, title, url)); 

            await _client.PostAsync("https://api.pushover.net/1/messages.json", content);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        private List<KeyValuePair<string, string>> BuildContentParams(string userKey, string message, string title = null, Uri url = null)
        {
            var contentParams = new List<KeyValuePair<string, string>> 
            {
                new KeyValuePair<string, string>("token", _appKey),
                new KeyValuePair<string, string>("user", userKey),
                new KeyValuePair<string, string>("message", message)
            };

            if (title != null)
            {
                contentParams.Add(new KeyValuePair<string, string>("title", title));
            }

            if (url != null)
            {
                contentParams.Add(new KeyValuePair<string, string>("url", url.ToString()));
            }

            return contentParams;
        }
    }
}
