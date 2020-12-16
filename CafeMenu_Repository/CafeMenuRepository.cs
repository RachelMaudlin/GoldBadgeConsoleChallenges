using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_Repository
{
    public class CafeMenuRepository
    {
        private List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();

        //CREATE
        public void AddItemToMenu(CafeMenu item)
        {
            _listOfMenuItems.Add(item);
        }

        //READ
        public List<CafeMenu> GetCafeMenu()
        {
            return _listOfMenuItems;
        }

        //UPDATE
        public bool UpdateExistingMenu(int originalMealNumber, CafeMenu newMealNumber)
        {
            //FIND MEAL NUMBER
            CafeMenu oldMenuItem = GetItemByNumber(originalMealNumber);
            //UPDATE CONTENT
            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMealNumber.MealNumber;
                oldMenuItem.MealName = newMealNumber.MealName;
                oldMenuItem.MealDescription = newMealNumber.MealDescription;
                oldMenuItem.MealPrice = newMealNumber.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }


        //DELETE
        public bool RemoveItemFromMenu(int mealNumber)
        {
            CafeMenu item = GetItemByNumber(mealNumber);
            if (item == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(item);
            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER METHOD
        public CafeMenu GetItemByNumber(int mealNumber)
        {
            foreach (CafeMenu item in _listOfMenuItems)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
