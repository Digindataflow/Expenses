using  System.ComponentModel.DataAnnotations;
namespace Expenses.Models;

public class ExpenseItem
{
    public int ID { get; set; }
    [Required]
    public DateOnly OccurDate { get; set; } 
    [Required, StringLength(50)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; }
    [Required]
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