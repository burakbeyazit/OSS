using Microsoft.AspNetCore.Mvc;
namespace demo.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{

    private static List<Item> items = new List<Item>();

    [HttpGet]
    [Route("list")]
    public IActionResult GetItems()
    {
        return Ok(items);
    }


    [HttpGet]
    [Route("get/{id}")]
    public IActionResult GetItems([FromHeader] int id)
    {
        return Ok(items.FirstOrDefault(x => x.Id == id));
    }

    [Route("post")]
    [HttpPost]
    public IActionResult Poststring([FromBody] Item item)
    {
        items.Add(item);
        return Ok("Başarılı");
    }


    [HttpPut]
    [Route("update/{id}")]
    public IActionResult PutTodoItem(long id, [FromBody] Item newItem)
    {
        var item = items.FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        item = newItem;

        return Ok(item);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public IActionResult Deletestring([FromHeader] long id)
    {
        var item = items.FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        items.Remove(item);
        return Ok("Success");
    }
}
