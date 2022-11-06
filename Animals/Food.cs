namespace Animals
{
    public class Food
    {
        private double _foodWeight;
        public string FoodName { get; set; }

        public double FoodWeight
        {
            get
            {
                return _foodWeight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("weightFood <0");
                }
                else
                {
                    _foodWeight = value;
                }

            }
        }

        public Food(string foodName, double foodWeight)
        {
            FoodName = foodName;
            FoodWeight = foodWeight;
        }

        public override bool Equals(object? obj)
        {
            return obj is Food food 
                && food.FoodName == FoodName
                && food.FoodWeight == FoodWeight;
        }
    }
}
