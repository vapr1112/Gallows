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
        break;
    }
    WriteLine("Введи тему для игры (техника, одежда, животные)");
    theme = ReadLine();
    if (theme == "техника")
    {
        words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Techic.txt").Split();
        searchWord = words[new Random().Next(0, 9)];
    }
    else if (theme == "одежда")
    {
        words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Cloths.txt").Split();
        searchWord = words[new Random().Next(0, 9)];
    }
    else if (theme == "животные")
    {
        words = File.ReadAllText("C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Animals.txt").Split();
        searchWord = words[new Random().Next(0, 9)];
    }

    Game(searchWord); 
}while(true);

void Game(string searchWord)
{
    int size = searchWord.Length;
    WriteLine(searchWord);
    Write("|");
    for (int i = 0; i < size; i++)
    {
        Write("_|");
    }
    WriteLine();
}