﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    /*
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    */

    class Testing
    {
        static void Main(string[] args)
        {
            Pack new_pack = new Pack();
            for (int i = 1; i < 4; i++)
            {
                // This loops over 3 numbers, all of which are valid options for shuffleCardPack
                Pack.shuffleCardPack(i);
                Console.WriteLine(Pack.ToString());
            }
        }
    }
}
