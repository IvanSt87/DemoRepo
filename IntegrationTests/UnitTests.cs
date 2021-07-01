namespace IntegrationTests
{
    using IntegrationTests.Models;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://libraryjuly.azurewebsites.net/");
        }

        [Test]
        public async Task VerifyAuthorCreation()
        {
            var author = new Author();
            author.FirstName = "Ivan";
            author.LastName = "Stalev";
            author.Genre = "Action";

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseAsString);

            var expectedAuthor = new Author()
            {
                Name = $"{author.FirstName} {author.LastName}",
                Genre = author.Genre
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task VerifyAuthorGetting()
        {
            var authorId = "2241dc27-617b-433c-9fe5-8f61443dd52d";

            var response = await _client.GetAsync($"/api/authors/{authorId}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(responseAsString);

            var expectedAuthor = new Author()
            {
                Name = "Ivan Testing",
                Genre = "Horror"
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task VerifyAuthorDeletion()
        {
            var author = new Author();
            author.FirstName = "Ivan";
            author.LastName = "Stalev";
            author.Genre = "Horror";

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");
            var creation = await _client.PostAsync("/api/authors", content);
            creation.EnsureSuccessStatusCode();
            var responseAsString = await creation.Content.ReadAsStringAsync();
            var authorData = JsonConvert.DeserializeObject<Author>(responseAsString);
            var authorId = authorData.Id;

            var deletion = await _client.DeleteAsync($"/api/authors/{authorId}");
            deletion.EnsureSuccessStatusCode();

            var response = await _client.GetAsync($"/api/authors/{authorId}");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
