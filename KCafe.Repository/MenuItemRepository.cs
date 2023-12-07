using KCafe.Data;

namespace KCafe.Repository
{
    public class MenuItemRepository
    {
        private List<MenuItem> _menuDb = new List<MenuItem>();
        //what I use to change the Id (Pk)
        private int _counter = 0;

        //?C.
        public bool AddMenuItem(MenuItem item)
        {
            //check to see if 'item' is valid data.
            if(item is null)
            {
                return false;
            }
            else
            {
                _counter++;
                item.MealNumber = _counter;
                _menuDb.Add(item);
                return true;
            }
        }

        //?R.
        public List<MenuItem> GetItems()
        {
            return _menuDb;
        }
        
        //?U.
        
        
        //?D.
        public bool DeleteMenuItem(int id)
        {
            MenuItem itemInDb = _menuDb.FirstOrDefault(x => x.MealNumber == id)!;
            return _menuDb.Remove(itemInDb);
        }




    }
}