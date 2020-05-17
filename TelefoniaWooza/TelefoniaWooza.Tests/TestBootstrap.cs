using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TelefoniaWooza.API;

namespace TelefoniaWooza.Tests
{
    public class TestBootstrap
    {
       
        public HttpClient Client { get; set; }
        private TestServer _server;


        public TestBootstrap()
        {
            SetupClient();
        }
        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
