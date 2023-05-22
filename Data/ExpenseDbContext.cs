using Microsoft.EntityFrameworkCore;
using Expenses.Models;

namespace Expenses.Data;

public class ExpenseDbContext : DbContext
{
    public ExpenseDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ExpenseItem> ExpenseItem { get; set; } = null!;
}    