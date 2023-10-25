using System;
using System.Collections.Generic;

namespace DailyPlanner
{
    class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public Note(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
            DueDate = date;
        }
    }

    class Program
    {
        static List<Note> notes;
        static int currentIndex;

        static void Main(string[] args)
        {
            InitializeNotes();

            ConsoleKeyInfo key;
            do
            {
                PrintMenu();

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveToPreviousDate();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveToNextDate();
                        break;
                    case ConsoleKey.Enter:
                        DisplayNoteInfo();
                        break;
                    case ConsoleKey.Q:
                        AddNote();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }

        static void InitializeNotes()
        {
            notes = new List<Note>()
            {
                new Note("Заметка 1", "Описание 1", new DateTime(2023, 10, 5)),
                new Note("Заметка 2", "Описание 2", new DateTime(2023, 9, 6)),
                new Note("Заметка 3", "Описание 3", new DateTime(2023, 5, 31)),
                new Note("Заметка 4", "Описание 4", new DateTime(2023, 7, 4)),
                new Note("Заметка 5", "Описание 5", new DateTime(2023, 7, 10))
            };

            currentIndex = 0;
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Ежедневник");
            Console.WriteLine("------------");
            Console.WriteLine("Дата: {0}", notes[currentIndex].Date.ToShortDateString());
            Console.WriteLine();

            for (int i = 0; i < notes.Count; i++)
            {
                string noteName = (i == currentIndex) ? "> " + notes[i].Name : notes[i].Name;
                Console.WriteLine(noteName);
            }

            Console.WriteLine();
            Console.WriteLine("Стрелка влево - Предыдущая дата");
            Console.WriteLine("Стрелка вправо - Следующая дата");
            Console.WriteLine("Enter - Полная информация");
            Console.WriteLine("Q - Добавить заметку");
            Console.WriteLine("Esc - Выйти");
        }

        static void MoveToPreviousDate()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = notes.Count - 1;
            }
        }

        static void MoveToNextDate()
        {
            if (currentIndex < notes.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }

        static void DisplayNoteInfo()
        {
            Console.Clear();
            Console.WriteLine("Полная информация о заметке:");
            Console.WriteLine("Название: {0}", notes[currentIndex].Name);
            Console.WriteLine("Описание: {0}", notes[currentIndex].Description);
            Console.WriteLine("Дата: {0}", notes[currentIndex].Date.ToShortDateString());
            Console.WriteLine("Дата выполнения: {0}", notes[currentIndex].DueDate.ToShortDateString());

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        static void AddNote()
        {
            Console.Clear();
            Console.WriteLine("Добавление новой заметки");
            Console.WriteLine("-------------------------");
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            Console.Write("Введите описание: ");
            string description = Console.ReadLine();
            Console.Write("Введите дату: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            notes.Add(new Note(name, description, date));
        }
    }
}