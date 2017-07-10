using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            using (var client = new HttpClient())
            {
                // TODO
                await client.PostAsync("", new StringContent(""));
            }
        }
    }
}
