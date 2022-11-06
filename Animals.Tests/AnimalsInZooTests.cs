
namespace Animals.Tests
{
    public class AnimalsInZooTests
    {
        [TestCase(0, 50.5)]
        [TestCase(1, 10.5)]
        [TestCase(2, 35d)]
        [TestCase(3, 50.5)]
        [TestCase(4, 11d)]
        [TestCase(5, 50.5)]
        [TestCase(6, 40d)]
        [TestCase(7, 50.5)]
        [TestCase(8, 50.5)]
        [TestCase(9, 20.5)]
        [TestCase(10, 0d)]
        [TestCase(11, 0d)]

        public void DoEatTest(int mockNumber, double expected)
        {
            Food[] food = FoodMock(mockNumber);
            AnimalsInZoo bear = new AnimalsInZoo("bear", "forest", 1000, new[] { "fish", "meat" }, true, "Byyyyeer", "Vinni", 50.5, 3);
            bear.DoEat(food);
            double actual = bear.AtedFood;
            Assert.AreEqual(expected, actual);
        }


        private Food[] FoodMock(int index)
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
                        new Food("fish", 0.5),
                        new Food("meat", 10d)
                   };
                case 2:
                    return new Food[]
                   {
                        new Food("fish", 20d),
                        new Food("grass", 10d),
                        new Food("meat", 15d)
                   };
                case 3:
                    return new Food[]
                   {
                        new Food("bird", 10.5),
                        new Food("fish", 40d),
                        new Food("meat", 15d)
                   };
                case 4:
                    return new Food[]
                   {
                        new Food("bird", 5d),
                        new Food("meat", 0.5),
                        new Food("fish", 10.5)
                   };
                case 5:
                    return new Food[]
                   {
                        new Food("fish", 50d),
                        new Food("meat", 0.5),
                        new Food("mouse", 10.5)
                   };
                case 6:
                    return new Food[]
                   {
                        new Food("meat", 40d),
                        new Food("mouse", 10.5)
                   };
                case 7:
                    return new Food[]
                   {
                        new Food("grass", 20d),
                        new Food("fish", 50.5)
                   };
                case 8:
                    return new Food[]
                   {
                        new Food("meat", 200d)
                   };
                case 9:
                    return new Food[]
                   {
                        new Food("fish", 20.5)
                   };
                case 10:
                    return new Food[]
                   {
                        new Food("fruit", 25d)
                   };
                case 11:
                    return new Food[]
                   {
                        new Food("", 25d)
                   };
                default:
                    throw new ArgumentException();
            }
        }
    }
}


