using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace StyleWeaver
{
    class FileManagement
    {
        public static string folderPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop"), "StyleWeaver");

        public static string colorFilePath = "colors.txt";
        public static string fontFilePath = "fonts.txt";
        public static string imageFolderPath = "Assets";

        public FileManagement()
        {
            // Create folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Folder 'StyleWeaver' created at: {folderPath}");
                if (!Directory.Exists(folderPath + imageFolderPath))
                    Directory.CreateDirectory(folderPath + "\\" + imageFolderPath);
                Console.WriteLine($"Folder 'Assets' created at: {folderPath}{imageFolderPath}");
                colorFilePath = Path.Combine(folderPath, "colors.txt");
                fontFilePath = Path.Combine(folderPath, "fonts.txt");

                // Create and write default data to colors.txt
                using (StreamWriter writer = new StreamWriter(colorFilePath))
                {
                    writer.WriteLine(@"
                    :root {
                        --buttons: **--buttons**;
                        --primary: **--primary**;
                        --secondary: **--secondary**;
                        --text: **--text**;
                        --link: **--link**;
                        --main-bg: **--main-bg**;
                        --inner-bg: **--inner-bg**;
                        --accent-bg: **--accent**;
                        --primary-alt: **--primary-alt**;
                        --secondary-alt: **--secondary-alt**;
                        --text-alt: **--text-alt**;
                        --link-alt: **--link-alt**;
                        --main-bg-alt: **--main-bg-alt**;
                        --inner-bg-alt: **--inner-bg-alt**;
                        --accent-bg-alt: **--accent-alt**;
                    }
                ");
                }
                // Create and write default data to fonts.txt
                using (StreamWriter writer = new StreamWriter(fontFilePath))
                {
                    writer.WriteLine(@"
                    :root {
                        --fnt-t: ""**--fnt-t**"", sans-serif;
                        --fnt-m: ""**--fnt-m**"", sans-serif;

                        --fnt-t-big-ff: **Title Big fontFamily**; /* { friendly: 'Title Big Font Family' } */
                        --fnt-t-big-ls: **Title Big letterSpacing**em; /* { min: **Title Big letterSpacing Min**, max: **Title Big letterSpacing Max**, step: **Title Big letterSpacing Step**, friendly: 'Title Big Letter Spacing' } */
                        --fnt-t-big-w: **Title Big fontWeight**; /* { friendly: 'Title Big Font Weight' } */
                        --fnt-t-big-tt: **Title Big textCase**; /* { friendly: 'Title Big Case' } */
                        
                        --fnt-t-co-ff: **Callout fontFamily**; /* { friendly: 'Callout Font Family' } */
                        --fnt-t-co-ls: **Callout letterSpacing**em; /* { min: **Callout letterSpacing Min**, max: **Callout letterSpacing Max**, step: **Callout letterSpacing Step**, friendly: 'Callout Letter Spacing' } */
                        --fnt-t-co-w: **Callout fontWeight**; /* { friendly: 'Callout Font Weight' } */
                        --fnt-t-co-tt: **Callout textCase**; /* { friendly: 'Callout Case' } */
                    
                        --fnt-t-k-ff: **Kicker fontFamily**; /* { friendly: 'Header Kicker Font Family' } */
                        --fnt-t-k-ls: **Kicker letterSpacing**em; /* { min: **Kicker letterSpacing Min**, max: **Kicker letterSpacing Max**, step: **Kicker letterSpacing Step**, friendly: 'Header Kicker Letter Spacing' } */
                        --fnt-t-k-w: **Kicker fontWeight**; /* { friendly: 'Header Kicker Font Weight' } */
                        --fnt-t-k-tt: **Kicker textCase**; /* { friendly: 'Header Kicker Case' } */
                    
                        --fnt-t-1-ff: **Title 1 fontFamily**; /* { friendly: 'Title 1 Font Family' } */
                        --fnt-t-1-ls: **Title 1 letterSpacing**em; /* { min: **Title 1 letterSpacing Min**, max: **Title 1 letterSpacing Max**, step: **Title 1 letterSpacing Step**, friendly: 'Title 1 Letter Spacing' } */
                        --fnt-t-1-w: **Title 1 fontWeight**; /* { friendly: 'Title 1 Font Weight' } */
                        --fnt-t-1-tt: **Title 1 textCase**; /* { friendly: 'Title 1 Case' } */
                    
                        --fnt-t-2-ff: **Title 2 fontFamily**; /* { friendly: 'Title 2 Font Family' } */
                        --fnt-t-2-ls: **Title 2 letterSpacing**em; /* { min: **Title 2 letterSpacing Min**, max: **Title 2 letterSpacing Max**, step: **Title 2 letterSpacing Step**, friendly: 'Title 2 Letter Spacing' } */
                        --fnt-t-2-w: **Title 2 fontWeight**; /* { friendly: 'Title 2 Font Weight' } */
                        --fnt-t-2-tt: **Title 2 textCase**; /* { friendly: 'Title 2 Case' } */
                    
                        --fnt-t-3-ff: **Title 3 fontFamily**; /* { friendly: 'Title 3 Font Family' } */
                        --fnt-t-3-ls: **Title 3 letterSpacing**em; /* { min: **Title 3 letterSpacing Min**, max: **Title 3 letterSpacing Max**, step: **Title 3 letterSpacing Step**, friendly: 'Title 3 Letter Spacing' } */
                        --fnt-t-3-w: **Title 3 fontWeight**; /* { friendly: 'Title 3 Font Weight' } */
                        --fnt-t-3-tt: **Title 3 textCase**; /* { friendly: 'Title 3 Case' } */
                    
                        --fnt-t-4-ff: **Title 4 fontFamily**; /* { friendly: 'Title 4 Font Family' } */
                        --fnt-t-4-ls: **Title 4 letterSpacing**em; /* { min: **Title 4 letterSpacing Min**, max: **Title 4 letterSpacing Max**, step: **Title 4 letterSpacing Step**, friendly: 'Title 4 Letter Spacing' } */
                        --fnt-t-4-w: **Title 4 fontWeight**; /* { friendly: 'Title 4 Font Weight' } */
                        --fnt-t-4-tt: **Title 4 textCase**; /* { friendly: 'Title 4 Case' } */
                    
                        --fnt-t-5-ff: **Title 5 fontFamily**; /* { friendly: 'Title 5 Font Family' } */
                        --fnt-t-5-ls: **Title 5 letterSpacing**em; /* { min: **Title 6 letterSpacing Min**, max: **Title 6 letterSpacing Max**, step: **Title 5 letterSpacing Step**, friendly: 'Title 5 Letter Spacing' } */
                        --fnt-t-5-w: **Title 5 fontWeight**; /* { friendly: 'Title 5 Font Weight' } */
                        --fnt-t-5-tt: **Title 5 textCase**; /* { friendly: 'Title 5 Case' } */
                    
                        --fnt-t-6-ff: **Title 6 fontFamily**; /* { friendly: 'Title 6 Font Family' } */
                        --fnt-t-6-ls: **Title 6 letterSpacing**em; /* { min: **Title 6 letterSpacing Min**, max: **Title 6 letterSpacing Max**, step: **Title 6 letterSpacing Step**, friendly: 'Title 6 Letter Spacing' } */
                        --fnt-t-6-w: **Title 6 fontWeight**; /* { friendly: 'Title 6 Font Weight' } */
                        --fnt-t-6-tt: **Title 6 textCase**; /* { friendly: 'Title 6 Case' } */
                        
                        --fnt-nv-pry-ff: **Primary Nav Link fontFamily**; /* { friendly: 'Top Nav Link Font Family' } */
                        --fnt-nv-pry-ls: **Primary Nav Link letterSpacing**em; /* { min: **Primary Nav Link letterSpacing Min**, max: **Primary Nav Link letterSpacing Max**, step: **Primary Nav Link letterSpacing Step**, friendly: 'Top Nav Link Letter Spacing' } */
                        --fnt-nv-pry-w: **Primary Nav Link fontWeight**; /* { friendly: 'Top Nav Link Font Weight' } */
                        --fnt-nv-pry-tt: **Primary Nav Link textCase**; /* { friendly: 'Top Nav Link Case' } */	
                        --fnt-nv-pry-fs: **Primary Nav Link italic**; /* { friendly: 'Top Nav Link Style' } */
                        
                        --fnt-nv-sec-ff: **Secondary Nav fontFamily**; /* { friendly: 'Secondary Nav Link Font Family' } */
                        --fnt-nv-sec-ls: **Secondary Nav letterSpacing**em; /* { min: **Secondary Nav letterSpacing Min**, max: **Secondary Nav letterSpacing Max**, step: **Secondary Nav letterSpacing Step**, friendly: 'Secondary Nav Link Letter Spacing' } */
                        --fnt-nv-sec-w: **Secondary Nav fontWeight**; /* { friendly: 'Secondary Nav Link Font Weight' } */
                        --fnt-nv-sec-tt: **Secondary Nav textCase**; /* { friendly: 'Secondary Nav Link Case' } */	
                        --fnt-nv-sec-fs: **Secondary Nav italic**; /* { friendly: 'Secondary Nav Link Style' } */

                        --fnt-qte-ff: **Quote fontFamily**; /* { friendly: 'Quote Font Family' } */
                        --fnt-qte-ls: **Quote letterSpacing**em; /* { min: **Quote letterSpacing Min**, max: **Quote letterSpacing Max**, step: **Quote letterSpacing Step**, friendly: 'Quote Letter Spacing' } */
                        --fnt-qte-w: **Quote fontWeight**; /* { friendly: 'Quote Font Weight' } */
                        --fnt-qte-tt: **Quote textCase**; /* { friendly: 'Quote Case' } */
                        --fnt-qte-fs: **Quote italic**; /* { friendly: 'Quote Font Style' } */
                        
                        --fnt-atr-ff: **Author Name fontFamily**; /* { friendly: 'Author Name Font Family' } */
                        --fnt-atr-ls: **Author Name letterSpacing**em; /* { min: **Author Name letterSpacing Min**, max: **Author Name letterSpacing Max**, step: **Author Name letterSpacing Step**, friendly: 'Author Name Letter Spacing' } */
                        --fnt-atr-w: **Author Name fontWeight**; /* { friendly: 'Author Name Font Weight' } */
                        --fnt-atr-tt: **Author Name textCase**; /* { friendly: 'Author Name Case' } */
                        --fnt-atr-fs: **Author Name italic**; /* { friendly: 'Author Name Font Style' } */
                    
                        --fnt-phn-ff: **Phone Number fontFamily**; /* { friendly: 'Phone Font Family' } */
                        --fnt-phn-ls: **Phone Number letterSpacing**em; /* { min: **Phone Number letterSpacing Min**, max: **Phone Number letterSpacing Max**, step: **Phone Number letterSpacing Step**, friendly: 'Phone Letter Spacing' } */
                        --fnt-phn-w: **Phone Number fontWeight**; /* { friendly: 'Phone Font Weight' } */

                        --fnt-t-itm-ff: **Item fontFamily**; /* { friendly: 'Item Title Font Family' } */
	                --fnt-t-itm-ls: **Item letterSpacing**em; /* { min: **Item letterSpacing Min**, max: **Item letterSpacing Max**, step: **Item letterSpacing Step**, friendly: 'Item Title Letter Spacing' } */
	                --fnt-t-itm-w: **Item fontWeight**; /* { friendly: 'Item Title Font Weight' } */
	                --fnt-t-itm-tt: **Item textCase**; /* { friendly: 'Item Title Case' } */
	
	                --fnt-t-nt-ff: **Note fontFamily**; /* { friendly: 'Note Font Family' } */
	                --fnt-t-nt-ls: **Note letterSpacing**em; /* { min: **Note letterSpacing Min**, max: **Note letterSpacing Max**, step: **Note letterSpacing Step**, friendly: 'Note Letter Spacing' } */
	                --fnt-t-nt-w: **Note fontWeight**; /* { friendly: 'Note Font Weight' } */
	                --fnt-t-nt-tt: **Note textCase**; /* { friendly: 'Note Case' } */

                        --tag-ff: **Tag fontFamily**; /* { friendly: 'Tag Font Family' } */
                        --tag-ls: **Tag letterSpacing**em; /* { min: **Tag letterSpacing Min**, max: **Tag letterSpacing Max**, step: **Tag letterSpacing Step**, friendly: 'Tag Letter Spacing' } */
                        --tag-w: **Tag fontWeight**; /* { friendly: 'Tag Font Weight' } */
                        --tag-tt: **Tag textCase**; /* { friendly: 'Tag Case' } */
                    
                        --btn-v1-ff: **Button text fontFamily**; /* { friendly: 'Button V1 Font Family' } */
                        --btn-v1-ls: **Button text letterSpacing**em; /* { min: **Button text letterSpacing Min**, max: **Button text letterSpacing Max**, step: **Button text letterSpacing Step**, friendly: 'Button V1 Letter Spacing' } */
                        --btn-v1-w: **Button text fontWeight**; /* { friendly: 'Button V1 Font Weight' } */
                        --btn-v1-tt: **Button text textCase**; /* { friendly: 'Button V1 Case' } */
                    
                        --btn-v2-ff: **Button text fontFamily**; /* { friendly: 'Button V2 Font Family' } */
                        --btn-v2-ls: **Button text letterSpacing**em; /* { min: **Button text letterSpacing Min**, max: **Button text letterSpacing Max**, step: **Button text letterSpacing Step**, friendly: 'Button V2 Letter Spacing' } */
                        --btn-v2-w: **Button text fontWeight**; /* { friendly: 'Button V2 Font Weight' } */
                        --btn-v2-tt: **Button text textCase**; /* { friendly: 'Button V2 Case' } */
                    
                        --fnt-frm-ff: **Form Label fontFamily**; /* { friendly: 'Form Label Font Family' } */
                        --fnt-frm-ls: **Form Label letterSpacing**em; /* { min: **Form Label letterSpacing Min**, max: **Form Label letterSpacing Max**, step: **Form Label letterSpacing Step**, friendly: 'Form Label Letter Spacing' } */
                        --fnt-frm-w: **Form Label fontWeight**; /* { friendly: 'Form Label Font Weight' } */
                        --fnt-frm-tt: **Form Label textCase**; /* { friendly: 'Form Label Case' } */
                    }
                ");
                }
            }

            Fonts.fontStyles = CleanData(Fonts.fontStyles);
            ApplyReplacements(Fonts.fontStyles, "fonts.txt");
            ApplyReplacements(ColorsSW.allColors, "colors.txt");
        }

        public static Dictionary<string, string> CleanData(Dictionary<string, string> inputDict)
        {

            var tempDict = new Dictionary<string, string>();

            var fnt_t = inputDict["Title Big fontFamily"];
            object fnt_m = string.Empty;

            var baseFont = float.Parse(inputDict["Paragraph fontSize"].ToString());

            var bufferDict = GetFontFamily(inputDict);

            foreach (var kvp in bufferDict)
            {
                if (kvp.Value.ToString() != fnt_t)
                {
                    fnt_m = kvp.Value.ToString();
                }
            }
            if (string.IsNullOrEmpty(fnt_m.ToString()))
            {
                fnt_m = fnt_t;
            }
            foreach (var kvp in inputDict)
            {
                switch (kvp.Key)
                {
                    case var key when key.Contains("textCase"):
                        switch (kvp.Value)
                        {
                            case "UPPER":
                                inputDict[kvp.Key] = "uppercase";
                                break;
                            case "TITLE":
                                inputDict[kvp.Key] = "capitalize";
                                break;
                            case "LOWER":
                                inputDict[kvp.Key] = "lowercase";
                                break;
                            case "":
                                inputDict[kvp.Key] = "none";
                                break;
                        }
                        break;

                    case var key when key.Contains("italic"):
                        switch (kvp.Value)
                        {
                            case "":
                                inputDict[kvp.Key] = "normal";
                                break;
                            case "True":
                                inputDict[kvp.Key] = "italic";
                                break;
                        }
                        break;

                    case var key when key.Contains("fontFamily"):
                        if (kvp.Value.ToString() == fnt_t)
                        {
                            inputDict[kvp.Key] = "var(--fnt-t)";
                        }
                        else
                        {
                            inputDict[kvp.Key] = "var(--fnt-m)";
                        }
                        break;

                    case var key when key.Contains("letterSpacing"):
                        float letterSpacing = float.Parse(inputDict[kvp.Key]);
                        var remValue = (Math.Round(letterSpacing / baseFont, 2)).ToString();
                        inputDict[kvp.Key] = remValue;

                        if (inputDict[kvp.Key].ToString() == "0")
                        {
                            tempDict[key + " Min"] = "-0.5";
                            tempDict[key + " Max"] = "0.5";
                            tempDict[key + " Step"] = ".01";
                        }
                        else
                        {
                            tempDict[key + " Min"] = Math.Round(letterSpacing - (2 * letterSpacing), 2).ToString();
                            tempDict[key + " Max"] = Math.Round(letterSpacing + (2 * letterSpacing), 2).ToString();
                            tempDict[key + " Step"] = GetStepValue(inputDict[kvp.Key]);
                        }
                        break;
                }
            }

            inputDict["--fnt-t"] = fnt_t;
            inputDict["--fnt-m"] = fnt_m.ToString();
            foreach (var item in tempDict)
            {
                inputDict[item.Key] = item.Value;
            }

            return inputDict;
        }

        public static Dictionary<string, string> GetFontFamily(Dictionary<string, string> inputDict)
        {
            Dictionary<string, string> bufferDict = new Dictionary<string, string>();

            foreach (var item in inputDict)
            {
                if (item.Key.Contains("fontFamily"))
                {
                    bufferDict.Add(item.Key, item.Value.ToString());
                }
            }

            return bufferDict;
        }

        public static string GetStepValue(string value)
        {
            if (value.Contains("."))
            {
                var splitStr = value.Split('.', 2);
                if (splitStr.Length > 1 && splitStr[1].Length > 1)
                {
                    return ".01";
                }
                return ".1";
            }

            return ".1";
        }

        public static string ReplaceTokens(Match match, Dictionary<string, string> inputDict)
        {
            var key = match.Groups[1].Value;
            return inputDict.ContainsKey(key) ? inputDict[key].ToString() : match.Groups[0].Value;
        }

        public static void ApplyReplacements(Dictionary<string, string> inputDict, string fileName)
        {
            string filePath = Path.Combine(folderPath, fileName);

            string content;
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
            }

            string updatedContent = Regex.Replace(content, @"\*\*(.*?)\*\*", match => ReplaceTokens(match, inputDict));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(updatedContent);
            }

            Console.WriteLine($"Tokens replaced and saved to: {filePath}");
        }
    }
}
