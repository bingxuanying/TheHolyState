using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class Utils
    {
        public static float Area(this Rect rect)
        {
            return (rect.yMax - rect.yMin) * (rect.xMax - rect.xMin);
        }

        public static int MainDirection(this Vector3 vector)
        {
            //face right
            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y) && vector.x > 0)
                return 3;
            //face left
            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y) && vector.x < 0)
                return 1;
            //face up
            if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y) && vector.y > 0)
                return 2;
            //face down
            if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y) && vector.y < 0)
                return 0;
            return 0;
        }
    }
}
