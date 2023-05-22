using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenses.Data;
using Expenses.Models;

namespace Expenses.Controllers;

[Route("api/expense")]
[ApiController]
public class ExpenseItemController : Controller
{
    private readonly ExpenseService _service;

    public ExpenseItemController(ExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExpenseItem>>> GetExpenseItems()
    {
        return await _service.GetExpenseItemsAsync();
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddExpenseItem(ExpenseItem newExpenseItem)
    {
        newExpenseItem = await _service.AddExpenseItemAsync(newExpenseItem);
        return CreatedAtAction(nameof(AddExpenseItem), new {id = newExpenseItem.ID}, newExpenseItem);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, ExpenseItem newExpenseItem)
    {
        var old = _service.GetExpenseItemById(id);

        if(old is not null)
        {
            await _service.EditExpenseItemById(id, newExpenseItem);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var old = _service.GetExpenseItemById(id);
        if (old == null) {
            return NotFound();
        }
        await _service.DeleteExpenseItemById(id);
        return Ok();
    }
}