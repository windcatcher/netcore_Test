using DI_AOP.Data;
using DI_AOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_AOP.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Character c)
        {
            _dbContext.Characters.Add(c);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Character> ListAll()
        {
            return _dbContext.Characters.AsEnumerable<Character>();
        }
    }
}
