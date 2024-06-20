using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cinema_Teste.Controllers
{
    public class FilmesController : Controller
    {
        CinemaEntities db = new CinemaEntities();

        // GET: Filmes
        public ActionResult Index(string procurar)
        {
            return View(db.Filme.Where(x => x.Titulo.Contains(procurar) || 
            x.Duracao.Contains(procurar) || 
            x.Ano.Contains(procurar) || 
            x.TipoDeMidia.Contains(procurar) || 
            x.Elenco.Contains(procurar) ||
            x.Diretor.Contains(procurar) || 
            procurar == null).ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Filme filme = db.Filme.Find(id);

            if (filme == null)
                return HttpNotFound();
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFilme,Titulo,Duracao,Ano,TipoDeMidia,Elenco,Diretor")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filme.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Filme filme = db.Filme.Find(id);

            if (filme == null)
                return HttpNotFound();

            return View(filme);
        }

        // POST: Filmes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFilme,Titulo,Duracao,Ano,TipoDeMidia,Elenco,Diretor")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Filme filme = db.Filme.Find(id);

            if (filme == null)
                return HttpNotFound();

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filme.Find(id);
            db.Filme.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
