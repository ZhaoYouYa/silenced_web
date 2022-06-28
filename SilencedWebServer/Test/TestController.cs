namespace Test;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys_Common;
using Sys_Pgsql;

public class TestController : ControllerBase
{
    public readonly PgContext _db;

    public TestController(PgContext db_)
    {
        _db = db_;
    }

    [Route("Silenced2")]
    [HttpGet]
    public IActionResult Silenced2()
    {
        var item = from i in _db.dpt_choice select i;
        return Ok(item.ToArray());
    }

    [Route("test")]
    [HttpGet]
    public IActionResult test()
    {
        Random rd = new Random();

        var x = rd.NextInt64();

        HttpContext.Session.SetString("name", $"{x}");

        //throw new Exception("sdfsdfg");
        return Ok($"{x}");
    }

    [AuthorizFilter]
    [Route("Get")]
    [HttpGet]
    public IActionResult Get()
    {
        //throw new Exception("sdfsdfg");
        return Ok(HttpContext.Session.GetString("name"));
    }
}
