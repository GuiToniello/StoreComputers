using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Context;
using Uniplac.Trabalho_Final_Guilherme.Aplicacao;
using Uniplac.Trabalho_Final_Guilherme.Infraestrutura.Repositories;
using Dominio.Contracts;
using Infraestrutura.Data.Twitter;

namespace Uniplac.Trabalho_Final.Apresentacao.Web.Controllers
{
    public class MotherboardsController : Controller
    {
        private IMotherboardRepository motherboardRepository;
        private IPostRepository postRepository;
        private IMotherboardService service;

        public MotherboardsController() : base()
        {
            motherboardRepository = new MotherboardRepository();
            postRepository = new PostRepository();
            service = new MotherboardService(motherboardRepository, postRepository);
        }

        // GET: Computers
        public ActionResult Index()
        {
            return View(service.ReadAll());
        }

        // GET: Computers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard computer = service.Read(id.Value);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // GET: Computers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Brand,Type")] Motherboard computer)
        {
            if (ModelState.IsValid)
            {
                service.Create(computer);
                return RedirectToAction("Index");
            }

            return View(computer);
        }

        // GET: Computers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard computer = service.Read(id.Value);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Brand,Type")] Motherboard computer)
        {
            if (ModelState.IsValid)
            {
                service.Update(computer);
                return RedirectToAction("Index");
            }
            return View(computer);
        }

        // GET: Computers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard computer = service.Read(id.Value);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motherboard computer = service.Read(id);
            service.Delete(computer);
            return RedirectToAction("Index");
        }
    }
}
