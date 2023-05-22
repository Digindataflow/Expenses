
namespace Expenses.Models;

public class ExpenseItem
{
    public int ID { get; set; }
    public DateOnly OccurDate { get; set; } 
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public ExpenseCategory Category { get; set; }
}

public enum ExpenseCategory
{
    Hygiene,
    Clothes,
    Restraurant,
    Vacation,
    Food,
    Technique,
    Health,
    Mobility,
    Entertainment,
    Home,
    Insurance,
    Other

}