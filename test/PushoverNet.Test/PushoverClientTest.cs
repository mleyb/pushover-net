using System;
using Xunit;
using PushoverNet;

namespace PushoverNet.Test
{
    public class PushoverClientTest
    {
        [Fact]
        public void Construction_with_null_arg_throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PushoverClient(null));
        }

        [Fact]
        public void Construction_with_empty_string_arg_throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PushoverClient(""));
        }
    }
}
