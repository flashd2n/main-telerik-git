using System;

namespace exchangeBits
{
    class xchangeBits
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());

            uint maskThree = 1U << 3;
            uint thirdBit = (number & maskThree) >> 3;

            uint maskFour = 1U << 4;
            uint fourthBit = (number & maskFour) >> 4;

            uint maskFive = 1U << 5;
            uint fifthBit = (number  & maskFive) >> 5;

            uint maskTwentFour = 1U << 24;
            uint twentyFourBit = (number & maskTwentFour) >> 24;

            uint maskTwentyFive = 1U << 25;
            uint twentyFiveBit = (number & maskTwentyFive) >> 25;

            uint maskTwentySix = 1U << 26;
            uint twentySixBit = (number & maskTwentySix) >> 26;

            switch (thirdBit)
            {
                case 1:
                    uint mask24 = 1U << 24;
                    number = (number | mask24);
                    break;
                case 0:
                    uint mask240 = ~(1U << 24);
                    number = (number & mask240);
                    break;  
                default:
                    break;
            }

            switch (fourthBit)
            {
                case 1:
                    uint mask25 = 1U << 25;
                    number = (number | mask25);
                    break;
                case 0:
                    uint mask250 = ~(1U << 25);
                    number = (number & mask250);
                    break;
                default:
                    break;
            }

            switch (fifthBit)
            {
                case 1:
                    uint mask26 = 1U << 26;
                    number = (number | mask26);
                    break;
                case 0:
                    uint mask260 = ~(1U << 26);
                    number = (number & mask260);
                    break;
                default:
                    break;
            }

            switch (twentyFourBit)
            {
                case 1:
                    uint mask3 = 1U << 3;
                    number = (number | mask3);
                    break;
                case 0:
                    uint mask30 = ~(1U << 3);
                    number = (number & mask30);
                    break;
                default:
                    break;
            }

            switch (twentyFiveBit)
            {
                case 1:
                    uint mask4 = 1U << 4;
                    number = (number | mask4);
                    break;
                case 0:
                    uint mask40 = ~(1U << 4);
                    number = (number & mask40);
                    break;
                default:
                    break;
            }

            switch (twentySixBit)
            {
                case 1:
                    uint mask5 = 1U << 5;
                    number = (number | mask5);
                    break;
                case 0:
                    uint mask50 = ~(1U << 5);
                    number = (number & mask50);
                    break;
                default:
                    break;
            }
            Console.WriteLine(number);
        }
    }
}
