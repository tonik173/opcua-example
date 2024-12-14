
using System.Text.Json.Nodes;
using Opc.Ua;

namespace MqttCommon;

static class Extensions
{
    public static string AsString(this JsonNode node)
    {
        if (node == null) return null;

        switch (node)
        {
            case JsonValue value:
                return value.ToString();
            default:
                return node.ToJsonString();
        }
    }

    public static bool? AsBoolean(this JsonNode node)
    {
        if (node == null) return null;

        switch (node)
        {
            case JsonValue value:
                if (value.TryGetValue(out bool number))
                {
                    return number;
                }
                break;
        }

        return null;
    }

    public static ulong? AsUInteger(this JsonNode node)
    {
        if (node == null) return null;

        switch (node)
        {
            case JsonValue value:
                if (value.TryGetValue(out ulong number))
                {
                    return number;
                }
                break;
        }

        return null;
    }

    public static DateTime? AsDateTime(this JsonNode node)
    {
        if (node == null) return null;

        switch (node)
        {
            case JsonValue value:
                if (value.TryGetValue(out DateTime dt))
                {
                    return dt;
                }
                break;
        }

        return null;
    }

    public static T AsEncodeable<T>(this JsonNode node, IServiceMessageContext context) where T : IEncodeable
    {
        if (node == null) return default(T);

        switch (node)
        {
            case JsonObject value:
                using (var decoder = new JsonDecoder(value.ToJsonString(), context))
                {
                    return (T)decoder.ReadEncodeable(null, typeof(T));
                }
        }

        return default(T);
    }

    public static Dictionary<string, JsonNode> AsMap(this JsonNode node)
    {
        Dictionary<string, JsonNode> map = new();

        if (node != null)
        {
            foreach (var field in node.AsObject())
            {
                map.Add(field.Key, field.Value);
            }
        }

        return map;
    }
}
