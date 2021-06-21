using Habilitar.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Habilitar.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EFHelperController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EFHelperController(ApplicationDbContext context) => _context = context;

        [HttpGet("GenerateScript")]
        public string GenerateScript()
        {
            return _context.Database.GenerateCreateScript();
        }
    }
}
