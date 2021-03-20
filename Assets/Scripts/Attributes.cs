using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Attributes
{
    [JsonProperty]
    public string Name { get; set; }
    [JsonProperty]
    public double Health { get; set; }
    [JsonProperty]
    public double Damage { get; set; }
    [JsonProperty]
    public long Cost { get; set; }
    [JsonProperty]
    public string Description { get; set; }
}
