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
using WebApp2.Data;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    public class Car2
    {

        public string Id { get; set; }
        public int ModelId { get; set; }

        public string Model { get; set; }
        public DateTime DateProduction { get; set; }
        public string FuelType { get; set; }
        public string BodyStyle { get; set; }
        public int OdoMeter { get; set; }
        public string EngineType { get; set; }
        public string Brand { get; set; }
    }
    public class CarsController : ApiController
    {
        private WebApp2Context db = new WebApp2Context();
        [HttpGet]
        [Route("api/Cars/nowe")]
        public async Task<List<Car2>> Getcar2()
        {
            List<Car2> car2s = new List<Car2>();
            List<Car> cars = db.Cars.ToList();
            foreach (Car car in cars)
            {
                Car2 car2 = new Car2();
                car2.BodyStyle = car.BodyStyle;
                car2.DateProduction = car.DateProduction;
                car2.EngineType = car.EngineType;
                car2.FuelType = car.FuelType;
                car2.Id = car.Id;
                car2.OdoMeter = car.OdoMeter;
                Model model = await db.Models.FindAsync(car.ModelId);
                car2.Model = model.Name;
                Brand brand = await db.Brands.FindAsync(model.BrandId);
                car2.Brand = brand.Name;
                car2s.Add(car2);

            }
            return car2s;



        }
        [Route("api/Cars/nowe2")]
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> PostCar2(Car2 car2)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            Model model =  db.Models.Where(q => q.Name == car2.Model).FirstOrDefault();
            Car car = new Car()
            {
                BodyStyle = car2.BodyStyle,
                DateProduction = car2.DateProduction,
                EngineType = car2.EngineType,
                FuelType = car2.FuelType,
                ModelId = model.id,
                OdoMeter = car2.OdoMeter,
                Id = car2.Id
            };
            db.Cars.Add(car);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarExists(car.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = car.Id }, car);
        }
        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> GetCar(string id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCar(string id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Id)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarExists(car.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> DeleteCar(string id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            await db.SaveChangesAsync();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(string id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}