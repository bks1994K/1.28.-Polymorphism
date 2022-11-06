using FluentAssertions;

namespace Animals.Tests
{
    public class AviariesTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void AddFoodArraayTest(int mockNumber, int expectedMockNumber)
        {
            Food[] food = FoodArrayMock(mockNumber);
            Aviaries bearsAviaries = new Aviaries(5000, "bearsAviaries", "forest");
            bearsAviaries.AddFood(food);
            Food[] actual = bearsAviaries.Feeder;
            Food[] expected = FoodArrayMock(expectedMockNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 3)]
        [TestCase(1, 4)]
        public void AddFoodTest(int mockNumber, int expectedMockNumber)
        {
            Food food = FoodMock(mockNumber);
            Aviaries bearsAviaries = new Aviaries(5000, "bearsAviaries", "forest");
            bearsAviaries.AddFood(food);
            Food[] actual = bearsAviaries.Feeder;
            Food[] expected = FoodArrayMock(expectedMockNumber);
            Assert.AreEqual(expected, actual);
        }

        private Food[] FoodArrayMock(int index)
        {
            switch (index)
            {
                case 0:
                    return new Food[]
                    {
                        new Food("meat", 100d),
                        new Food("fish", 50.5)
                    };
                case 1:
                    return new Food[]
                   {
                        new Food("bird", 0.5)
                   };
                    break;
                case 2:
                    return new Food[]
                   {
                        new Food("fish", 20d),
                        new Food("grass", 100d),
                        new Food("meat", 15d)
                   };
                case 3:
                    return new Food[]
                   {
                        new Food("meat", 100d)
                   };
                case 4:
                    return new Food[]
                  {
                        new Food("bird", 0.5)
                  };
                default:
                    throw new ArgumentException();
            }
        }

        private Food FoodMock(int index)
        {
            switch (index)
            {
                case 0:
                    return new Food("meat", 100d);
                case 1:
                    return new Food("bird", 0.5);
                default:
                    throw new ArgumentException();
            }
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]

