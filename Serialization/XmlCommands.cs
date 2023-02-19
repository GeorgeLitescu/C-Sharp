using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class XmlCommands
    {

        public void AddItem<T>(List<T> items, T item)
        {
            items.Add(item);
        }

        public T SearchItem<T>(List<T> items, T item)
        {
            foreach (T personFromDB in items)
            {
                if (item.Equals(personFromDB))
                    return personFromDB;
            }

            return default(T);
        }

        public bool RemoveItem<T>(List<T> items,T item)
        {
            try
            {
                items.RemoveAt(items.IndexOf((T)SearchItem(items, item)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
