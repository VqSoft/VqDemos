using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal OldPrice;

        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal oPrice, decimal nPrice)
        {
            OldPrice = oPrice;
            NewPrice = nPrice;
        }
    }

    public class IPhone
    {
        private decimal price;

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged !=null)
            {
                PriceChanged(this, e);
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }


    public sealed class PriceDemo
    {
        public static void Demo()
        {
            IPhone p = new IPhone() { Price = 5288M };
            p.PriceChanged += Iphone_PriceChanged;

            p.Price = 3999;

        }

        private static void Iphone_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine("IPhone price from {0} to {1}", e.OldPrice,e.NewPrice);
        }
    }
}
