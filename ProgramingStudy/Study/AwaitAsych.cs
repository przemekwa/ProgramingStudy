using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class AwaitAsych : IStudyTest
    {
        class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has
            // subscribed. 
            if (OnAlarmRaised != null)
            {
                OnAlarmRaised();
            }
        }
    }

        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 called");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

        public void Study()
        {

            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            // raise the alarm
            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised");

            Console.ReadKey();

            int count = 5;

            //while (count == 0 )
            //{
            //    count--;
            //    Console.WriteLine("Number : {0}", count);
            //}

            DoAsynch();

            Console.WriteLine("Coś za do Ancyhch");

        }

        public async void DoAsynch()
        {
            Console.WriteLine("Start DoAnych");

            var x = await TestMethod();

            int count = 5;

            while (count != 0)
            {
                count--;
                Console.WriteLine("Number : {0}", count);
            }

            Console.WriteLine("Stop DoAnych" + x);
        }
        
        public Task Method()
        {
            Console.WriteLine("Start metody");

            var t = new Task(() =>
            {
                Console.WriteLine("Idzie zadanie");
                Thread.Sleep(2000);
            });


            t.Start();

            Console.WriteLine("Stop metody");

            return t;
        
        }


        public Task<int> TestMethod()
        {
            return Task.Run<int>(() =>
            {
                Thread.Sleep(10000);
                return 1;
            });
        }

    }
}
