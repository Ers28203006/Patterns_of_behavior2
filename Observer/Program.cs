using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    public interface ISubscriber
    {
        void Update(IBublisher subject);
    }

    public interface IBublisher
    {
        
        void Attach(ISubscriber observer);

        
        void Detach(ISubscriber observer);

     
        void Notify();
    }

    public class Bookstore : IBublisher
    {
        public int State { get; set; } = -0;

        private List<ISubscriber> _observers = new List<ISubscriber>();

        public void Attach(ISubscriber observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(ISubscriber observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

     
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

   
    class BookSubscriber : ISubscriber
    {
        public void Update(IBublisher subject)
        {
            if ((subject as Bookstore).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class JournalSubscriber : ISubscriber
    {
        public void Update(IBublisher subject)
        {
            if ((subject as Bookstore).State == 0 || (subject as Bookstore).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }

    class ComicsSubscriber : ISubscriber
    {
        public void Update(IBublisher subject)
        {
            if ((subject as Bookstore).State == 0 || (subject as Bookstore).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код.
            var subject = new Bookstore();
            var observerA = new BookSubscriber();
            subject.Attach(observerA);

            var observerB = new JournalSubscriber();
            subject.Attach(observerB);

            var observerC = new ComicsSubscriber();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
    }
}
