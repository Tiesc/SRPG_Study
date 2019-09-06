using System.Collections.Generic;

namespace ELGame
{
    public class T
    {
        public static bool isInList(List<T> list, T element)
        {
            foreach (T tmpE in list)
            {
                if (tmpE == element)
                {
                    return true;
                }
            }

            return false;
        }
    }
}