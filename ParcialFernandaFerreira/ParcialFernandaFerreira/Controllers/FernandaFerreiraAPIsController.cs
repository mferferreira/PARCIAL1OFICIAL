using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ParcialFernandaFerreira.Models;

namespace ParcialFernandaFerreira.Controllers
{
    public class FernandaFerreiraAPIsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/FernandaFerreiraAPIs
        [Authorize]
        public IQueryable<FernandaFerreiraAPI> GetFernandaFerreiraAPIs()
        {
            return db.FernandaFerreiraAPIs;
        }

        // GET: api/FernandaFerreiraAPIs/5
        [Authorize]
        [ResponseType(typeof(FernandaFerreiraAPI))]
        public IHttpActionResult GetFernandaFerreiraAPI(int id)
        {
            FernandaFerreiraAPI fernandaFerreiraAPI = db.FernandaFerreiraAPIs.Find(id);
            if (fernandaFerreiraAPI == null)
            {
                return NotFound();
            }

            return Ok(fernandaFerreiraAPI);
        }

        // PUT: api/FernandaFerreiraAPIs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFernandaFerreiraAPI(int id, FernandaFerreiraAPI fernandaFerreiraAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fernandaFerreiraAPI.alpha3Code)
            {
                return BadRequest();
            }

            db.Entry(fernandaFerreiraAPI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FernandaFerreiraAPIExists(id))
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

        // POST: api/FernandaFerreiraAPIs
        [Authorize]
        [ResponseType(typeof(FernandaFerreiraAPI))]
        public IHttpActionResult PostFernandaFerreiraAPI(FernandaFerreiraAPI fernandaFerreiraAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FernandaFerreiraAPIs.Add(fernandaFerreiraAPI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fernandaFerreiraAPI.alpha3Code }, fernandaFerreiraAPI);
        }

        // DELETE: api/FernandaFerreiraAPIs/5
        [Authorize]
        [ResponseType(typeof(FernandaFerreiraAPI))]
        public IHttpActionResult DeleteFernandaFerreiraAPI(int id)
        {
            FernandaFerreiraAPI fernandaFerreiraAPI = db.FernandaFerreiraAPIs.Find(id);
            if (fernandaFerreiraAPI == null)
            {
                return NotFound();
            }

            db.FernandaFerreiraAPIs.Remove(fernandaFerreiraAPI);
            db.SaveChanges();

            return Ok(fernandaFerreiraAPI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FernandaFerreiraAPIExists(int id)
        {
            return db.FernandaFerreiraAPIs.Count(e => e.alpha3Code == id) > 0;
        }
    }
}