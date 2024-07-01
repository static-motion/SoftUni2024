namespace PizzaCalories;

public class Program
{
    public static void Main()
    {
        try
        {
            string command = Console.ReadLine();
            Pizza? pizza = null;
            while (command != "END")
            {
                string[] operation = command.Split();
                if (operation[0].ToLower() == "pizza")
                {
                    pizza = new Pizza(operation[1]);
                }
                else if (operation[0].ToLower() == "dough")
                {
                    if (pizza is null) throw new InvalidOperationException("Create a pizza first");
                    pizza.Dough = new Dough(operation[1], operation[2], double.Parse(operation[3]));
                }
                else if (operation[0].ToLower() == "topping")
                {
                    if (pizza is null) throw new InvalidOperationException("Create a pizza first");
                    pizza.AddTopping(new Topping(operation[1], double.Parse(operation[2])));
                }
                command = Console.ReadLine();
            }
            if (pizza is not null)
                Console.WriteLine(pizza);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}
