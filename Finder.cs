//No longer need but keeping for reference. Replaced this file with Nuget JSON Package

//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace StyleWeaver
//{
//    public class Finder
//    {
//        public static object FindDictByKeyValue(JToken data, string targetKey, object targetValue)
//        {
//            /*try
//            {
//                // If the data is a dictionary, search through its key-value pairs
//                //if (data is Dictionary<string, object> dict)

//                for (var i = 0; i < data.Count(); i++)
//                {
//                    data.Sel
//                        //Console.WriteLine("Key: {0} Value: {1}", kvp.Key, kvp.Value.ToString());
//                        // If the key-value pair matches, return the dictionary
//                        if (kvp.Key == targetKey && kvp.Value.Equals(targetValue))
//                        {
//                            return dict;
//                        }

//                        // If the value is another dictionary or list, recursively search within it
//                        if (kvp.Value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Object)
//                        {
//                            // Convert the JsonElement object to a Dictionary<string, object>
//                            var nestedDict = JsonElementToDictionary(jsonElement);
//                            var result = FindDictByKeyValue(nestedDict, targetKey, targetValue);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }
//                }
//                // Not sure if this is needed as the item is explicitly a dictionary
//                //NEED TESTING
//                *//*else if (data is object list)
//                {
//                    foreach (var item in list)
//                    {
//                        var result = FindDictByKeyValue(item, targetKey, targetValue);
//                        if (result != null)
//                        {
//                            return result;
//                        }
//                    }
//                }*//*

//                // If no match is found, return null
//                return null;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine($"Error: {e.Message}");
//                return null;
//            }*/
//            //return null;
//        }

//        public static JToken SearchValue(JObject data, string targetValue = null, string targetKey = null)
//        {
//            // Search by key
//            if (targetValue == null && targetKey != null)
//            {
//                foreach (var item in data.Properties())
//                {
//                        if (item.Name == targetKey)
//                        {
//                            return item.Value;
//                        }

//                        // Recurse into the property value if it's a JObject
//                        if (item.Value is JObject || item.Children().Count() > 0)
//                        {
//                            var result = SearchValue(item.Value as JObject, targetValue, targetKey);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }

//                        // Recurse into arrays if the value is a JArray
//                        if (item.Value is JArray childArray)
//                        {
//                            foreach (var token in childArray)
//                            {

//                                if (token is JObject arrayObj)
//                                {
//                                    var result = SearchValue(arrayObj, targetValue, targetKey);
//                                    if (result != null)
//                                    {
//                                        return result;
//                                    }
//                                }
//                            }
//                        }
//                    /*else
//                    {
//                        // Recursively search other types of JTokens
//                        if (item is JObject)
//                        {
//                            var result = SearchValue(tokenObj, targetValue, targetKey);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }
//                    }*/
//                }
//            }

//            // Search by value
//            if (targetKey == null && targetValue != null)
//            {
//                foreach (var item in data.Properties())
//                {
//                    if (item.Value.ToString() == targetValue)
//                    {
//                        return item.Value;
//                    }
//                    if (item is JProperty prop)
//                    {
//                        // If the property value matches the target value, return the value
//                        if (prop.Value.ToString() == targetValue)
//                        {
//                            return prop.Value;
//                        }

//                        // Recurse into the property value if it's a JObject
//                        if (prop.Value is JObject childObj)
//                        {
//                            var result = SearchValue(childObj, targetValue, targetKey);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }

//                        // Recurse into arrays if the value is a JArray
//                        if (prop.Value is JArray childArray)
//                        {
//                            foreach (var token in childArray)
//                            {
//                                if (token is JObject arrayObj)
//                                {
//                                    var result = SearchValue(arrayObj, targetValue, targetKey);
//                                    if (result != null)
//                                    {
//                                        return result;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        // Recursively search other types of JTokens
//                            var result = SearchValue(item.Value as JObject, targetValue, targetKey);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                    }
//                }
//            }

//            if (targetValue != null && targetKey != null)
//            {
//                foreach (var item in data.Properties())
//                {
//                    if (item.Name == targetKey && item.Value.ToString() == targetKey)
//                    {
//                        return item;
//                    }
//                    else if (item.Children().Count() >= 1)
//                    {
//                        foreach (var child in item.Children())
//                        {
//                            if (child is JObject)
//                            {
//                                var tokenResult = SearchValue((JObject)child, targetValue, targetKey);
//                                if (tokenResult != null)
//                                {
//                                    return tokenResult;
//                                }
//                            }
//                            else if (item.Value is JArray)
//                            {

