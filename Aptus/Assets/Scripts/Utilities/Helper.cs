using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class Helper
    {
        private static readonly Vector3[] Directions =
        {
            Vector3.forward, Vector3.back, Vector3.right, Vector3.left, Vector3.up, Vector3.down
        };

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

        /// <summary>
        ///     Gets a random one of the six possible orthogonal direction.
        /// </summary>
        /// <returns>A direction vector that is orthogonal to the world axes.</returns>
        public static Vector3 GetRandomOrthogonalDirection()
        {
            return Directions[Random.Range(0, Directions.Length)];
        }

        /// <summary>
        ///     Gets a random position next to and orthogonal to the provided position.
        /// </summary>
        /// <param name="position">The position of which an orthogonal position will be returned.</param>
        /// <param name="unitScale">The scale of a cube.</param>
        /// <returns>An orthogonal position.</returns>
        public static Vector3 GetRandomOrthogonalBlockPosition(Vector3 position, float unitScale)
        {
            return position + unitScale*GetRandomOrthogonalDirection();
        }

        /// <summary>
        ///     Given a block, will randomly orient it.
        /// </summary>
        /// <param name="block">The block to randomly orient.</param>
        public static void RandomlyOrientate(GameObject block)
        {
            block.transform.rotation = Quaternion.LookRotation(Directions[Random.Range(0, Directions.Length)]);
        }
    }
}