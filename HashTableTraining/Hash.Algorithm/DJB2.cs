using HashTableTraining.Hash.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Algorithm
{
    public class DJB2 : IHashAlgorithm
    {

        /// <summary>
        /// hashing function first reported by Dan Bernstein
        /// http://www.cse.yorku.ca/~oz/hash.html
        /// </summary>
        public int Hash(string input)
        {
            int hash = 5381;
            foreach(int c in input.ToCharArray())
            {
                unchecked
                {
                    // hash * 33 + c 
                    hash = ((hash << 5) + hash) + c;
                }
            }
            return hash;
        }
    }
}
