namespace PizzaCalories
{
    public class Topping
    {
        private const double MaxWeight = 50;
        private const double MinWeight = 1;

        private const double Meat = 1.2;
        private const double Veggies = .8;
        private const double Cheese = 1.1;
        private const double Sauce = .9;
        private const double DefaultCaloriesPerGram = 2;
        private readonly double TypeModifier;
        private static readonly Dictionary<string, double> _toppings = new()
        {
            {nameof(Meat).ToLower(), Meat },
            {nameof(Veggies).ToLower(), Veggies},
            {nameof(Cheese).ToLower(), Cheese},
            {nameof(Sauce).ToLower(), Sauce}
        };
        private double _weight;
        public Topping(string topping, double weight)
        {
            if (!_toppings.ContainsKey(topping.ToLower()))
                throw new ArgumentException($"Cannot place {topping} on top of your pizza.");

            this.TypeModifier = _toppings[topping.ToLower()];
            this.Name = topping;
            this.Weight = weight;
        }
        public string Name { get; }
        public double Weight 
        { 
            get => this._weight; 
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                    throw new ArgumentException($"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
                this._weight = value;
            }
        }
        public double TotalCalories => this.Weight * DefaultCaloriesPerGram * this.TypeModifier;
    }
}
