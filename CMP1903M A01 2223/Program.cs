using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Testing.testingMain(args);             // This will just call the main testing method and can be removed when not needed.
        }
    }


    // additional class
    class Testing
    {
        public static void testingMain(string[] args)
        {
            Pack newPack = new Pack();
            for (int i = 1; i < 4; i++)
            {
                // This loops over 3 numbers, all of which are valid options for shuffleCardPack
                Pack.shuffleCardPack(i);
                Console.WriteLine(Pack.ToString());
            }

            Console.WriteLine(format: "Dealing {0}", Pack.deal());

            List<Card> dealtCards = Pack.dealCard(10);
            foreach (Card card in dealtCards)
            {
                Console.WriteLine(format:"Dealt {0}", card.ToString());
            }
        }
    }
}
