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
using System.Reflection.Metadata.Ecma335;

WriteLine("Введите своё имя: ");
int rnd;
string userName = ReadLine();
string choise;
string theme;
string[] words;
string searchWord = null;
List<char> Word = new List<char>();
char symbol = ' ';
string str_symbol = null;
bool flag = false;
List<char> listChar = new List<char>();
bool breaker = false;
bool checkWin = false, checkLose = false;
char[] splitted;


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
                words = File.ReadAllText("C:\\Users\\User-PC\\source\\repos\\vapr1112\\Gallows\\Techic.txt").Split();
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
    int mistakes = 0;
    Word.Add('|');
    for (int i = 0; i < searchWord.Length; i++)
    {
        Word.Add('_');
        Word.Add('|');
    }
    splitted = searchWord.ToCharArray();

    WriteLine(searchWord);
    Write("|");
    for (int i = 0; i < searchWord.Length; i++)
    {
        Write("_|");
    }


    do
    {
        do
        {
            WriteLine("\nВведите букву");
            str_symbol = ReadLine();
        } while (str_symbol.Length != 1);

        symbol = str_symbol[0];

        bool ocherednoiFLAG = fun_flag();

        for (int i = 0; i < splitted.Length; i++)
        {
            char c = splitted[i];

            if (c == symbol)
            {
                flag = true;
                PrintWord(searchWord, c, i);
                for (int j = i; j < splitted.Length; j++)
                {
                    c = splitted[j];
                    if (c == symbol)
                    {
                        PrintWord(searchWord, c, j);
                    }
                }
                foreach (var symb in Word)
                {
                    Write(symb);
                }
                break;
            }
            else
            {
                flag = false;
            }
        }

        if (Word.IndexOf('_') == -1)
        {
            checkWin = true;
            break;
        }
        if (flag == false)
        {
            if (!ocherednoiFLAG)
            {
                mistakes++;
            }
        }
        if (mistakes >= 10)
        {
            checkLose = true;
        }
        
        listChar.Add(symbol);
        if(PrintVISELICA(mistakes))
        {
            break;
        }
    } while (checkWin != true);
    if (checkLose == true)
    {
        WriteLine($"\nИгрок {userName} был повешен.....\n");
    }
    else if (checkWin == true)
    {
        WriteLine($"\nИгрок {userName} избежал повешания!!!!!\n");
    }
}

void PrintWord(string searchWord, char c, int i)
{
    Word[i * 2 + 1] = c;
}

bool fun_flag()
{
    if (listChar.Any())
    {
        foreach (var c in listChar)
        {
            if (c == symbol)
            {
                WriteLine("Этот символ был введен ранее, введите новый: ");
                return true;
            }
        }
    }

    if(symbol < 1072 || symbol > 1103)
    {
        WriteLine("введите русскую строчную букву!");
        return true;
    }

    return false;
}

bool PrintVISELICA(int mistakes)
{
    if (mistakes == 1)
    {
        WriteLine("\n     | ");
        WriteLine("     | ");
        WriteLine("    _|_");
    }
    else if (mistakes == 2)
    {
        WriteLine("\n         /| ");
        WriteLine("        / | ");
        WriteLine("    ___/ _|_");
    }
    else if (mistakes == 3)
    {
        WriteLine("\n         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 4)
    {
        WriteLine("\n         |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 5)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 6)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("  O       |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 7)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("  O       |       ");
        WriteLine("  |       |       ");
        WriteLine("  |       |       ");
        WriteLine("  |       |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 8)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("  O       |       ");
        WriteLine(" /|       |       ");
        WriteLine("/ |       |       ");
        WriteLine("  |       |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 9)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("  O       |       ");
        WriteLine(" /|\\     |      ");
        WriteLine("/ | \\    |      ");
        WriteLine("  |       |       ");
        WriteLine("          |       ");
        WriteLine("          |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes == 10)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |       |       ");
        WriteLine("  O       |       ");
        WriteLine(" /|\\     |      ");
        WriteLine("/ | \\    |      ");
        WriteLine("  |       |       ");
        WriteLine(" /        |       ");
        WriteLine("/         |       ");
        WriteLine("         /|\\     ");
        WriteLine("        / | \\    ");
        WriteLine("    ___/ _|_ \\___");
    }
    else if (mistakes > 10)
    {
        WriteLine("\n   _______        ");
        WriteLine("  |        |      ");
        WriteLine("  O        |      ");
        WriteLine(" /|\\      |      ");
        WriteLine("/ | \\     |      ");
        WriteLine("  |        |      ");
        WriteLine(" / \\      |      ");
        WriteLine("/   \\     |      ");
        WriteLine("          /|\\     ");
        WriteLine("         / | \\    ");
        WriteLine("     ___/ _|_ \\___");
        return true;
    }

    return false;
}