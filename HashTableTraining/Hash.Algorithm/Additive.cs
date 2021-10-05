using HashTableTraining.Hash.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Algorithm
{
    public class Additive : IHashAlgorithm
    {
        /// <summary>
        /// sums the characters in the string 
        /// terrible hashing function, not secure, and not uniform
        /// foo = oof
        /// </summary>
        public int Hash(string input)
        {
            var currentHashValue = 0;
            foreach(char c in input)
            {
                unchecked
                {
                    currentHashValue += (int)c;
                }
            }
            return currentHashValue;
        }
    }
}
