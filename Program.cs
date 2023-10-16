using System.Collections;
using System.Runtime.InteropServices;

namespace note;

public class note
{
    static Notes memo_1 = new Notes("Пойти в колледж", "ОХ ЗРЯ Я ТУДА ПОЛЕЗ...", new DateTime (2023, 10, 16));
    static Notes memo_2 = new Notes("Пойти в магазин", "Куда делись продукты?", new DateTime (2023, 10, 14));
    static Notes memo_3 = new Notes("Помыть посуду", "Надо меньше жрать", new DateTime (2023, 10, 15));
    static Notes memo_4 = new Notes("Постирать шмотки", "Где я ходил, что они грязные?", new DateTime (2023, 10, 17));
    static Notes memo_5 = new Notes("Приготовить пожрать", "Рататуй be like)))", new DateTime (2023, 10, 18));
    static Notes memo_6 = new Notes("Сделать домашку", "Опять...", new DateTime (2023, 10, 18));
    static Notes memo_7 = new Notes("Помыть кошку", "Хватит срать!", new DateTime (2023, 10, 14));
    static Notes memo_8 = new Notes("Убраться в хате", "Нах ты её засрал???", new DateTime (2023, 10, 14));
    public static ConsoleKeyInfo key;
    public static List<Notes> AllNotes = new List<Notes>();
    public static List<Notes> DAYNotes;
    public static bool check = true;
    static DateTime Day = DateTime.Now;
    static int Position = 1;
    static void Main(string[] args)
    {
        DAYNotes = new List<Notes>();
        AllNotes.Add(memo_1);
        AllNotes.Add(memo_2);
        AllNotes.Add(memo_3);
        AllNotes.Add(memo_4);
        AllNotes.Add(memo_5);
        AllNotes.Add(memo_6);
        AllNotes.Add(memo_7);
        AllNotes.Add(memo_8);
        Start();
    }
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Выбрана дата: " + Day.ToString("D"));
        Print();
    }
    public static void Print()
    {
        int i = 1;
             
        foreach (Notes note in AllNotes) 
        {
            if (note.Data.Date == Day.Date)
            {
                Console.Write("  " + i + ". ");
                Console.WriteLine(note.Name);
                     
                DAYNotes.Add(note);
                i++;
            }
        }
    }
    public static void Cursor()
    {
        do
        {
            Console.SetCursorPosition(0, Position);
            Console.WriteLine("->");
            key = Console.ReadKey();
            Console.SetCursorPosition(0, Position);
            Console.WriteLine("  ");
            if (key.Key == ConsoleKey.UpArrow && Position != 1)
            {
                Position--;
            }
            else if (key.Key == ConsoleKey.DownArrow && Position != AllNotes.Count)
            {
                Position++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                DAYNotes = new List<Notes>();
                Day = Day.AddDays(-1);
                Menu();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                DAYNotes = new List<Notes>();
                Day = Day.AddDays(1);
                Menu();
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.SetCursorPosition(0, 8);
        Selection();
    }
    public static void Start()
    {
        Menu();
        note.Cursor();
    }
    
    public static void Selection()
    {
        if (AllNotes.Count > 0)
        {
            Information(DAYNotes[Position-1]);
        }
    }
    public static void Information(Notes note)
    {
        Console.Clear();
        Console.WriteLine("Название: " +note.Name + "\n" +"Описание: " +note.Text + "\n" + "Дата: " +note.Data);
        
        ConsoleKeyInfo key_2 = Console.ReadKey();
        if (key_2.Key == ConsoleKey.F1)    //escape govno ne workaet)))))
        {
            Start();
        }
        Console.ReadLine();
    }
}