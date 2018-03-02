using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_AOP.Interfaces;
using DI_AOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DI_AOP.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public IActionResult Index()
        {
            PopulateCharactersIfNoneExist();
            var chars = _characterRepository.ListAll();
            return View(chars);
        }

        private void PopulateCharactersIfNoneExist()
        {
            if (!_characterRepository.ListAll().Any())
            {
                _characterRepository.Add(new Character("Darth Maul"));
                _characterRepository.Add(new Character("Darth Vader"));
                _characterRepository.Add(new Character("Yoda"));
                _characterRepository.Add(new Character("Mace Windu"));
            }

        }
    }
}