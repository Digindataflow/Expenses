using Expenses.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Data;

public class ExpenseService
{
    private readonly ExpenseDbContext _db;
    public ExpenseService(ExpenseDbContext db)
    {
        _db = db;
    }

    public async Task<List<ExpenseItem>> GetExpenseItemsAsync()
    {
        // Call your data access technology here
        return (await _db.ExpenseItem.ToListAsync()).OrderByDescending(s => s.OccurDate).ToList();
    }

    public async Task<ExpenseItem> AddExpenseItemAsync(ExpenseItem ExpenseItem) {
        _db.Add(ExpenseItem);
        await _db.SaveChangesAsync();
        return ExpenseItem;
    }

    public async Task<ExpenseItem?> GetExpenseItemById(int id)
    {
        return await _db.ExpenseItem
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.ID == id);
    }

    public async Task DeleteExpenseItemById(int id)
    {
        var expenseItem = await _db.ExpenseItem.FindAsync(id);
        if (expenseItem is not null)
        {
            _db.ExpenseItem.Remove(expenseItem);
            await _db.SaveChangesAsync();
        }        
    }

    public async Task EditExpenseItemById(int id, ExpenseItem newExpenseItem)
    {
        var expenseItem = await _db.ExpenseItem.FindAsync(id);
        if (expenseItem is not null)
        {
            _db.Entry(expenseItem).CurrentValues.SetValues(newExpenseItem);
            await _db.SaveChangesAsync();
        }        
    }

}