using System.Text.Json;
namespace fileparsers;

public class JSONParser : IParserFileToString
{
    private readonly JsonDocument _jsonDocument;

    public JSONParser(JsonDocument jsonDocument) 
    {
        _jsonDocument = jsonDocument;
    }

    public string ConvertToString()
    {
        string result = "";
        JsonElement rootElement = _jsonDocument.RootElement;
        // Get type of element, enumerateArray for array, enumerateObject for object, getString for other
        // test type = object
        foreach (JsonProperty var in rootElement.EnumerateObject())
        {
            result += var.Name + " ";
            result += processElement(var.Value);
        }
        /*
        else if (rootElement.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement var in rootElement.EnumerateArray())
            {
                result += processElement(var);
            }
        }
        else result += rootElement.GetString() + " ";
        */

        return result;
    }

    private string processElement(JsonElement element)
    {
        string result = "";

        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty var in element.EnumerateObject())
            {
                result += var.Name + " ";
                result += processElement(var.Value);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement var in element.EnumerateArray())
            {
                result += processElement(var);
            }
        }
        else if (element.GetString() != "")
        {
            result += element.GetString() + " ";
        }

        return result;
    }
}