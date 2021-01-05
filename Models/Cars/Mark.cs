using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestApi.Models.Cars
{
    [JsonConverter((typeof(StringEnumConverter)))]
    public enum Mark
    {
        Audi,
        Honda,
        Opel,
        Nissan
    }
}