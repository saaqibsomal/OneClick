using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneClick.Models;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneClick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAddressController : ControllerBase
    {

        private readonly MyDbContext _context;

        public EmailAddressController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetEmailAddress")]
        public ActionResult<IEnumerable<EmailAddress>> GetEmailAddress()
        {
            // Retrieve all email addresses including the newly inserted one
            var result = _context.EmailAddresses.ToList();
            // Convert the IAsyncEnumerable to a list
            // Convert the IAsyncEnumerable to a list
            //var results = await result.ToListAsync();

            // Serialize the result using Newtonsoft.Json
            var serializedResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            // Return the serialized result
            return Ok(serializedResult);

           // return Ok(result);
        }




        [HttpPost("AddEmailAddress")]
        public async Task<ActionResult<IEnumerable<EmailAddress>>> AddEmailAddress([FromBody] EmailAddress newEmailAddress)
        {
            try
            {
                if (newEmailAddress == null)
                {
                    return BadRequest("Invalid input data");
                }

                // Validate the input if necessary

                // Add the new entity to the DbSet
              var Added =  _context.EmailAddresses.Add(newEmailAddress);

                // Save changes to the database
             var savechanges=   await _context.SaveChangesAsync();


                if (savechanges > 0)
                {

                    // Log the exception or handle it appropriately
                    return StatusCode(200, "Success");
                }

                // Retrieve all email addresses including the newly inserted one
                //var result = await _context.EmailAddresses.ToListAsync();
                else { 

                // Log the exception or handle it appropriately
                return StatusCode(400, "NOT Found");
                }
                //                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }











    }
}
