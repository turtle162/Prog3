using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Model2
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
       
        public Brand Brand { get; set; }
        public DateTime FirstDateProduction { get; set; }
        public string Brand_ { get; set; }
    }
    public class ModelsController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/Models
        public IQueryable<Model> GetModels()
        {
            return db.Models;
        }
        [HttpGet]
        [Route("api/Models/nowe")]
        public async Task<List<Model2>> Getmodel2()
        {
            List<Model2> model2s = new List<Model2>();
            List<Model> models = db.Models.ToList();
            foreach(Model model in models)
            {
                Model2 model2 = new Model2();
                model2.FirstDateProduction = model.FirstDateProduction;
                model2.id = model.id;
                model2.Name = model.Name;
                Brand brand = await db.Brands.FindAsync(model.BrandId);
                model2.Brand_ = brand.Name;
                model2s.Add(model2);
            }
            return model2s;
        }
        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> GetModel(int id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Models
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Models.Add(model);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = model.id }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> DeleteModel(int id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Models.Remove(model);
            await db.SaveChangesAsync();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Models.Count(e => e.id == id) > 0;
        }
    }
}