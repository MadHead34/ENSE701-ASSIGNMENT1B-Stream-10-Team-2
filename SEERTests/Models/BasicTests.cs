using Microsoft.AspNetCore.Mvc.Testing;
using SEER.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SEER.Models.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/Error")]
        [InlineData("/Privacy")]
        [InlineData("/InitialArticle/Create")]
        [InlineData("/InitialArticle/Failure")]
        [InlineData("/InitialArticle/Success")]
        [InlineData("/BibliographicReferences/Create")]
        [InlineData("/BibliographicReferences/Index")]
        [InlineData("/BibliographicReferences/Search")]
        [InlineData("/AcceptedArticle/Failure")]
        [InlineData("/AcceptedArticle/Index")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}