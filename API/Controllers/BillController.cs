using API.Business.Services.Interface;
using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    public class BillController : BaseApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IBillService _billService;
        private readonly ILoggerManager _logger;

        public BillController(IMapper mapper, IBillService billService, ILoggerManager logger)
        {
            _logger = logger;
            _mapper = mapper;
           _billService = billService;
        }


        [HttpGet("getAll")]

        public async Task<IActionResult> getAll ()
        {
            try
            {
                var bill = await _billService.GetAll(trackChanges: false);
                if (bill == null || !bill.Any())
                {
                    _logger.LogInfo("List Bill is empty");
                    return BadRequest(HttpStatusCode.NotFound);
                }
                return Ok(new  {
                    StatusCode = "Success",
                    data = bill
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            
        }



      

    }
}
