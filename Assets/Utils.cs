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

        public static Vector3 MainDirectionVec(this Vector3 vector)
        {
            //face right
            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y) && vector.x > 0)
                return Vector3.right;
            //face left
            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y) && vector.x < 0)
                return Vector3.left;
            //face up
            if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y) && vector.y > 0)
                return Vector3.up;
            //face down
            if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y) && vector.y < 0)
                return Vector3.down;
            return Vector3.zero;
        }

        public static T RandomElementByWeight<T>(this IEnumerable<T> sequence, Func<T, float> weightSelector)
        {
            var enumerable = sequence.ToList();
            var totalWeight = enumerable.Sum(weightSelector);
            // The weight we are after...
            var itemWeightIndex = new System.Random().NextDouble() * totalWeight;
            float currentWeightIndex = 0;

            foreach (var item in enumerable.Select(t => new {Value = t, Weight = weightSelector(t)}))
            {
                currentWeightIndex += item.Weight;
                if (currentWeightIndex >= itemWeightIndex)
                    return item.Value;
            }

            return default(T);
        }
    }
}
