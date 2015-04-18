using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    ///     Provides a generic interface that can build
    ///     blocks of different shapes and sizes.
    /// </summary>
    public abstract class BlockBuilder
    {
        // Radius of the sphere that is used to check if
        // a cube exists at a certain position
        private const float SphereCheckRadius = 0.2f;

        protected Object UnitCube;

        protected BlockBuilder()
        {
            UnitCube = Resources.Load("UnitCube");
        }

        /// <summary>
        ///     Builds a block at a position with the specified number of cubes.
        /// </summary>
        /// <param name="position">Where the block will be built.</param>
        /// <param name="cubeSize">The size of a cube.</param>
        /// <param name="numberOfCubes">The number of cubes to build the block with.</param>
        /// <returns>The created block game-object.</returns>
        public abstract GameObject Build(Vector3 position, float cubeSize, int numberOfCubes);

        protected void CreateCube(Vector3 position)
        {
        }

        /// <summary>
        ///     Gets a random one of the six possible orthogonal direction.
        /// </summary>
        /// <returns>A direction vector that is orthogonal to the world axes.</returns>
        protected Vector3 GetRandomOrthogonalDirection()
        {
            Vector3[] directions =
            {
                Vector3.forward, Vector3.back, Vector3.right, Vector3.left, Vector3.up, Vector3.down
            };
            return directions[Random.Range(0, directions.Length)];
        }

        /// <summary>
        ///     Gets a random position next to and orthogonal to the provided position.
        /// </summary>
        /// <param name="position">The position of which an orthogonal position will be returned.</param>
        /// <param name="cubeSize">The size of a cube.</param>
        /// <returns>An orthogonal position.</returns>
        protected Vector3 GetRandomOrthogonalBlockPosition(Vector3 position, float cubeSize)
        {
            return position + cubeSize*GetRandomOrthogonalDirection();
        }

        protected bool IsCubeAtPosition(Vector3 position)
        {
            return Physics.CheckSphere(position, SphereCheckRadius);
        }
    }
}