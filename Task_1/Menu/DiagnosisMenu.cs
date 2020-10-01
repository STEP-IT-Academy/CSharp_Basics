using HW7.Hospital;
using System;

namespace HW7.Menu
{
    class DiagnosisMenu
    {
        /// <summary>
        /// Пункты меню
        /// </summary>
        public string[] Items { get; private set; } =
        {
            "Ангина    ",
            "Грипп     ",
            "Пневмония ",
        };

        /// <summary>
        /// Активное окно
        /// </summary>
        public int ActiveItem { get; set; }

        // Цвета
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;
        public ConsoleColor Foreground { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor ActiveColor { get; set; } = ConsoleColor.Blue;

        // Координаты для местоположения меню в консоли
        public int X { get; set; } = 35;
        public int Y { get; set; } = 10;
        public int ActiveItemCursorPosition { get; set; }

        /// <summary>
        /// Вывод меню
        /// </summary>
        void ShowMenu()
        {
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;

            for (int i = 0; i < Items.Length; i++)
            {
                switch (i)
                {
                    case 0: Console.SetCursorPosition(X, Y); Console.Write(Items[i]); break;
                    case 1: Console.SetCursorPosition(X + Items[0].Length, Y); Console.Write(Items[i]); break;
                    case 2: Console.SetCursorPosition(X + (Items[0].Length + Items[1].Length), Y); Console.Write(Items[i]); break;
                }
            }

            Console.CursorVisible = false;
        }

        /// <summary>
        /// Вывод опереденного пунта меню по index
        /// </summary>
        /// <param name = "index"></param>
        void ShowItem(int index)
        {
            switch (index)
            {
                case 0: Console.SetCursorPosition(X, Y); Console.Write(Items[index]); break;
                case 1: Console.SetCursorPosition(X + Items[0].Length, Y); Console.Write(Items[index]); break;
                case 2: Console.SetCursorPosition(X + (Items[0].Length + Items[1].Length), Y); Console.Write(Items[index]); break;
            }
        }

        /// <summary>
        /// Подсветка выбранного меню
        /// </summary>
        void ActiveLight()
        {
            Console.BackgroundColor = ActiveColor;

            switch (ActiveItem)
            {
                case 0: Console.SetCursorPosition(X, Y); Console.Write(Items[ActiveItem]); break;
                case 1: Console.SetCursorPosition(X + Items[0].Length, Y); Console.Write(Items[ActiveItem]); break;
                case 2: Console.SetCursorPosition(X + (Items[0].Length + Items[1].Length), Y); Console.Write(Items[ActiveItem]); break;
            }
        }

        /// <summary>
        /// Гасим некоторый пункт меню 
        /// </summary>
        void TurnOffItem(int itemIndex)
        {
            Console.BackgroundColor = Background;
            switch (itemIndex)
            {
                case 0: Console.SetCursorPosition(X, Y); ShowItem(itemIndex); break;
                case 1: Console.SetCursorPosition(X + Items[0].Length, Y); ShowItem(itemIndex); break;
                case 2: Console.SetCursorPosition(X + (Items[0].Length + Items[1].Length), Y); ShowItem(itemIndex); break;
            }
        }

        /// <summary>
        /// Перемещение по пунктам меню
        /// </summary>
        void NavigateThroughMenuItems()
        {
            bool isNoChoice = true;

            while (isNoChoice)
            {
                ActiveLight();
                int tmp = ActiveItem;
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter: isNoChoice = false; break;
                    case ConsoleKey.RightArrow: if (ActiveItem == Items.Length - 1) ActiveItem = 0; else { ActiveItem++; } break;
                    case ConsoleKey.LeftArrow: if (ActiveItem == 0) ActiveItem = Items.Length - 1; else { ActiveItem--; } break;
                }
                TurnOffItem(tmp);
            }
        }

        /// <summary>
        /// Работа меню
        /// </summary>
        public void Start(InfoService infoService)
        {
            bool isRun = true;

            while (isRun)
            {
                Console.Clear();
                ShowMenu();
                NavigateThroughMenuItems();

                switch (Items[ActiveItem].Trim().ToLower())
                {
                    case "ангина": Console.Clear(); infoService.ShowInfo(Items[ActiveItem].Trim()); isRun = false;  break;
                    case "грипп": Console.Clear(); infoService.ShowInfo(Items[ActiveItem].Trim()); isRun = false; break;
                    case "пневмония": Console.Clear(); infoService.ShowInfo(Items[ActiveItem].Trim()); isRun = false; break;
                }
            }
        }
    }
}
