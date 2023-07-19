using BethanysPieShop.ModelRepository;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet("all", Name = "GetAllPies")]
        public IActionResult GetAllPies()
        {
            var allPies = _pieRepository.AllPies;
            return Ok(allPies);
        }


        [HttpGet("{id}", Name = "GetPieById")]
        public IActionResult GetPieById(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie is null)
            {
                return NotFound();
            }
            return Ok(pie);
        }

        [HttpGet]
        public IActionResult SearchPie([FromQuery] string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var pie = _pieRepository.SearchPieByName(name);
                return new JsonResult(pie);
            }
            return new JsonResult(_pieRepository.AllPies);
        }
    }
}
