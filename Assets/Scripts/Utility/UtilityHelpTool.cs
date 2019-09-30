using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ELGame
{
    public class UtilityHelpTool
    {
        //去掉名字中的clone
        public static string RemoveNameClone(string oldName)
        {
            return oldName.Replace("(Clone)", "");
        }

        public static string SetGridPos(Vector3 vector3)
        {
            string TmpPos = "(" + (int) vector3.x + "," + (int) vector3.y + "," + (int) vector3.z + ")";
            return TmpPos;
        }

        public static string ResetName(string name, Vector3 vector)
        {
            return name + "[" + vector.x + "_" + vector.y + "_" + vector.z + "]";
        }

        public static bool isInList(List<int> list, int element)
        {
            foreach (int tmpE in list)
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