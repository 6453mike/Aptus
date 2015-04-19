using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Helper
    {
        /// <summary>
        ///     Given a position, will round each component to the nearest
        ///     multiple of 'multiple'. For example: Given a position of (1.7, 1.2, 0.3)
        ///     and a multiple of 0.5, we will return (1.5, 1.0, 0.5).
        /// </summary>
        /// <param name="position">The position to round.</param>
        /// <param name="multiple">The multiple to round to.</param>
        /// <returns></returns>
        public static Vector3 RoundPositionToNearestMultiple(Vector3 position, float multiple)
        {
            position.x = Mathf.Round(position.x/multiple)*multiple;
            position.y = Mathf.Round(position.y/multiple)*multiple;
            position.z = Mathf.Round(position.z/multiple)*multiple;

            return position;
        }
    }
}