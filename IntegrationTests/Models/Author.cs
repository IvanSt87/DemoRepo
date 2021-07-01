namespace IntegrationTests.Models
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Author
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
        public string? DateOfBirth { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }

    public partial class Author
    {
        public static Author FromJson(string json) => JsonConvert.DeserializeObject<Author>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