//                                foreach (var token in item.Value)
//                                {
//                                    if (token is JObject)
//                                    {
//                                        var arrayresult = SearchValue((JObject)token, targetValue, targetKey);
//                                        if (arrayresult != null)
//                                        {
//                                            return arrayresult;
//                                        }
//                                    }


//                                }
//                            }
//                            else if (item.Value is JToken)
//                            {
//                                if (item.Value is JValue)
//                                {

//                                    Console.WriteLine(item.Value);
//                                    continue;
//                                    Console.WriteLine();
//                                }
//                                Console.WriteLine();
//                                Console.WriteLine();
//                            }
//                            continue;
//                        }

//                    }
//                    else if (item.Value is not JObject && item.Value is not JArray && item.Value is not JProperty && item.Value is not JToken)
//                    {
//                        continue;
//                    }
//                    else if (item.Value is JArray)
//                    {

//                        foreach (var token in item.Value)
//                        {
//                            if (token is JObject)
//                            {
//                                var arrayresult = SearchValue((JObject)token, targetValue, targetKey);
//                                if (arrayresult != null)
//                                {
//                                    return arrayresult;
//                                }
//                            }


//                        }
//                    }
//                    else if (item.Value is JValue)
//                    {
//                        continue;
//                    }

//                    continue;

//                    }
//            }

//            // Return null if no match is found
//            return null;
//        }

//        public static Dictionary<string, object> JsonElementToDictionary(JsonElement element)
//        {
//            var dict = new Dictionary<string, object>();
//            foreach (var property in element.EnumerateObject())
//            {
//                dict.Add(property.Name, property.Value);
//            }
//            return dict;
//        }

//        // Method to recursively find a value by key
//        public static object FindValueByKey(Dictionary<string, object> data, string targetKey)
//        {
//            // If data is a dictionary, search through its key-value pairs
//            foreach (var kvp in data)
//            {
//                // If the key matches the target key, return the value
//                if (kvp.Key == targetKey)
//                {
//                    return (Dictionary<string, object>)kvp.Value;
//                }

//                // If the value is another dictionary or list, recursively search within it
//                /*if (kvp.Value is Dictionary<string, object> || kvp.Value is List<object>)
//                {
//                    var result = FindValueByKey(kvp.Value, targetKey);
//                    if (result != null)
//                    {
//                        return result;
//                    }
//                }*/
//            }

//            // If data is a list, iterate through each item
//            /*else if (data is List<object> list)
//            {
//                foreach (var item in list)
//                {
//                    var result = FindValueByKey(item, targetKey);
//                    if (result != null)
//                    {
//                        return result;
//                    }
//                }
//            }*/

//            // If no match is found, return null
//            return null;
//        }

//        // Method to find the grandparent container
//        public static object FindGrandparentContainer(object container, string targetKey, object targetValue)
//        {
//            // Helper method to perform the recursive search
//            Dictionary<string, object> Search(object currentContainer, Dictionary<string, object> parent = null, Dictionary<string, object> grandparent = null)
//            {
//                // If the container is a dictionary
//                if (currentContainer is Dictionary<string, object> dict)
//                {
//                    // Check if the dictionary contains the target key-value pair
//                    if (dict.ContainsKey(targetKey) && dict[targetKey].Equals(targetValue))
//                    {
//                        return grandparent;
//                    }

//                    // Recursively search through the dictionary's values
//                    foreach (var kvp in dict)
//                    {
//                        if (kvp.Value is Dictionary<string, object> || kvp.Value is List<object>)
//                        {
//                            var result = Search(kvp.Value, dict, parent);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }
//                    }
//                }
//                // If the container is a list
//                else if (currentContainer is List<object> list)
//                {
//                    // Recursively search through each item in the list
//                    foreach (var item in list)
//                    {
//                        if (item is Dictionary<string, object> || item is List<object>)
//                        {
//                            var result = Search(item, parent, grandparent);
//                            if (result != null)
//                            {
//                                return result;
//                            }
//                        }
//                    }
//                }

//                // Return null if no matching grandparent is found
//                return null;
//            }
//            // Start the recursive search
//            return Search(container);
//        }
//    }


//}
