using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {

        private BaseDonnees _baseDonnees { get; set; }

        public WeaponController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            return View(_baseDonnees.Weapons.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Weapon weapon)
        {
            return View();
        }
    }

}
