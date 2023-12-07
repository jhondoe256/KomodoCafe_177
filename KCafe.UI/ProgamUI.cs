

using KCafe.Data;
using KCafe.Repository;

namespace KCafe.UI
{
    public class ProgamUI
    {
        private readonly MenuItemRepository _menuRepo;

        public ProgamUI()
        {
            _menuRepo = new MenuItemRepository();
        }

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome To McDonald's Admin Menu\n" +
                                        "1. Add A Meal\n" +
                                        "2. Get All Meals\n" +
                                        "3. Delete Existing Meal\n" +
                                        "---------------------------\n" +
                                        "00. Close App\n");

                int userInput = int.Parse(Console.ReadLine()!);
                switch (userInput)
                {
                    case 1:
                        AddAMeal();
                        break;
                    case 2:
                        GetAllMeals();
                        break;
                    case 3:
                        DelteExistingMeal();
                        break;
                    case 00:
                        isRunning = CloseApp();
                        break;
                    default:
                        System.Console.WriteLine("Invalid Key. Try Again.");
                        break;
                }
            }
        }

        private bool CloseApp()
        {
            Console.Clear();
            System.Console.WriteLine("Thx.");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press any Key to continue.");
            Console.ReadKey();
        }

        private void DelteExistingMeal()
        {
            Console.Clear();
            List<MenuItem> itemsInDb = _menuRepo.GetItems();
            if (itemsInDb.Count() > 0)
            {
                foreach (var item in itemsInDb)
                {
                    System.Console.WriteLine($"Id: {item.MealNumber} - Name: {item.MealName}");
                }
                System.Console.WriteLine();
                System.Console.Write("Please select an Id: ");
                int userInput = int.Parse(Console.ReadLine()!);
                if (_menuRepo.DeleteMenuItem(userInput))
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Fail!");
                }
            }
            else
            {
                System.Console.WriteLine("Sorry, no Menu Items at this time.");
            }

            PressAnyKey();
        }


        private void GetAllMeals()
        {
            Console.Clear();
            //this is a 'fetch' going to database to find some data
            List<MenuItem> itemsInDb = _menuRepo.GetItems();
            System.Console.WriteLine("== Meal Menu ==");
            if (itemsInDb.Count() > 0)
            {
                foreach (var item in itemsInDb)
                {
                    System.Console.WriteLine(item);
                }
            }
            else
            {
                System.Console.WriteLine("Sorry, no Menu Items at this time.");
            }

            PressAnyKey();
        }


        private void AddAMeal()
        {
            //make a new instance of the MenuItem type
            // this 'item' is empty
            MenuItem item = new MenuItem();

            //Ask the user questions based on the properties on a MenuItem obj
            Console.Write("Enter a Meal Name: ");
            item.MealName = Console.ReadLine()!;

            System.Console.Write("Enter a Description: ");
            item.Description = Console.ReadLine()!;

            System.Console.Write("Enter a Price: ");
            item.Price = Convert.ToDecimal(Console.ReadLine()!);

            while (true)
            {
                System.Console.WriteLine("Do you want to add Ingrdients. y/n");
                string user_input_YN = Console.ReadLine()!;
                if (user_input_YN == "Y".ToLower())
                {
                    System.Console.Write("Enter an Ingredient: ");
                    string ingredient = Console.ReadLine()!;
                    item.Ingredients.Add(ingredient);
                    continue;
                }
                else
                {
                    break;
                }
            }

            //we need to interact with the database! (_menuRepo)
            if (_menuRepo.AddMenuItem(item))
            {
                System.Console.WriteLine("Success!");
            }
            else
            {
                System.Console.WriteLine("Fail!");
            }

            PressAnyKey();
        }
    }
}