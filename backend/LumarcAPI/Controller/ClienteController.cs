using LumarcAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LumarcAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly LumarcContext _context;

    public ClienteController(LumarcContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Clientes.ToList());
    }
}
