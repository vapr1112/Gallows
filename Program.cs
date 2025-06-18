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
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;



user user = new user();

WriteLine("Введите своё имя: ");

user.name = ReadLine();
int rnd;
string choise;
string theme;
string[] words;
string searchWord = null;
List<char> Word = new List<char>();
char symbol = ' ';
string str_symbol = null;
bool flag = false;
List<char> listChar = new List<char>();
bool checkWin = false, checkLose = false;
char[] splitted;

WriteLine($"{user.name}, приветствуем тебя в игре \"ВИСЕЛИЦА\"");
do
{
    WriteLine($"{user.name}, ты хочешь продолжить игру? (да\\нет)");
    choise = ReadLine();
    switch(choise)
    {
        case "нет":
            WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {user.name} был повешен.....\n");
            return;  
        case "да":
            themes_world();
            Game(searchWord);
            break;
        default:
            WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {user.name} был повешен.....\n");
            return; 
    }
    XmlSerializer serializer = new XmlSerializer(typeof(user));

    using (Stream fstream = File.Create("statistic.xml"))
    {
        serializer.Serialize(fstream, user);
    }

    using (Stream fstream = File.OpenRead("statistic.xml"))
    {
        user = (user)serializer.Deserialize(fstream);
    }

} while (true);

//функция с выбором темы слова
void themes_world()
{
    bool flag_is_find = false;
    search_themes themes_del = random_word;
    //словарь, в котором хранятся темы и пути к файлам (ключ, значение)
    var theme_paths = new Dictionary<string, string>()
    {
        ["техника"] = "C:\\Users\\User-PC\\source\\repos\\vapr1112\\Gallows\\Techic.txt",
        ["одежда"] = "C:\\Users\\User-PC\\source\\repos\\vapr1112\\Gallows\\Cloths.txt",
        ["животные"] = "C:\\Users\\302k12\\source\\repos\\ВыселицаБобра\\Animals.txt"
    };
    do
    {
        WriteLine("Введи тему для игры (техника, одежда, животные)");
        theme = ReadLine();
        foreach(string word_p in theme_paths.Keys)
        {
            if(word_p == theme)
            {
                //передаем путь к файлу в делегат
                themes_del(theme_paths[theme]);
                flag_is_find = true;
            }
        }
        //если флаг не true, то тема введена неверно
        if (!flag_is_find)
        {
            WriteLine($"Введена неверная тема\n{user.name}, повторите попытку\n");
        }
    } while (theme != "техника" && theme != "одежда" && theme != "животные");
}

//выбирается рандомное слово из файла
void random_word(string path)
{
    words = File.ReadAllText(path).Split();
    do
    {
        rnd = new Random().Next(0, 9);
    } while (rnd % 2 != 0);
    searchWord = words[rnd];
}

//игра
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
        WriteLine($"\nИгрок {user.name} был повешен.....\n");
        user.count_lose++;
    }
    else if (checkWin == true)
    {
        WriteLine($"\nИгрок {user.name} избежал повешания!!!!!\n");
        user.count_win++;
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

delegate void search_themes(string path);

public class user
{
    public string name {  get; set; }

    public int count_win {  get; set; }

    public int count_lose { get; set; }

    public user() { count_win = 0; count_lose = 0; }

    public user(string name_p, int count_win_p, int count_lose_p)
    {
        name = name_p;
        count_win = count_win_p;
        count_lose = count_lose_p;
    }

    public override string ToString()
    {
        return $"имя пользователя {name} количесво побед {count_win} количество поражений {count_lose}";
    }

    public void statictic()
    {
        WriteLine("статистика");
        WriteLine(ToString());
    }
}