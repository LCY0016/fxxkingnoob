using System;
using System.Threading;


namespace project9
{
    public delegate void TickHandler(object sender, TickEventArgs args);
    public class TickEventArgs{}

    public delegate void AlarmHandler(object sender, AlarmEventArgs args);
    public class AlarmEventArgs { }
    public class Clock
    {
        public event TickHandler Onclick1;
        public event AlarmHandler Onclick2;
        public int sethour;
        public int setminute;
        public int setsecond;
        public Clock(int hour,int minute,int second)
        {
            sethour = hour;
            setminute = minute;
            setsecond = second;
        }

        public void Tick()
        {
            TickEventArgs args = new TickEventArgs();
            Onclick1(this, args);
        }
        public void Alarm()
        {
            AlarmEventArgs args = new AlarmEventArgs();
            Onclick2(this, args);
        }

        public void work()
        {
            while (true)
            {
                Tick();
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                if (hour == sethour && minute == setminute && second == setsecond)
                {
                    Alarm();
                }
                Thread.Sleep(1000);
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clock A = new Clock(0,0,0);
            A.Onclick1 += ClockTick;
            A.Onclick2 += ClockAlarm;
            A.work();
        }
        static public void ClockTick(object sender, TickEventArgs args)
        {
            Console.WriteLine("时间转动1秒");
        }
        static public void ClockAlarm(object sender, AlarmEventArgs args)
        {
            Console.WriteLine("闹钟响起");
        }
    }
}
