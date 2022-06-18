using Microsoft.AspNetCore.Mvc;
using WebApiKalum.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/KalumManagement/[controller]")]
    public class CarreraTecnicaController : ControllerBase    
    {
        private readonly KalumDbContext DbContext;
        //private readonly ILogger<CarreraTecnicaController> Logger;
        //public CarreraTecnicaController(KalumDbContext _DbContext, ILogger<CarreraTecnicaController> _Logger)
        //{
        //    this.DbContext = _DbContext;
        // this.    this.Logger = _Logger;
        //}
        public CarreraTecnicaController(KalumDbContext _DbContext)
        {
            this.DbContext = _DbContext;
        }
        [HttpGet]
        public ActionResult<List<CarreraTecnica>> Get()
        {
            List<CarreraTecnica> carrerasTecnicas = null;
            //Tarea 1
            //carrerasTecnicas = await DbContext.CarreraTecnica.Include(c => c.Aspirantes).Include(c => c.Inscripcion).ToListAsync();
            carrerasTecnicas = DbContext.CarreraTecnica.Include(c => c.Aspirantes).Include(c => c.Inscripciones).ToList();
            //tarea 2
            if(carrerasTecnicas == null || carrerasTecnicas.Count == 0)
            {
                return new NoContentResult();
            }    
            return Ok(carrerasTecnicas);    
        }

        

    }
}