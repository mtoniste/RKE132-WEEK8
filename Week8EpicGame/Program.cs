//string[] heroes = { "Spongebob", "Lara Croft", "Black Panther", "Martin Toniste", "Austrian Painter" };
//string[] villains = { "Mustache Guy", "The Devil", "Joker", "Putin", "Kaja Kallas" };

using System.Security.AccessControl;

string folderPath = @"C:\Users\PC\Desktop\Julia aine\Week5\Week8EpicGame";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "fists", "minigun", "kfc chicken", "comically large spoon", "love for your enemies" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrike = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}) saves the day with a {heroWeapon}!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrike = villainHP;
Console.WriteLine($"Today {villain} ({villainHP}) tries to take over the world using {villainWeapon}.");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrike);
    villainHP = villainHP - Hit(hero, heroStrike);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine("Evil prevails...");
}
else
{
    Console.WriteLine("Combatants settle for a draw.");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rand = new Random();
    int randomIndex = rand.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rand = new Random();
    int strike = rand.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target.");
    }
    else if(strike == characterHP -1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }

    return strike;
}