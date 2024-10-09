using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StyleWeaver
{
    public class Finder
    {
        public static Dictionary<string, object> FindDictByKeyValue(Dictionary<string, object> data, string targetKey, object targetValue)
        {
            try
            {
                // If the data is a dictionary, search through its key-value pairs
                if (data is Dictionary<string, object> dict)
                {
                    foreach (var kvp in dict)
                    {
                        // If the key-value pair matches, return the dictionary
                        if (kvp.Key == targetKey && kvp.Value.Equals(targetValue))
                        {
                            return dict;
                        }

                        // If the value is another dictionary or list, recursively search within it
                        if (kvp.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Object)
                        {
                            // Convert the JsonElement object to a Dictionary<string, object>
                            var nestedDict = JsonElementToDictionary(jsonElement);
                            var result = FindDictByKeyValue(nestedDict, targetKey, targetValue);
                            if (result != null)
                            {
                                return result;
                            }
                        }
                    }
                }
                // Not sure if this is needed as the item is explicitly a dictionary
                //NEED TESTING
                else if (data is object list)
                {
                    /*foreach (var item in list)
                    {
                        var result = FindDictByKeyValue(item, targetKey, targetValue);
                        if (result != null)
                        {
                            return result;
                        }
                    }*/
                }

                // If no match is found, return null
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        public static Dictionary<string, object> JsonElementToDictionary(JsonElement element)
        {
            var dict = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                dict.Add(property.Name, property.Value);
            }
            return dict;
        }

        // Method to recursively find a value by key
        public static Dictionary<string, object> FindValueByKey(object data, string targetKey)
        {
            // If data is a dictionary, search through its key-value pairs
            if (data is Dictionary<string, object> dict)
            {
                foreach (var kvp in dict)
                {
                    // If the key matches the target key, return the value
                    if (kvp.Key == targetKey)
                    {
                        return (Dictionary<string, object>)kvp.Value;
                    }

                    // If the value is another dictionary or list, recursively search within it
                    if (kvp.Value is Dictionary<string, object> || kvp.Value is List<object>)
                    {
                        var result = FindValueByKey(kvp.Value, targetKey);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }
            // If data is a list, iterate through each item
            else if (data is List<object> list)
            {
                foreach (var item in list)
                {
                    var result = FindValueByKey(item, targetKey);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            // If no match is found, return null
            return null;
        }

        // Method to find the grandparent container
        public static Dictionary<string, object> FindGrandparentContainer(object container, string targetKey, object targetValue)
        {
            // Helper method to perform the recursive search
            Dictionary<string, object> Search(object currentContainer, Dictionary<string, object> parent = null, Dictionary<string, object> grandparent = null)
            {
                // If the container is a dictionary
                if (currentContainer is Dictionary<string, object> dict)
                {
                    // Check if the dictionary contains the target key-value pair
                    if (dict.ContainsKey(targetKey) && dict[targetKey].Equals(targetValue))
                    {
                        return grandparent;
                    }

                    // Recursively search through the dictionary's values
                    foreach (var kvp in dict)
                    {
                        if (kvp.Value is Dictionary<string, object> || kvp.Value is List<object>)
                        {
                            var result = Search(kvp.Value, dict, parent);
                            if (result != null)
                            {
                                return result;
                            }
                        }
                    }
                }
                // If the container is a list
                else if (currentContainer is List<object> list)
                {
                    // Recursively search through each item in the list
                    foreach (var item in list)
                    {
                        if (item is Dictionary<string, object> || item is List<object>)
                        {
                            var result = Search(item, parent, grandparent);
                            if (result != null)
                            {
                                return result;
                            }
                        }
                    }
                }

                // Return null if no matching grandparent is found
                return null;
            }
            // Start the recursive search
            return Search(container);
        }
    }

    
}
