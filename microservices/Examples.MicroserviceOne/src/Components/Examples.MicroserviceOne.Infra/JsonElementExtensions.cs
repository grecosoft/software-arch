using System.Text.Json;

namespace Examples.MicroserviceOne.Infra;

public static class JsonElementExtensions
{
    public static string ReadStringProp(this JsonElement element, string name) => 
        element.TryGetProperty(name, out var propElement) ? propElement.GetString() : null;
}