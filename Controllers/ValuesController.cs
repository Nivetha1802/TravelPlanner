
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
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

        [HttpGet("ProductsGetplaces")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var tripDetailsDTOs = await DBContext.Tripdetails
                .Select(td => new tripdetailsdto
                {
                    Destinationplace = td.Destinationplace,
                    Addnotes = td.Addnotes
                    // Map other properties as needed
                })
                .ToListAsync();

            return Ok(tripDetailsDTOs);
        }
        [HttpPost("AddTripDetails")]
        public async Task<IActionResult> AddTripDetails([FromBody] tripdetailsdto td)
        {
            var tripDetailsEntity = new Tripdetail
            {
                Originplace = td.Originplace,
                Departureday = td.Departureday,
                Destinationplace = td.Destinationplace,
                Arrivalday = td.Arrivalday,
                Modeoftransport = td.Modeoftransport,
                Durationoftrip = td.Durationoftrip,
                Addnotes = td.Addnotes,
                Budget = td.Budget
             
            };

            // Add entity to DbContext and save changes
            DBContext.Tripdetails.Add(tripDetailsEntity);
            await DBContext.SaveChangesAsync();

            var responsedto = new tripdetailsdto
            {
                Originplace = tripDetailsEntity.Originplace,
                Departureday = tripDetailsEntity.Departureday,
                Destinationplace = tripDetailsEntity.Destinationplace,
                Arrivalday = tripDetailsEntity.Arrivalday,
                Modeoftransport = tripDetailsEntity.Modeoftransport,
                Durationoftrip = tripDetailsEntity.Durationoftrip,
                Addnotes = tripDetailsEntity.Addnotes,
                Budget = tripDetailsEntity.Budget
            };

            // Return HTTP 201 (Created) with the created entity
            return Ok(responsedto);
        }
        [HttpPost("AddMemberDetails")]
        public async Task<IActionResult> AddMemberDetails([FromBody] memberdetailsdto td)
        {
            var memberDetailsEntity = new Membersdetail
            {
                Membername = td.Membername,
                Membertype = td.Membertype,
                Memberage = td.Memberage
                
            };

            // Add entity to DbContext and save changes
            DBContext.Membersdetails.Add(memberDetailsEntity);
            await DBContext.SaveChangesAsync();

            var responsedto = new memberdetailsdto
            {
                Membername = td.Membername,
                Membertype = td.Membertype,
                Memberage = td.Memberage
            };

            // Return HTTP 201 (Created) with the created entity
            return Ok(responsedto);
        }
        [HttpPost("AddPlacesDetails")]
        public async Task<IActionResult> AddPlacesDetails([FromBody] placesdetailsdto td)
        {
            var placesDetailsEntity = new Placesdetail
            {
                Placename = td.Placename,
                Notes = td.Notes
            };

            // Add entity to DbContext and save changes
            DBContext.Placesdetails.Add(placesDetailsEntity);
            await DBContext.SaveChangesAsync();

            var responsedto = new placesdetailsdto
            {
                Placename = td.Placename,
                Notes = td.Notes
            };

            // Return HTTP 201 (Created) with the created entity
            return Ok(responsedto);
        }
        
        
        [HttpGet("{dp}")]
        public IActionResult GetDetailsbydest ([FromRoute]String dp)
        {
            var td = DBContext.Tripdetails.Find(dp);
            if (td == null)
            {
                return BadRequest("Not found");
            }
            var tripdto = new tripdetailsdto
            {
                Originplace = td.Originplace,
                Departureday = td.Departureday,
                Destinationplace = td.Destinationplace,
                Arrivalday = td.Arrivalday,
                Modeoftransport = td.Modeoftransport,
                Durationoftrip = td.Durationoftrip,
                Addnotes = td.Addnotes,
                Budget = td.Budget

            };
            return Ok(tripdto);  
        }

        
        [HttpGet("{id}")]
        public IActionResult GetMembersbydest(String id)
        {
            var td = DBContext.Membersdetails.Find(id);
            if (id == null)
            {
                return BadRequest("Not found");
            }
            var responsedto = new memberdetailsdto
            {
                Membername = td.Membername,
                Membertype = td.Membertype,
                Memberage = td.Memberage
            };

            return Ok(responsedto);
        }

        
        [HttpGet("{dp1}")]
        public IActionResult GetPlacesbydest(String dp1)
        {
            var td = DBContext.Placesdetails.Find(dp1);
            if (dp1 == null)
            {
                return BadRequest("Not found");
            }

            var responsedto = new placesdetailsdto
            {
                Placename = td.Placename,
                Notes = td.Notes
            };

            return Ok(responsedto);
        }

    }



}


    