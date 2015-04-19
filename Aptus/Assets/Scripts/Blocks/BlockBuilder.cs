using Assets.Scripts.Settings;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Blocks
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
            UnitCube = ResourceLoader.Load(Paths.BlockUnitCube);
        }

        /// <summary>
        ///     Builds a block at a position with the specified number of cubes.
        /// </summary>
        /// <param name="position">Where the block will be built.</param>
        /// <param name="numberOfCubes">The number of cubes to build the block with.</param>
        /// <param name="unitScale">The scale of a cube.</param>
        /// <returns>The created block game-object.</returns>
        public abstract GameObject Build(Vector3 position, int numberOfCubes, float unitScale = 1.0f);

        protected bool IsCubeAtPosition(Vector3 position)
        {
            return Physics.CheckSphere(position, SphereCheckRadius);
        }
    }
}