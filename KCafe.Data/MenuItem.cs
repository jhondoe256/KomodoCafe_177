namespace KCafe.Data
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(string mealName, string description, List<string> ingredients, decimal price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        
        //PK
        public int MealNumber { get; set; }
        public string MealName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }

        public override string ToString()
        {
            string str = $"MealNumber: {MealNumber}\n"+
                         $"MealName: {MealName}\n"+
                         $"Description: {Description}\n"+
                         $"Price: {Price}\n"+
                         "================ Ingredients =================\n";
            if(Ingredients.Count() > 0)
            {
                foreach (string ing in Ingredients)
                {
                    str += $"{ing}\n";
                }
            }
            else
            {
                str += "Sorry no Ingredients available.";
            }

            return str;
        }
    }
}