namespace PizzaCalories
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        //Dough type modifiers
        private const double White = 1.5;
        private const double Wholegrain = 1;
        private static readonly Dictionary<string, double> _flourTypes = new() 
        { 
            { nameof(White).ToLower(), White }, 
            { nameof(Wholegrain).ToLower(), Wholegrain } 
        };

        //Baking technique modifiers
        private const double Crispy = .9;
        private const double Chewy = 1.1;
        private const double Homemade = 1;
        private static readonly Dictionary<string, double> _bakingTechniques = new() 
        { 
            { nameof(Crispy).ToLower(), Crispy }, 
            { nameof(Chewy).ToLower(), Chewy }, 
            { nameof(Homemade).ToLower(), Homemade } 
        };

        private static double DefaultCaloriesPerGram = 2;

        private double _typeModifier;
        private double _bakingTechniqueModifier;
        private double _weight;
        public double Weight 
        {
            get => this._weight; 
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                
                this._weight = value;
            }
        }
        public double CaloriesPerGram => 
            DefaultCaloriesPerGram * this._typeModifier * this._bakingTechniqueModifier;
        public double TotalCalories => 
            DefaultCaloriesPerGram * this.Weight * this._typeModifier * this._bakingTechniqueModifier; 
        
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            if (!ValidateDough(flourType, bakingTechnique)) 
                throw new ArgumentException("Invalid type of dough");
            this.Weight = weight;
            this._typeModifier = _flourTypes[flourType.ToLower()];
            this._bakingTechniqueModifier = _bakingTechniques[bakingTechnique.ToLower()];
        }

        private bool ValidateDough(string doughType, string bakingTechnique)
        {
            return _flourTypes.ContainsKey(doughType.ToLower()) 
                && _bakingTechniques.ContainsKey(bakingTechnique.ToLower());
        }

        public override string ToString()
        {
            return $"{this.TotalCalories:F2}";
        }
    }
}
