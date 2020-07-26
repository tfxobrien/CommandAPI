using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    //Add the code below to our class
    private readonly ICommandAPIRepo _repository;
    public CommandsController(ICommandAPIRepo repository)
    {
      _repository = repository;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(commandItems);
    }
    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem == null)
      {
        return NotFound();
      }
      return Ok(commandItem);
    }


    // [HttpGet]
    // public ActionResult<IEnumerable<string>> Get()
    // {
    //   return new string[] { "this", "is", "hard", "coded" };
    // }
  }
}
