using System;
namespace Events
{
    delegate void MyDelegate();
    class SourceEvent
    {
        public event MyDelegate Event;
        public void GeneratorEvent()
        {
            Console.WriteLine("Произошло событие!");
            Event?.Invoke();
        }
    }

    class ObserverEventA
    {
        public void See()
        {
            Console.WriteLine("ObserverEventA. Событие обработано!");
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
            s.Event += obj1.See;
            s.Event += obj2.See;
            s.Event += obj3.See;
            s.Event += obj4.See;
 
            s.GeneratorEvent(); // инициирование события

            s.Event -= obj3.See;
            s.Event -= obj4.See;

            s.GeneratorEvent(); // инициирование события
        }
    }

}
