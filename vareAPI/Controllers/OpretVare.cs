using Microsoft.AspNetCore.Mvc;
using vareAPI;

namespace vareAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private List<Vare> _varene = new List<Vare>() { 
        new Vare() {  
          id = 1, 
          name = "Adonis mor", 
          beskrivelse = "Løs tøs klar til at slå sig løs", 
          vurdering = 22.5
      }, 
        new Vare() {  
          id = 2, 
          name = "Emil papsøster", 
          beskrivelse = "dejlig dame", 
          vurdering = 5000
      } 
  }; 

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostVare")]
    public Vare PostVare(int id, string name, string beskrivelse, double vurdering)
    {
        Vare vare = new(id, name, beskrivelse, vurdering);
        _varene.Add(vare);
        return _varene.Last();
    }

    // [HttpGet(Name = "GetVareById")] 
    // public Vare GetVareById(int vareId) 
    // { 
    //   return _varene.Where(c => c.id == vareId).First();
    // }

    [HttpGet(Name = "GetVare")] 
    public List<Vare> Get() 
    { 
      return _varene.ToList();
    }
    
}