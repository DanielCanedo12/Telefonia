using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TelefoniaWooza.Tests
{
    public class PlanoTests
    {
        private readonly TestBootstrap _testBootstrap;
        public PlanoTests()
        {
            _testBootstrap = new TestBootstrap();
        }

        [Fact]
        public async Task Plano_Get_ReturnsOkResponse()
        {
            var response = await _testBootstrap.Client.GetAsync("/api");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlanoValues_GetByTipo_ValuesReturnsOkResponse()
        {
            var response = await _testBootstrap.Client.GetAsync("/api/21/tipo/2");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlanoValues_GetByOperadora_ValuesReturnsOkResponse()
        {
            var response = await _testBootstrap.Client.GetAsync("/api/21/operadora/claro");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlanoValues_GetByPlano_ValuesReturnsOkResponse()
        {
            var response = await _testBootstrap.Client.GetAsync("/api/21/plano/PREZAO30");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ReturnsNotFoundResponse()
        {
            var response = await _testBootstrap.Client.GetAsync("/api/22/plano/PREZAO30");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Values_GetById_CorrectContentType()
        {
            var response = await _testBootstrap.Client.GetAsync("/api/");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}
