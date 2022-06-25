namespace Test;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys_Common;

public class TestController : ControllerBase
{
    public static int Index { get; set; }

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
