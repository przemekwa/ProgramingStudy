using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class ObserverrDesignPatternStudy : IStudyTest
    {
        public void Study()
        {

            var investor1 = new Investor("Przemek");
            var investor2 = new Investor("Jola");

            var bzwbk = new ConcreteStock();

            bzwbk.Attach(investor1);
            bzwbk.Attach(investor2);

            bzwbk.Price = 100;

            Thread.Sleep(3000);

            bzwbk.Price = 200;

            Thread.Sleep(3000);

            bzwbk.Price = 300;



        }





    }


    public class ConcreteStock : Stock
    {
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                this.NotifyAll(this);
            }
        }
    }


    public abstract class Stock
    {
        public List<Investor> Investros { get; set; } = new List<Investor>();

        public void Attach(Investor i)
        {
            this.Investros.Add(i);
        }

        public void Detach(Investor i)
        {
            this.Investros.Remove(i);
        }

        public virtual void NotifyAll(ConcreteStock concreteStock)
        {
            foreach (var investro in this.Investros)
            {
                investro.Show(concreteStock);
            }
        }

    }

    public class Investor
    {
        public string Name { get; set; }

        public Investor(string name)
        {
            Name = name;
        }

        public void Show(ConcreteStock concreteStock)
        {
            Console.WriteLine($" {Name} widzi zmiane ceny na {concreteStock.Price}");
        }
    }
}
