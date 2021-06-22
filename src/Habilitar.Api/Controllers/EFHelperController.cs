using Habilitar.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        [HttpGet("CheckDb")]
        public async Task<bool> CheckDb()
        {
            return await _context.Database.CanConnectAsync();
        }
    }
}
