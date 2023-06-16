using System.Text.Json.Serialization;

namespace ResourceGraphApp.Shared;

public class Content
{
    [JsonPropertyName("location")]
    public string Location { get; set; } = default!;

    [JsonPropertyName("qtd")]
    public int Qtd { get; set; }
}

public class CloudRegion
{
    [JsonPropertyName("totalRecords")]
    public int TotalRecords { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("data")]
    public List<Content> Data { get; set; } = default!;

    [JsonPropertyName("facets ")]
    public List<object> Facets { get; set; } = default!;

    [JsonPropertyName("resultTruncated")]
    public string ResultTruncated { get; set; } = default!;
}