using System;
using System.Collections.Generic;
namespace Events
{
    delegate void MyDelegate();
    class SourceEvent
    {
        List<MyDelegate> list = new List<MyDelegate>();

        // Для управления списком обработчиков событий служит 
        // расширенная форма оператора event, позволяющая использовать аксессоры событий. 
        // Эти аксессоры предоставляют средства для управления реализацией подобного списка. 
        // Элементы управления WPF используют этот подход для добавления функциональности 
        // "пузырькового" и "туннельного" распространения событий.

        public event MyDelegate Event
        {
            // Используем аксессоры событий
            add
            {
                list.Add(value);
            }

            remove
            {
                list.Remove(value);
            }
        }
        public void GeneratorEvent()
        {
            Console.WriteLine("Произошло событие!");
            if (list.Count != 0)
                foreach (MyDelegate del in list)
                {
                    del();
                }
        }
    }

    class ObserverEventA
    {
        public void See()
        {
            Console.WriteLine("ObserverEventA. Событие обработано! ");
        }
    }

    class ObserverEventB
    {
        public void See()
        {
            Console.WriteLine("ObserverEventB. Событие обработано!");
        }
    }

    class MainClass
    {
        static void Main()
        {
            SourceEvent s = new SourceEvent(); // объект класса-источника события
            ObserverEventA obj1 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventA obj2 = new ObserverEventA(); // объект класса наблюдателя
            ObserverEventB obj3 = new ObserverEventB(); // объект класса наблюдателя
            ObserverEventB obj4 = new ObserverEventB(); // объект класса наблюдателя

            // добавление обработчиков к событию
            s.Event += new MyDelegate(obj1.See);
            s.Event += new MyDelegate(obj2.See);
            s.Event += new MyDelegate(obj3.See);
            s.Event += new MyDelegate(obj4.See);

            s.GeneratorEvent(); // инициирование события

            s.Event -= obj3.See;
            s.Event -= obj4.See;

            s.GeneratorEvent(); // инициирование события
        }
    }

}
