using System;
using System.Timers;

namespace ReadKey
{
    class Program
    {
        enum Direction { UP, RIGHT, DOWN, LEFT };
        static Direction d = Direction.RIGHT;
        static int x = 0, y = 0;
        static void Main(string[] args)
        {
            Timer t = new Timer
            {
                Interval = 100
            };
            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
            t.Elapsed += new ElapsedEventHandler(OnTimer);
            t.Start(); // Начинает вызывать событие Elapsed
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        d = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        d = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        d = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        d = Direction.DOWN;
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        private static void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
        {
            switch (d)
            {
                case Direction.UP:
                    if (y > 0)
                        --y;
                    break;
                case Direction.RIGHT:
                    if (x < Console.WindowWidth - 1)
                        ++x;
                    break;
                case Direction.DOWN:
                    if (y < Console.WindowHeight - 1)
                        ++y;
                    break;
                case Direction.LEFT:
                    if (x > 0)
                        --x;
                    break;
            }

            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Устанавливаем UTF-8 для корректного отображения символов
            Console.WriteLine("\uD83D\uDE03"); // Выводит 😃
        }
    }
}
