namespace Animals
{
    public class Aviaries
    {
        private int _habitatArea;
        private int _remainingHabitatArea;
        public string Name { get; set; }

        public string Habitat { get; set; }

        /// <summary>
        /// Кормушка - сколько сейчас еды
        /// </summary>
        public Food[] Feeder { get; set; }

        public int HabitatArea
        {
            get
            {
                return _habitatArea;
            }
            set
            {
                if (value > 0)
                { _habitatArea = value; }
            }
        }

        public AnimalsInZoo[] Animals { get; private set; }

        public Aviaries(int habitatArea, string name, string habitat)
        {
            HabitatArea = habitatArea;
            _remainingHabitatArea = _habitatArea;
            Name = name;
            Habitat = habitat;
            Animals = new AnimalsInZoo[0];
            Feeder = new Food[0];
        }

        public void AddAnimal(AnimalsInZoo animal)
        {
            if (Animals.Contains(animal))
                return;

            if (Habitat != animal.Habitat)
            {
                Console.WriteLine($"{Habitat} of Aviary does not match with {animal.Habitat} of {animal.Type} {animal.Name}");
                return;
            }
            if (animal.HabitatArea >= _remainingHabitatArea)
            {
                Console.WriteLine($"{HabitatArea} less then {animal.Type} {animal.Name} need");
                return;
            }

            if (Animals.Length > 0)
            {
                bool canAdd = true;
                if (animal.IsPredator)
                {
                    for (int i = 0; i < Animals.Length; i++)
                    {
                        if (!Animals[i].IsPredator || Animals[i].Type != animal.Type)
                        {
                            Console.WriteLine($"{animal.Type} {animal.Name} can not lives in this Aviary with other animals: {Animals[i].Type}");
                            canAdd = false;
                            break;
                        }
                    }
                }
                else if (!animal.IsPredator)
                {
                    for (int i = 0; i < Animals.Length; i++)
                    {
                        if (Animals[i].IsPredator)
                        {
                            canAdd = false;
                            Console.WriteLine($"{animal.Type} {animal.Name} can not lives in this Aviary with predator {Animals[i].Type}");
                            break;
                        }

                    }
                }
                if (canAdd)
                {
                    AnimalsInZoo[] updatedAnimal = new AnimalsInZoo[Animals.Length + 1];
                    for (int i = 0; i < Animals.Length; i++)
                    {
                        updatedAnimal[i] = Animals[i];
                    }
                    updatedAnimal[updatedAnimal.Length - 1] = animal;
                    Animals = updatedAnimal;
                    _remainingHabitatArea = _remainingHabitatArea - animal.HabitatArea;
                }

            }
            else
            {
                Animals = new AnimalsInZoo[1] { animal };
                _remainingHabitatArea = _remainingHabitatArea - animal.HabitatArea;
            }
        }


        public void AddAnimals(AnimalsInZoo[] animal)
        {
            for (int i = 0; i < animal.Length; i++)
            {
                AddAnimal(animal[i]);
            }
        }

        public void RemoveAnimal(AnimalsInZoo animal)
        {
            if (Animals.Length >= 1)
            {
                AnimalsInZoo[] updatedAnimal = new AnimalsInZoo[Animals.Length - 1];
                int j = 0;
                bool isRemoved = false;
                for (int i = 0; i < Animals.Length - 1; i++)
                {
                    if (animal != Animals[i])
                    {
                        updatedAnimal[j] = Animals[i];
                        j = j + 1;
                    }
                    else
                    {
                        isRemoved = true;
                    }
                }
                if (isRemoved)
                {
                    updatedAnimal[updatedAnimal.Length - 1] = Animals[Animals.Length - 1];
                    Animals = updatedAnimal;
                }
                else if (animal == Animals[Animals.Length - 1])
                {
                    Animals = updatedAnimal;
                }
            }
        }

        public void FeedAll()
        {
            for (int k = 0; k < Animals.Length; k++)
            {
                Animals[k].DoEat(Feeder);
            }
            int count = 0;
            for (int j = 0; j < Feeder.Length; j++)
            {
                if (Feeder[j].FoodWeight == 0)
                {
                    count++;
                }
            }
            Food[] updatedFeeder = new Food[Feeder.Length - count];
            int tmp = 0;
            for (int i = 0; i < Feeder.Length; i++)
            {
                if (Feeder[i].FoodWeight != 0)
                {
                    updatedFeeder[tmp] = Feeder[i];
                    tmp++;
                }
            }
            Feeder = updatedFeeder;
        }

        public void HowMuchFoodInAviaries()
        {
            if (Feeder.Length > 0)
            {
                for (int i = 0; i < Feeder.Length; i++)
                {
                    Console.WriteLine($"There are {Feeder[i].FoodWeight} {Feeder[i].FoodName} left in Aviary");
                }
            }
            else
            {
                Console.WriteLine($"There are empty");
            }
        }

        public void AddFood(Food food)
        {
            Food[] newFood = new Food[Feeder.Length + 1];
            for (int i = 0; i < Feeder.Length; i++)
            {
                newFood[i] = Feeder[i];
            }
            newFood[Feeder.Length] = food;
            Feeder = newFood;
        }

        public void AddFood(Food[] food)
        {
            for (int i = 0; i < food.Length; i++)
            {
                AddFood(food[i]);
            }
        }

        public void WhoIsHungryAndHowMuchFoodHeNeeds()
        {
            for (int i = 0; i < Animals.Length; i++)
            {
                Animals[i].IsHungryAndHowMuchFoodHeNeeds();
            }
        }

        public void WhoInAviary()
        {
            string result = "There are now ";
            if (Animals.Length == 0)
            {
                Console.WriteLine(result + "empty");
            }
            else
            {
                for (int i = 0; i < Animals.Length - 1; i++)
                {
                    result = result + Animals[i].Name + ", ";
                }
                Console.WriteLine(result + Animals[Animals.Length - 1].Name);
            }
        }


        public void DoSoundAll()
        {
            for (int i = 0; i < Animals.Length; i++)
            {
                Animals[i].DoSound();
            }
        }
    }
}
