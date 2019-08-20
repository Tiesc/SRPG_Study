using UnityEngine;

namespace ELGame
{
    public class ELHelpTool
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
    }
}