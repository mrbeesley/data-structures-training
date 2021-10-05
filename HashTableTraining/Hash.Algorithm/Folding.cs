using HashTableTraining.Hash.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Algorithm
{
    public class Folding : IHashAlgorithm
    {
        /// <summary>
        /// treats each four characters as an integers 
        /// </summary>
        public int Hash(string input)
        {
            var hashValue = 0;
            var startIndex = 0;
            int currentFourBytes;

            do
            {
                currentFourBytes = GetNextBytes(startIndex, input);
                unchecked
                {
                    hashValue += currentFourBytes;
                }
                startIndex += 4;
            } while (currentFourBytes != 0);

            return hashValue;
        }

        private int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;

            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes += GetByte(str, startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;

            return currentFourBytes;
        }

        private int GetByte(string str, int index)
        {
            if(index < str.Length)
            {
                return (int)str[index];
            }
            return 0;
        }
    }
}
