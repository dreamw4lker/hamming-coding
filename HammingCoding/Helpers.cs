﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HammingCoding
{
    public static class Helpers
    {
        //Метод проверки индекса элемента на степень двойки
        public static bool notPowerOf2(int x)
        {
            return !(x == 1 || x == 2 || x == 4 || x == 8);
        }

        //Метод получения позиций для построения XOR
        public static int[] getPositionsForXoring(int length, int currentHammingPosition)
        {
            var positions = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if ((i & currentHammingPosition) > 0 && notPowerOf2(i))
                    positions.Add(i);

            }
            return positions.ToArray();
        }

        //Метод построения XOR для вычисления синдрома
        public static bool doXoringForPosition(bool[] vector, int length, int currentHammingPosition)
        {
            return getPositionsForXoring(length, currentHammingPosition)
                .Select(x => vector[x - 1])
                .Aggregate((x, y) => x ^ y);
        }

        //Метод получения массива байтов из бинарной строки
        public static byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<byte>();
            for (int i = 0; i < binary.Length; i += 8)
            {
                if (binary.Length - i < 8) break;

                String t = binary.Substring(i, 8);
                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        //Метод построения массива битов со всеми элементами, равными 0
        public static bool[] createEmptyZeroBitArray(int length)
        {
            bool[] array = new bool[length];
            for (int i = 0; i < length; i++) array[i] = false;
            return array;
        }
    }
}
