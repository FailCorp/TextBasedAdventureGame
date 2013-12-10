using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Inventory
{
    public class Inventory
    {
        Hashtable inventory = new Hashtable();
        string inventoryItem = string.Empty;
        int inventoryKey = 0;

        public void reset()
        {
            foreach (string invItem in inventory)
            {
                inventory.Remove(invItem);
            }
            
            inventoryKey = 0;
        }

        public void printInventory()
        {
            Console.WriteLine("INVENTORY");
            foreach (string inventoryitem in inventory.Keys)
            {
                Console.WriteLine(inventoryitem.ToUpper());
            }
        }

        public void testInventory()
        {
            for (; inventoryKey < 3; inventoryKey++)
            {
                inventory.Add("Item " + inventoryKey, inventoryKey);
            }
        }

        public void addToInventory(string item)
        {
            if (inventoryKey >= 3)
            {
                inventoryFull(item);
            }

            else
            {
                inventory.Add(item, inventoryKey);
                inventoryKey++;
            }
        }

        public Hashtable getInventory()
        {
            return inventory;
        }

        public void inventoryFull(string itemToGet)
        {
            Console.WriteLine("Your inventory is full. You'll have to drop an item to pick up that " + itemToGet + ".");
            foreach (DictionaryEntry inventoryitem in inventory)
            {
                Console.WriteLine(inventoryitem.Value as string);
            }

            string thingToDrop = Console.ReadLine();

            foreach (string inventoryitem in inventory)
            {
                if (inventoryitem == thingToDrop)
                {
                    inventory.Remove(thingToDrop);

                }

                else
                {
                    continue;
                }
            }
        }

        public void removeFromInventory(string itemToRemove)
        {
            foreach (string item in inventory)
            {
                if (item == itemToRemove)
                {
                    inventory.Remove(itemToRemove);
                    inventoryKey--;
                }
            }
        }
    }
}