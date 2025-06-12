using System;
using static System.Console;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Text.Json;

WriteLine("Введите своё имя: ");
int rnd;
string userName = ReadLine();
string choise;
string theme;
string[] words;
string searchWord = null;

WriteLine($"{userName}, приветствуем тебя в игре \"ВИСЕЛИЦА\"");
do
{
    WriteLine($"{userName}, ты хочешь продолжить игру? (да\\нет)");
    choise = ReadLine();
    if (choise == "нет")
    {
        WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {userName} был повешен.....\n");
        break;
    }
    else if (choise == "да")
    {
        do
        {
            WriteLine("Введи тему для игры (техника, одежда, животные)");
            theme = ReadLine();
            if (theme == "техника")
            {
                words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Techic.txt").Split();
                do
                {
                    rnd = new Random().Next(0, 9);
                } while (rnd % 2 != 0);
                searchWord = words[rnd];
            }
            else if (theme == "одежда")
            {
                words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Cloths.txt").Split();
                do
                {
                    rnd = new Random().Next(0, 9);
                } while (rnd % 2 != 0);
                searchWord = words[rnd];
            }
            else if (theme == "животные")
            {
                words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Animals.txt").Split();
                do
                {
                    rnd = new Random().Next(0, 9);
                } while (rnd % 2 != 0);
                searchWord = words[rnd];
            }
            else
            {
                WriteLine($"Введена неверная тема\n{userName}, повторите попытку\n");
            }
        } while (theme != "техника" && theme != "одежда" && theme != "животные");

        Game(searchWord);
    }
    else
    {
        WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {userName} был повешен.....\n");
        return;
    }
} while (true);

void Game(string searchWord)
{
    int size = searchWord.Length;
    int mistakes = 0;


    WriteLine(searchWord);
    Write("|");
    for (int i = 0; i < size; i++)
    {
        Write("_|");
    }
    WriteLine();

    char symbol;
    bool flag = false;
    List<char> listChar = new List<char>();
    bool breaker = false;


    do
    {
        WriteLine("Введите букву");
        symbol = Convert.ToChar(ReadLine());
        if (!listChar.Any())
        {
            foreach (var c in listChar)
            {

                if (c == symbol)
                {
                    WriteLine("Этот символ был введен ранее, введите новый: ");
                }
            }
        }
        listChar.Add(symbol);
    } while (true);
    char[] splitted = searchWord.ToCharArray();


    foreach (char c in splitted)
    {
        if (c == symbol)
        {
            flag = true;
        }

    }

    if (mistakes == 1)
    {
        WriteLine("     | \n");
        WriteLine("     | \n");
        WriteLine("    _|_");
    }
    else if (mistakes == 2)
    {
        WriteLine("         /| \n");
        WriteLine("        / | \n");
        WriteLine("    ___/ _|_");
    }
    else if (mistakes == 3)
    {
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 4)
    {
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 5)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 6)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 7)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine("  |       |       \n");
        WriteLine("  |       |       \n");
        WriteLine("  |       |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 8)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine(" /|       |       \n");
        WriteLine("/ |       |       \n");
        WriteLine("  |       |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 9)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine(" /|\\      |      \n");
        WriteLine("/ | \\     |      \n");
        WriteLine("  |       |       \n");
        WriteLine("          |       \n");
        WriteLine("          |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 10)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine(" /|\\      |      \n");
        WriteLine("/ | \\     |      \n");
        WriteLine("  |       |       \n");
        WriteLine(" /        |       \n");
        WriteLine("/         |       \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes > 10)
    {
        WriteLine("   _______        \n");
        WriteLine("  |       |       \n");
        WriteLine("  O       |       \n");
        WriteLine(" /|\\      |      \n");
        WriteLine("/ | \\     |      \n");
        WriteLine("  |       |       \n");
        WriteLine(" / \\      |      \n");
        WriteLine("/   \\     |      \n");
        WriteLine("         /|\\     \n");
        WriteLine("        / | \\    \n");
        WriteLine("    ___/ _|_ \\___");
    }
}