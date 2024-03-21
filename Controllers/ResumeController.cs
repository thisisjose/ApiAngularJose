using ApiAngularJose.Models;
using ApiAngularJose.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAngularJose.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
    {
    private readonly ILogger<ResumeController> _logger;

    private readonly ResumeServices _resumeServices;

    public ResumeController(ILogger<ResumeController> logger, ResumeServices resumeServices)
    {
        _logger = logger;
        _resumeServices = resumeServices;
    }

    ///Obtener todos los Sensores
    [HttpGet]
    public async Task<IActionResult> GetResume()
    {
        var resume = await _resumeServices.GetAsync();
        return Ok(resume);
    }

    ///Obtener Sensor por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetResumeById(string Id)
    {
        return Ok(await _resumeServices.GetResumeById(Id));
    }

    ///Crear Sensor
    [HttpPost]
    public async Task<IActionResult> CreateResume([FromBody] Resume resume)
    {
        if (resume == null)
            return BadRequest();

        await _resumeServices.InsertResume(resume);

        return Created("Created", true);
    }

    ///Actualizar Sensor
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateProyecto([FromBody] Resume resume, string Id)
    {
        if (resume == null)
            return BadRequest();

        await _resumeServices.InsertResume(resume);
        return Created("Created", true);
    }

}

