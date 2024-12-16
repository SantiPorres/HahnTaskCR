using System.Text.Json.Serialization;

namespace Application.DTOs;

public class CardsResponseDto()
{
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }
}

public class IconUrls
{
    [JsonPropertyName("medium")]
    public string Medium { get; set; }
    
    [JsonPropertyName("evolutionMedium")]
    public string EvolutionMedium { get; set; }
}

public class Item
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("maxLevel")]
    public int MaxLevel { get; set; }
    
    [JsonPropertyName("maxEvolutionLevel")]
    public int? MaxEvolutionLevel { get; set; }
    
    [JsonPropertyName("elixirCost")]
    public int ElixirCost { get; set; }
    
    [JsonPropertyName("iconUrls")]
    public IconUrls IconUrls { get; set; }
    
    [JsonPropertyName("rarity")]
    public string Rarity { get; set; }
}