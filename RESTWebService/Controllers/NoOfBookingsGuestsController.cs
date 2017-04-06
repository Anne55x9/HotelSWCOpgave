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
using RESTWebService;

namespace RESTWebService.Controllers
{
    public class NoOfBookingsGuestsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/NoOfBookingsGuests
        public IQueryable<NoOfBookingsGuest> GetNoOfBookingsGuest()
        {
            return db.NoOfBookingsGuest;
        }

        // GET: api/NoOfBookingsGuests/5
        [ResponseType(typeof(NoOfBookingsGuest))]
        public async Task<IHttpActionResult> GetNoOfBookingsGuest(int id)
        {
            NoOfBookingsGuest noOfBookingsGuest = await db.NoOfBookingsGuest.FindAsync(id);
            if (noOfBookingsGuest == null)
            {
                return NotFound();
            }

            return Ok(noOfBookingsGuest);
        }

        // PUT: api/NoOfBookingsGuests/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNoOfBookingsGuest(int id, NoOfBookingsGuest noOfBookingsGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noOfBookingsGuest.Guest_No)
            {
                return BadRequest();
            }

            db.Entry(noOfBookingsGuest).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoOfBookingsGuestExists(id))
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

        // POST: api/NoOfBookingsGuests
        [ResponseType(typeof(NoOfBookingsGuest))]
        public async Task<IHttpActionResult> PostNoOfBookingsGuest(NoOfBookingsGuest noOfBookingsGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoOfBookingsGuest.Add(noOfBookingsGuest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoOfBookingsGuestExists(noOfBookingsGuest.Guest_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = noOfBookingsGuest.Guest_No }, noOfBookingsGuest);
        }

        // DELETE: api/NoOfBookingsGuests/5
        [ResponseType(typeof(NoOfBookingsGuest))]
        public async Task<IHttpActionResult> DeleteNoOfBookingsGuest(int id)
        {
            NoOfBookingsGuest noOfBookingsGuest = await db.NoOfBookingsGuest.FindAsync(id);
            if (noOfBookingsGuest == null)
            {
                return NotFound();
            }

            db.NoOfBookingsGuest.Remove(noOfBookingsGuest);
            await db.SaveChangesAsync();

            return Ok(noOfBookingsGuest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoOfBookingsGuestExists(int id)
        {
            return db.NoOfBookingsGuest.Count(e => e.Guest_No == id) > 0;
        }
    }
}