using JourneyMicroservice.Core.Entity;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;

namespace JourneyMicroservices.Test
{
    [TestFixture]
    public class Tests
    {
        private WebFactory _factory;
        private HttpClient _client;
        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new WebFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public void Inser_Test()
        {
            Journey newJourney = new Journey
            {

            };
            string json = JsonConvert.SerializeObject(newJourney);
        }

        [OneTimeTearDown]
        public void TearDow()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}