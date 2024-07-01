namespace PizzaCalories
{
    public class Pizza
    {
        private readonly List<Topping> _toppings;
        private string _name;
        private const int MaxToppingsCount = 10;

        public string Name 
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                this._name = value;
            }
        }
        public Dough? Dough { get; set; }
        public int ToppingsCount => _toppings.Count;
        public double TotalCalories => CalculateTotalCalories();
        public double CalculateTotalCalories()
        {
            double calories = 0;
            if (this.Dough != null) calories += this.Dough.TotalCalories;
            calories += this._toppings.Sum(t => t.TotalCalories);
            return calories;
        }
        public IReadOnlyList<Topping> Toppings => this._toppings;
        public Pizza(string name)
        {
            this.Name = name;
            this._toppings = new();
        }
        public Pizza(string name, Dough dough) : this(name)
        {
            this.Dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == MaxToppingsCount)
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            this._toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
    
}
