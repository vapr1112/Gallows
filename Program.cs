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
game game = new game();
work_with_words word = new work_with_words();

string theme = null;
string choise;


WriteLine("Введите своё имя: ");

user.name = ReadLine();

WriteLine($"{user.name}, приветствуем тебя в игре \"ВИСЕЛИЦА\"");
do
{
    WriteLine($"{user.name}, ты хочешь продолжить игру? (да\\нет)");
    choise = ReadLine();
    switch (choise)
    {
        case "нет":
            WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {user.name} был повешен.....\n");
            return;
        case "да":
            word.themes_world(theme, user);
            Game(word.searchWord);
            break;
        default:
            WriteLine($"Вы ошиблись......\nЭто была ваша последняя попытка......\nИгрок {user.name} был повешен.....\n");
            return;
    }

    word.Word.Clear();
    word.listChar.Clear();

} while (true);

//игра
void Game(string searchWord)
{
    word.change_world();

    word.splitted = searchWord.ToCharArray();

    WriteLine(searchWord);//убрать потом

    word.print();

    do
    {
        word.input();

        if (word.flag == false)
        {
            if (!word.ocherednoiFLAG)
            {
                game.mistakes++;
            }
        }

        game.PrintVISELICA();

    } while (game.check_result(word, user) == 0);

    game.output_event(user);

    game.save_in_file(user);
    game.load_from_file(user);
}

delegate void search_themes(string path);

delegate void del_result(user user);

class game
{
    XmlSerializer serializer = new XmlSerializer(typeof(user));

    public event del_result? result;

    public int mistakes { get; set; }

    public bool checkWin {  get; set; }
    public bool checkLose {  get; set; }

    public string message {  get; set; }

    public game() { mistakes = 0; checkWin = false; checkLose = false; }

    public int check_result(work_with_words word, user user)
    {
        if (mistakes > 10)
        {
            checkLose = true;
            result += print_lose;
            message = $"\nИгрок {user.name} был повешен.....\n";
            return 3;
        }
        if (word.Word.IndexOf('_') == -1)
        {
            checkWin = true;
            result = print_win;
            message = $"\nИгрок {user.name} избежал повешания!!!!!\n";
            return 5;
        }

        return 0;
    }

    public void print_win(user user)
    {
        WriteLine(message);
        user.count_win++;
    }

    public void print_lose(user user_p)
    {
        WriteLine(message);
        user_p.count_lose++;
    }

    public void output_event(user user_p)
    {
        result?.Invoke(user_p);
    }
    public void save_in_file(user user)
    {
        using (Stream fstream = File.Create("statistic.xml"))
        {


            serializer.Serialize(fstream, user);
        }
    }

    public void load_from_file(user user)
    {
        using (Stream fstream = File.OpenRead("statistic.xml"))
        {
            user = (user)serializer.Deserialize(fstream);
        }
    }

    public void PrintVISELICA()
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
        }
    }


}

public class user
{
    public string name { get; set; }

    public int count_win { get; set; }

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

class work_with_words
{
    //флаг для определения, есть ли буква в слове или нет
    public bool flag {  get; set; }
    public bool ocherednoiFLAG { get; set; }
    public char symbol {  get; set; }
    //ввод строки, потом присваивается символу
    string str_symbol { get; set; }
    //массив слов из файла
    public string[] words { get; set; }

    //искомое слово
    public string searchWord { get; set; }
    //слово в которое будут записывться нацденные буквы. Вначале содержит | и _
    public List<char> Word {  get; set; }
    //массив символов, которые уже ввели
    public List<char> listChar {  get; set; }
    //массив символов из искомого слова
    public char[] splitted { get; set; }

    public work_with_words() { searchWord = null; Word = new List<char>(); symbol = ' '; str_symbol = null; flag = false; listChar = new List<char>(); }

    //метод с выбором темы слова
    public void themes_world(string theme, user user)
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
            foreach (string word_p in theme_paths.Keys)
            {
                if (word_p == theme)
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
        int rnd;
        words = File.ReadAllText(path).Split();
        do
        {
            rnd = new Random().Next(0, 9);
        } while (rnd % 2 != 0);
        searchWord = words[rnd];
    }

    public void input()
    {
        do
        {
            WriteLine("\nВведите букву");
            str_symbol = ReadLine();
        } while (str_symbol.Length != 1);

        symbol = str_symbol[0];

        ocherednoiFLAG = fun_flag();

        for (int i = 0; i < splitted.Length; i++)
        {
            char c = splitted[i];

            if (c == symbol)
            {
                flag = true;
                index_symbol(searchWord, c, i);
                for (int j = i; j < splitted.Length; j++)
                {
                    c = splitted[j];
                    if (c == symbol)
                    {
                        index_symbol(searchWord, c, j);
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

            listChar.Add(symbol);
        }
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

        if (symbol < 1072 || symbol > 1103)
        {
            WriteLine("введите русскую строчную букву!");
            return true;
        }

        return false;
    }

    void index_symbol(string searchWord, char c, int i)
    {
        Word[i * 2 + 1] = c;
    }

    //вывод пустого слова
    public void change_world()
    {
        Word.Add('|');
        for (int i = 0; i < searchWord.Length; i++)
        {
            Word.Add('_');
            Word.Add('|');
        }
    }

    //вывод
    public void print()
    {
        Write("|");
        for (int i = 0; i < searchWord.Length; i++)
        {
            Write("_|");
        }
    }
}