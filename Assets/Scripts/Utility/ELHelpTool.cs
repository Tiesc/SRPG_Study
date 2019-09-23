using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ELGame
{
    public class ELHelpTool
    {
        struct Hex
        {
            private int _AxleQ, _AxleS, _AxleR;

            public Vector3 getAxle()
            {
                if (_AxleQ + _AxleS + _AxleR == 0)
                {
                    Vector3 vector = new Vector3(_AxleQ, _AxleS, _AxleR);
                    return vector;
                }

                return default;
            }

            public void setAxle(int x, int y)
            {
                _AxleQ = x;
                _AxleS = y;
                _AxleR = -x - y;
            }
        }

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