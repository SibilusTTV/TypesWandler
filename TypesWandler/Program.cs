// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string types;
string massTypes;
string expansionTypes;
Main();


void Main()
{
    types = File.ReadAllText("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\types.xml");
    massTypes = File.ReadAllText("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\massTypes.xml");
    expansionTypes = File.ReadAllText("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\expansion_types.xml");
    string[] gunRarities = File.ReadAllLines("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\gunRarities.txt");
    // string[] ammoRarities = File.ReadAllLines("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\ammoRarities.txt");
    // string[] magRarities = File.ReadAllLines("C:\\Users\\julian.pfeiff\\source\\repos\\TypesWandler\\magRarities.txt");
    string patternRarities = "(.+) (.+) ([0-9]+)";
    string patternTypes1 = "[^\\n]*<type name=\"";
    string patternTypes2 = "\">[\\s\\S]*?\\s*<\\/type>";
    SetGunRarities(patternRarities, gunRarities, patternTypes1, patternTypes2);
    // SetMagRarities(patternRarities, magRarities, patternTypes1, patternTypes2);
}

void SetGunRarities(string pattern, string[] gunRarities, string patternTypes1, string patternTypes2)
{
    Regex rg = new Regex(pattern);
    foreach (string gunRarity in gunRarities)
    {
        Match match = rg.Match(gunRarity);
        if (match.Success)
        {
            string type = match.Groups[1].Value;
            string rarity = match.Groups[2].Value;
            int variants = int.Parse(match.Groups[3].Value);
            int nominal = 0;
            int min;
            int buy;
            int sell;
            switch (rarity)
            {
                case "common":
                    nominal = 80 / variants;
                    break;

                case "uncommon":
                    nominal = 40 / variants;
                    break;

                case "rare":
                    nominal = 20 / variants;
                    break;

                case "epic":
                    nominal = 10 / variants;
                    break;

                case "legendary":
                    nominal = 5 / variants;
                    break;

            }
            min = nominal / 2;

            string patternTypes = patternTypes1 + type + patternTypes2;

            string item = SearchInTypes(patternTypes, types);

            if (item != null)
            {
                string newItem = ReplaceValues(item, nominal, min);
                Console.WriteLine(newItem);
            }
            else
            {
                item = SearchInTypes(patternTypes, expansionTypes);
                if (item != null)
                {
                    string newItem = ReplaceValues(item, nominal, min);
                }
                else
                {
                    item = SearchInTypes(patternTypes, massTypes);
                    if (item != null)
                    {
                        string newItem = ReplaceValues(item, nominal, min);
                    }
                }
            }
        }
    }
}
void SetMagRarities(string pattern, string[] magRarities, string patternTypes1, string patternTypes2)
{
    Regex rg = new Regex(pattern);
    for (int i = 0; i < magRarities.Length; i++)
    {
        
    }
}

string SearchInTypes(string pattern, string types)
{
    Regex rg = new Regex(pattern);

    Match match = rg.Match(types);

    if (match.Success)
    {
        return match.Groups[0].Value;
    }
    else
    {
        return null;
    }
}

string ReplaceValues(string item, int nominal, int min)
{
    Regex rgN = new Regex("[^\\n\\S]*<nominal>([0-9]+)<\\/nominal>");
    Match matchN = rgN.Match(item);
    if (matchN.Success)
    {
        string newNominal = matchN.Groups[0].Value.Replace(matchN.Groups[1].Value, nominal.ToString());
        item = item.Replace(matchN.Groups[0].Value, newNominal);
    }

    Regex rgM = new Regex("[^\\n\\S]*<min>([0-9]+)<\\/min>");
    Match matchM = rgM.Match(item);
    if (matchM.Success)
    {
        string newMin = matchM.Groups[0].Value.Replace(matchM.Groups[1].Value, min.ToString());
        item = item.Replace(matchM.Groups[0].Value, newMin);
    }

    return item;
}
