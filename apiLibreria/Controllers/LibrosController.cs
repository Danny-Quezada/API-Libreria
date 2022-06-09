using apiLibreria.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ViewModel;

namespace apiLibreria.Controllers
{
    public class LibrosController : ApiController
    {
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<LibrosWiewModel> librosWiewModels = new List<LibrosWiewModel>();

            using (LibreriaEntities db = new LibreriaEntities())
            {
                librosWiewModels = (from l in db.Libros
                                    select new LibrosWiewModel
                                    {
                                        Id = l.Id,
                                        ISBN = l.ISBN,
                                        Titulo = l.Titulo,
                                        Autor = l.Autor,
                                        Temas = l.Temas,
                                        Editorial = l.Editorial,
                                    }
                                 ).ToList();

                return Ok(librosWiewModels);
            }

        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            LibrosWiewModel librosWiewModel = null;

            using (LibreriaEntities db = new LibreriaEntities())
            {
                librosWiewModel = db.Libros.Where(l => l.Id == id).Select(l => new LibrosWiewModel()
                {
                    Id = l.Id,
                    ISBN = l.ISBN,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Temas = l.Temas,
                    Editorial = l.Editorial,
                }).FirstOrDefault();
            }

            if (librosWiewModel == null)
                return NotFound();
            return Ok(librosWiewModel);
        }

        [HttpPost]
        public IHttpActionResult Add(LibrosWiewModel librosWiewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (LibreriaEntities db = new LibreriaEntities())
            {
                var oLibro = new Models.Libros();
                oLibro.ISBN = librosWiewModel.ISBN;
                oLibro.Titulo = librosWiewModel.Titulo;
                oLibro.Autor = librosWiewModel.Autor;
                oLibro.Temas = librosWiewModel.Temas;
                oLibro.Editorial = librosWiewModel.Editorial;

                db.Libros.Add(oLibro);
                db.SaveChanges();
            }
            return Ok("Successfully added record");
        }
        [HttpPut]
        public IHttpActionResult Update(LibrosWiewModel librosWiewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("this is not model valid");
            }

            using (LibreriaEntities DB = new LibreriaEntities())
            {
                var oLibro = DB.Libros.Where(x => x.Id == librosWiewModel.Id).FirstOrDefault<Libros>();

                if (oLibro != null)
                {
                    oLibro.ISBN = librosWiewModel.ISBN;
                    oLibro.Titulo = librosWiewModel.Titulo;
                    oLibro.Autor = librosWiewModel.Autor;
                    oLibro.Temas = librosWiewModel.Temas;
                    oLibro.Editorial = librosWiewModel.Editorial;
                    DB.SaveChanges();
                }
                else
                    return NotFound();

            }

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id is not valid");
            }
            using(LibreriaEntities DB=new LibreriaEntities())
            {
                var libro = DB.Libros.Where(x => x.Id == id).FirstOrDefault<Libros>();
                DB.Entry(libro).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }
            return Ok();
        }
    }

}
