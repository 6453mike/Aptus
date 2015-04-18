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

        // The scale of a unit-cube that is used to construct a block
        protected float CubeScale;

        protected GameObject UnitCube;

        protected BlockBuilder(float cubeScale = 1.0f)
        {
            CubeScale = cubeScale;
            UnitCube = (GameObject) Resources.Load("UnitCube");

            // Scale the building-cube to the appropriate size
            UnitCube.transform.localScale = new Vector3(CubeScale, CubeScale, CubeScale);
        }

        /// <summary>
        ///     Builds a block at position with the specified number of cubes.
        /// </summary>
        /// <param name="position">Where the block will begin to be built.</param>
        /// <param name="numberOfCubes">The number of cubes to build the block with.</param>
        public abstract void Build(Vector3 position, int numberOfCubes);

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
        /// <returns>An orthogonal position.</returns>
        protected Vector3 GetRandomOrthogonalBlockPosition(Vector3 position)
        {
            return position + CubeScale*GetRandomOrthogonalDirection();
        }

        protected bool IsBlockAtPosition(Vector3 position)
        {
            return Physics.CheckSphere(position, SphereCheckRadius);
        }
    }
}