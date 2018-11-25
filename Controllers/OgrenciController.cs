using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _1._3.Models;

namespace _1._3.Controllers
{
    public class OgrenciController : Controller
    {
        OgrenciDataAccessLayer objOgrenci = new OgrenciDataAccessLayer();

        public IActionResult Index()
        {
            List<Ogrenci> lstOgrenci = new List<Ogrenci>();
            lstOgrenci = objOgrenci.spGetAllOgrenci().ToList();

            return View(lstOgrenci);
        }
        public IActionResult Profil()
        {
            List<Ogrenci> lstOgrenci = new List<Ogrenci>();
            lstOgrenci = objOgrenci.spGetAllOgrenci().ToList();

            return View(lstOgrenci);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                objOgrenci.spAddOgrenci(ogrenci);
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ogrenci ogrenci = objOgrenci.GetOgrenciData(id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Ogrenci ogrenci)
        {
            if (id != ogrenci.ogrenci_no)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objOgrenci.spUpdateOgrenci(ogrenci);
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ogrenci ogrenci = objOgrenci.GetOgrenciData(id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ogrenci ogrenci = objOgrenci.GetOgrenciData(id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objOgrenci.spDeleteOgrenci(id);
            return RedirectToAction("Index");
        }
    }
}