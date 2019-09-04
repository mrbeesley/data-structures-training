using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableTraining.Hash.Contracts
{
    public interface IHashAlgorithm
    {
        int Hash(string input);
    }
}
