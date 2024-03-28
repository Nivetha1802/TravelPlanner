
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelPlanner.Entities;

namespace TravelPlanner.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly TpContext DBContext;

        public ValuesController(TpContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("ProductsGetall")]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var activeProdCategories = await DBContext.Tripdetails.ToListAsync();
            /*            return StatusCode(200);
            */
            return Ok(activeProdCategories);
        }
        [HttpGet("Getplacenames")]
        public IActionResult Get()
        {
            var places = DBContext.Placesdetails.Select(p => p.Placename).ToList();
            return Ok(places);
        }
        [HttpPost("Getplacenames")]
        public IActionResult PostPlaceDetail(Placesdetail placeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DBContext.Placesdetails.Add(placeDetails);
            DBContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = placeDetails.Placeid }, placeDetails);
        }

    }
}

    