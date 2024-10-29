using System;
using System.Timers;

class Test
{
    static int count = 0;
    static void Main()
    {
        Timer t = new Timer();
        t.Interval = 1000;
        // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
        t.Elapsed += OnTimer;
        t.Start(); // Начинает вызывать событие Elapsed
        Console.Read();
    }

    private static void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
    {
        Timer t = (Timer)sender;
        count++;
        if (count == 10)
            t.Stop();

        Console.WriteLine("{0}", arg.SignalTime);
    }
}

