using DI_AOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_AOP.Interfaces
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();
        void Add(Character c);
    }
}
