using System;
using System.Collections.Generic;

public class Dish
{
    public string Name { get; set; }
    public string Category { get; set; }

    public Dish(string name, string category)
    {
        Name = name;
        Category = category;
    }
}

public class Potluck
{
    public List<Dish> Menu { get; set; }
    public string Date { get; set; }

    public Potluck(string date)
    {
        Menu = new List<Dish>();
        Date = date;
    }

    public void AddDish(Dish dish)
    {
        Menu.Add(dish);
    }

    public List<Dish> GetAllFromCategory(string category)
    {
        var dishesInCategory = new List<Dish>();
        foreach (var item in Menu)
        {
            if (item.Category == category)
            {
                dishesInCategory.Add(item);
            }
        }
        return dishesInCategory;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Potluck Planner!");

        // Get the date for the potluck from the user
        Console.Write("Enter the date for the potluck: ");
        string date = Console.ReadLine();

        // Create a new potluck with the specified date
        Potluck potluck = new Potluck(date);

        bool done = false;
        // Ask the user to add dishes to the potluck
        while (!done)
        {
            Console.WriteLine();
            Console.WriteLine("Add a dish to the potluck:");
            Console.Write("Enter the dish name (or 'done' to finish): ");
            string name = Console.ReadLine();

            if (name == "done")
            {
                done = true;
            }
            else
            {
                Console.Write("Enter the dish category (appetizer, entre, or dessert): ");
                string category = Console.ReadLine();

                Dish dish = new Dish(name, category);
                potluck.AddDish(dish);

                Console.WriteLine($"Added '{name}' to the potluck!");
            }
        }

        // Display the menu for the potluck
        Console.WriteLine();
        Console.WriteLine($"Menu for potluck on {date}:");
        Console.WriteLine("Appetizers:");
        foreach (Dish dish in potluck.GetAllFromCategory("appetizer"))
        {
            Console.WriteLine($"- {dish.Name}");
        }
        Console.WriteLine("Entres:");
        foreach (Dish dish in potluck.GetAllFromCategory("entre"))
        {
            Console.WriteLine($"- {dish.Name}");
        }
        Console.WriteLine("Desserts:");
        foreach (Dish dish in potluck.GetAllFromCategory("dessert"))
        {
            Console.WriteLine($"- {dish.Name}");
        }
    }
}