        public void AddAnimalTest_WhenIsEmpty(int mockNumber, int expectedMockNumber)
        {
            Aviaries wildCatsAviaries = new Aviaries(10000, "wildCatsAviaries", "forest");
            AnimalsInZoo animal = AnimalMock(mockNumber);
            wildCatsAviaries.AddAnimal(animal);
            AnimalsInZoo[] actual = wildCatsAviaries.Animals;
            AnimalsInZoo[] expected = AnimalArrayMock(expectedMockNumber);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 3, 0)]
        [TestCase(0, 4, 0)]
        [TestCase(0, 5, 0)]
        
        public void AddAnimalTest_ForPredatorsWhenIsNotEmpty(int mockNumber, int mockAddNumber, int expectedMockNumber)
        {
            //Given
            Aviaries wildCatsAviaries = new Aviaries(10000, "wildCatsAviaries", "forest");
            AnimalsInZoo animal = AnimalMock(mockNumber);
            AnimalsInZoo[] expected = AnimalArrayMock(expectedMockNumber);
            wildCatsAviaries.AddAnimal(animal);
            AnimalsInZoo addAanimal = AnimalMock(mockAddNumber);

            //When
            wildCatsAviaries.AddAnimal(addAanimal);
            AnimalsInZoo[] actual = wildCatsAviaries.Animals;

            //Then
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(1,5,3)]
        [TestCase(1,6,4)]
        [TestCase(1,7,5)]
        [TestCase(1,8,3)]
        [TestCase(1,9,3)]

        public void AddAnimalTest_ForNotPredatorsWhenIsNotEmpty(int mockNumber, int mockAddNumber, int expectedMockNumber)
        {
            //Given
            Aviaries wildCatsAviaries = new Aviaries(5000, "fluffyAviaries", "plain");
            AnimalsInZoo animal = AnimalMock(mockNumber);
            AnimalsInZoo[] expected = AnimalArrayMock(expectedMockNumber);
            wildCatsAviaries.AddAnimal(animal);
            AnimalsInZoo addAanimal = AnimalMock(mockAddNumber);

            //When
            wildCatsAviaries.AddAnimal(addAanimal);
            AnimalsInZoo[] actual = wildCatsAviaries.Animals;

            //Then
            actual.Should().BeEquivalentTo(expected);
        }

        private AnimalsInZoo AnimalMock(int index)
        {
            switch (index)
            {
                case 0:
                    return new AnimalsInZoo("wildCat", "forest", 1500, new[] { "meat", "bird" }, true, "Rrrrr", "Sher-Han", 60, 6);
                case 1:
                    return new AnimalsInZoo("rabbit", "plain", 50, new[] { "grass", "onion", "carrot" }, false, "Piy", "Rodjer", 5, 2);
                case 2:
                    return new AnimalsInZoo("wildCat", "forest", 1000, new[] { "meat" }, true, "Rrr-rr", "Pantera", 30, 2);
                case 3:
                    return new AnimalsInZoo("bear", "forest", 2000, new[] { "meat" }, true, "Byyyer", "Medved", 80, 3);
                case 4:
                    return new AnimalsInZoo("wildCat", "forest", 9500, new[] { "grass" }, true, "Muyu", "Lev", 150, 4);
                case 5:
                    return new AnimalsInZoo("wildCat", "plain", 500, new[] { "meat" }, true, "MuyuRR", "Rys", 30, 1);
                case 6:
                    return new AnimalsInZoo("rabbit", "plain", 1000, new[] { "onion" }, false, "Puiy", "Krol1", 2, 1);
                case 7:
                    return new AnimalsInZoo("hare", "plain", 1500, new[] { "carrot" }, false, "Puiy", "Zaez1", 4, 2);
                case 8:
                    return new AnimalsInZoo("hare", "plain", 4990, new[] { "grass", "onion", }, false, "Puiuiiy", "Zaez2", 4, 2);
                case 9:
                    return new AnimalsInZoo("rabbit", "taiga", 120, new[] { "grass", "carrot", }, false, "Puiuiioiy", "Krol2", 8, 4);
                default:
                    throw new ArgumentException();
            }
        }

        private AnimalsInZoo[] AnimalArrayMock(int index)
        {
            switch (index)
            {
                case 0:
                    return new AnimalsInZoo[]
                    {
                        new AnimalsInZoo("wildCat", "forest", 1500, new[] { "meat", "bird" }, true, "Rrrrr", "Sher-Han", 60, 6)
                    };
                case 1:
                    return new AnimalsInZoo[] { };
                case 2:
                    return new AnimalsInZoo[]
                    {
                        new AnimalsInZoo("wildCat", "forest", 1500, new[] { "meat", "bird" }, true, "Rrrrr", "Sher-Han", 60, 6),
                        new AnimalsInZoo("wildCat", "forest", 1000, new[] { "meat" }, true, "Rrr-rr", "Pantera", 30, 2),
                    };
                case 3:
                    return new AnimalsInZoo[]
                    {
                        new AnimalsInZoo("rabbit", "plain", 50, new[] { "grass", "onion", "carrot" }, false, "Piy", "Rodjer", 5, 2)
                    };
                case 4:
                    return new AnimalsInZoo[]
                    {
                        new AnimalsInZoo("rabbit", "plain", 50, new[] { "grass", "onion", "carrot" }, false, "Piy", "Rodjer", 5, 2),
                        new AnimalsInZoo("rabbit", "plain", 1000, new[] { "onion" }, false, "Puiy", "Krol1", 2, 1)
                    };
                case 5:
                    return new AnimalsInZoo[]
                    {
                        new AnimalsInZoo("rabbit", "plain", 50, new[] { "grass", "onion", "carrot" }, false, "Piy", "Rodjer", 5, 2),
                        new AnimalsInZoo("hare", "plain", 1500, new[] { "carrot" }, false, "Puiy", "Zaez1", 4, 2)
                    };
                default:
                    throw new ArgumentException();
            }
        }
    }
}
