using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_Server.Models;

namespace PRS_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequestsController(AppDbContext context)
        {
            _context = context;
        }


        //[HttpGet] get where status is REVIEW && User.Id !== User.Id


        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        //GET: api/Requests/userid/status
        //[HttpGet("{userid}/{status}")]
        //public async Task<ActionResult<Request>> RequestStatusUserId(int userId, string status) {
        //    var request = await _context.Requests
        //        .SingleOrDefaultAsync(r => r.UserId.Equals(userId) && r.Status.Equals(status));

        //    if (request == null) {
        //        return NotFound();
        //    }

        //    return request;

        //}

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Requests/5  (set Request Status to "Review" from id)
        [HttpPut("review/{id}")]
        public async Task<IActionResult> PutStatusReview(int id) {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) {
                return NotFound();
            }
            request.Status = "REVIEW";

            _context.SaveChanges();
            return NoContent();
        }

        // PUT: api/Requests/5  (set Request Status to "Approved" from id)
        [HttpPut("approved/{id}")]
        public async Task<IActionResult> PutStatusApproved(int id) {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) {
                return NotFound();
            }
            request.Status = "APPROVED";

            _context.SaveChanges();
            return NoContent();
        }
        //NEW REQUEST REJECT
        [HttpPut("reject/id")]
        public async Task<IActionResult> PutStatusReject(int id, Request request) {
            request.Status = "REJECTED";
            return await PutRequest(id, request);
        }




        // PUT: api/Requests/5  (set Request Status to "Rejected" from id)
        [HttpPut("rejected/{id}")]
        public async Task<IActionResult> PutStatusRejected(int id) {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) {
                return NotFound();
            }
            request.Status = "REJECTED";


            //REASON REJECTION CANNOT BE NULL
            if (request.ReasonRejection == null && request.Status == "REJECTED") {
                throw new Exception();
            }


            _context.SaveChanges();
            return NoContent();
        }




        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            // <50 auto set to APPROVED, >50 set to REVIEW
            request.Status = (request.Total <= 50) ? "APPROVED" : "REVIEW"; //ternary operator
            _context.SaveChanges();



            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }



        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
