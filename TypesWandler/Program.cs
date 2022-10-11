// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string types = File.ReadAllText("types.xml");
string massTypes = File.ReadAllText("massTypes.xml");
string expansionTypes = File.ReadAllText("expansion_types.xml");
string[] gunRarities = File.ReadAllLines("gunRarities.txt");
string[] ammoRarities = File.ReadAllLines("ammoRarities.txt");
string[] magRarities = File.ReadAllLines("magRarities.txt");

for (int i = 0; i < gunRarities.Length; i++)
{
    string pattern = "(.+) (.+) ([0-9]+)";
    Regex rg = new Regex(pattern);
    Match match = rg.Match(gunRarities[i]);
    if (match.Success)
    {
        string type = match.Groups[1].Value;
        string rarity = match.Groups[2].Value;
        int variants = int.Parse(match.Groups[3].Value);
        int nominal = 0;
        int min;
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



    }

}
/*
for (int i = 0; i < ammoRarities.Length; i++)
{

    string pattern = "(.+) (.+) ([0-9]+)";
    Regex rg = new Regex(pattern);
    Match match = rg.Match(ammoRarities[i]);
    if (match.Success)
    {
        string type = match.Groups[1].Value;
        string rarity = match.Groups[2].Value;
        int variants = int.Parse(match.Groups[3].Value);
        int nominal = 0;
        int min;
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



    }
}
*/
for (int i = 0; i < magRarities.Length; i++)
{

    string pattern = "(.+) (.+) ([0-9]+)";
    Regex rg = new Regex(pattern);
    Match match = rg.Match(magRarities[i]);
    if (match.Success)
    {
        string type = match.Groups[1].Value;
        string rarity = match.Groups[2].Value;
        int variants = int.Parse(match.Groups[3].Value);
        int nominal = 0;
        int min;
        switch (rarity)
        {
            case "common":
                nominal = 160 / variants;
                break;

            case "uncommon":
                nominal = 80 / variants;
                break;

            case "rare":
                nominal = 40 / variants;
                break;

            case "epic":
                nominal = 20 / variants;
                break;

            case "legendary":
                nominal = 10 / variants;
                break;

        }
        min = nominal / 2;



    }
}
