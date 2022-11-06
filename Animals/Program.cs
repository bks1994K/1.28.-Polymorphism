using Animals;

AnimalsInZoo[] bears = new AnimalsInZoo[]
    {
    new AnimalsInZoo("bear", "forest", 1000, new []{"fish", "meat"}, true, "Byyyyeer", "Vinni", 50.5, 3),
    new AnimalsInZoo("bear", "forest", 1000, new []{"fish", "meat"}, true, "Byyyyeer", "Puh", 30, 1),
    };

AnimalsInZoo rabbit = new AnimalsInZoo("rabbit", "plain", 50, new[] { "grass", "onion", "carrot" }, false, "Piy", "Rodjer", 5, 2);

AnimalsInZoo[] hares = new AnimalsInZoo[]
    {
    new AnimalsInZoo("hare", "forest", 90, new[] { "grass", "carrot"}, false, "Pzpzp", "ZaezOne", 7, 3),
    new AnimalsInZoo("hare", "plain", 100, new[] { "grass", "onion"}, false, "Pzpzp", "ZaezTwo", 9, 5),
    };

AnimalsInZoo tiger = new AnimalsInZoo("wildCat", "forest", 1500, new[] { "meat", "bird" }, true, "Rrrrr", "Sher-Han", 60, 6);

AnimalsInZoo[] spottedCats = new AnimalsInZoo[]
    {
    new AnimalsInZoo("wildCat", "forest", 1200, new[] { "meat", "mouse"}, true, "Rrrrr", "Jaguar", 50, 3),
    new AnimalsInZoo("wildCat", "forest", 1700, new[] { "bird", "meat", "fish"}, true, "rrrr", "Cheetah", 45, 3),
    new AnimalsInZoo("domesticCat", "city", 800, new[] { "meat"}, true, "Myu", "Bengal", 15, 10),
    };

Aviaries bearsAviaries = new Aviaries(5000, "bearsAviaries", "forest");
Aviaries wildCatsAviaries = new Aviaries(10000, "wildCatsAviaries", "forest");
Aviaries fluffyAviaries = new Aviaries(400, "fluffyAviaries", "plain");

//bearsAviaries.AddAnimals(bears);
//wildCatsAviaries.AddAnimal(tiger);
//fluffyAviaries.AddAnimals(new[] { hares[0], hares[1], rabbit });

bearsAviaries.AddAnimal(bears[0]);
bearsAviaries.AddAnimal(tiger);
bearsAviaries.AddAnimals(hares);
bearsAviaries.AddAnimals(bears);
bearsAviaries.WhoInAviary();
Console.WriteLine();

fluffyAviaries.AddAnimal(rabbit);
fluffyAviaries.AddAnimals(hares);
fluffyAviaries.AddAnimals(spottedCats);
fluffyAviaries.WhoInAviary();
Console.WriteLine();

fluffyAviaries.DoSoundAll();
wildCatsAviaries.DoSoundAll();
bearsAviaries.DoSoundAll();


Food bearsFoodMeat1 = new Food ("meat", 100d);
Food bearsFoodMeat2 = new Food("meat", 20d);
Food bearsFoodFish = new Food("fish", 100d);

Food CatsFoodMeat = new Food("meat", 100d);
Food CatsFoodBird = new Food("bird", 80d);

Food FluffyFoodCarrot = new Food("carrot", 30d);
Food FluffyFoodGrass = new Food("grass", 30d);

bearsAviaries.AddFood(new[] { bearsFoodMeat1, bearsFoodFish });
wildCatsAviaries.AddFood(CatsFoodBird);
fluffyAviaries.AddFood(FluffyFoodGrass);


//bears[0].DoEat(new[] { bearsFoodMeat1 });
//bearsAviaries.HowMuchFoodInAviaries();
//bearsAviaries.WhoInAviary();
//Console.WriteLine();

//wildCatsAviaries.FeedAll();
//wildCatsAviaries.HowMuchFoodInAviaries();
//wildCatsAviaries.WhoInAviary();
//Console.WriteLine();

//rabbit.DoEat(new[] { FluffyFoodGrass });
//fluffyAviaries.FeedAll();
//fluffyAviaries.HowMuchFoodInAviaries();
//fluffyAviaries.WhoInAviary();
//Console.WriteLine("");
