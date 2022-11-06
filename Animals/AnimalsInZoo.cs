namespace Animals
{
    public class AnimalsInZoo
    {
        private int _age;
        /// <summary>
        /// сколько может съесть
        /// </summary>
        private double _weightFood;
        /// <summary>
        /// сколько съел
        /// </summary>
        private double _atedFood;
        public string Type { get; set; }
        public string Habitat { get; set; }
        public int HabitatArea { get; set; }
        public string[] Food { get; set; }
        public bool IsPredator { get; set; }
        public string Sound { get; set; }
        public string Name { get; set; }
        public double WeightFood
        {
            get
            {
                return _weightFood;
            }
            set
            {
                if (value > 0)
                {
                    _weightFood = value;
                }
            }
        }

        public double NeedToEat
        {
            get
            {
                return _weightFood - _atedFood;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }

        public double AtedFood
        {
            get { return _atedFood; }
            private set { }
        }

        public AnimalsInZoo(string type, string habitat, int habitatArea, string[] food, bool isPredator, string sound, string name, double weightFood, int age)
        {
            Type = type;
            Habitat = habitat;
            HabitatArea = habitatArea;
            Food = food;
            IsPredator = isPredator;
            Sound = sound;
            Name = name;
            WeightFood = weightFood;
            Age = age;
            _atedFood = 0;
        }

        public AnimalsInZoo(string type, string name)
        {
            Type = type;
            Name = name;
            switch (type)
            {
                case "bear":
                    Habitat = "forest";
                    HabitatArea = 5000;
                    Food = new[] { "meat", "fish" };
                    IsPredator = true;
                    Sound = "Beaaaar";
                    WeightFood = 100;
                    break;
                case "cow":
                    Habitat = "field";
                    HabitatArea = 1000;
                    Food = new[] { "grass" };
                    IsPredator = false;
                    Sound = "Muuuuu";
                    WeightFood = 50;
                    break;
                default:
                    break;
            }
        }

        public void DoEat(Food[] food)
        {
            if (NeedToEat > 0)
            {
                for (int i = 0; i < food.Length; i++)
                {
                    if (food[i].FoodWeight < 0)
                    {
                        throw new ArgumentException("weightFood <0");
                    }
                }
                for (int i = 0; i < food.Length; i++)
                {
                    bool canEat = false;
                    if (food[i].FoodWeight <= 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < Food.Length; j++)
                    {
                        if ((food[i].FoodName == Food[j]))
                        {
                            if (NeedToEat >= food[i].FoodWeight)
                            {
                                Console.WriteLine($"{Name}: I ate {food[i].FoodName} {food[i].FoodWeight}");
                                _atedFood = _atedFood + food[i].FoodWeight;
                                food[i].FoodWeight = 0;
                            }
                            else
                            {
                                Console.WriteLine($"{Name}: I ate full {food[i].FoodName}");
                                food[i].FoodWeight = food[i].FoodWeight - NeedToEat;
                                _atedFood = _atedFood + NeedToEat;
                            }
                            canEat = true;
                        }
                    }
                    if (!canEat)
                    {
                        Console.WriteLine($"{Name}: I can not eat {food[i].FoodName}");
                    }
                }
                if (_atedFood > _weightFood)
                {
                    throw new ArgumentException($"I can not eat more then {_weightFood}");
                }
            }
        }

        public void IsHungryAndHowMuchFoodHeNeeds()
        {
            if (NeedToEat > 0)
            {
                Console.WriteLine($"{Name}: I am hungry and want to eat {NeedToEat} {ReadFoodfromArray()}");
            }
        }

        public string ReadFoodfromArray()
        {
            string result = $"{Food[0]}";
            for (int i = 1; i < Food.Length; i++)
            {
                result = $"{result} or {Food[i]} ";
            }
            return result;
        }

        public void DoSound()
        {
            Console.WriteLine($"{Name}: {Sound}");
        }

        public void DoPlay()
        {
            if (!IsPredator && _age <= 2)
            {
                Console.WriteLine($"{Name} play with you");
            }
            else if (IsPredator)
            {
                Console.WriteLine($"Play with {Type}-{Name} is dangerous");
            }
        }
    }
}

