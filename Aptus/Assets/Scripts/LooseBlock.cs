using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    ///     A loose block is a shape where the cubes that it is
    ///     composed of aren't necessarily densely positioned. When
    ///     the number of cubes is high, the block looks stringy as
    ///     opposed to a compact shape.
    /// </summary>
    public class LooseBlock : BlockBuilder
    {
        public LooseBlock(float cubeScale = 1.0f)
            : base(cubeScale)
        {
        }

        public override void Build(Vector3 position, int numberOfCubes)
        {
            var currentBlockPosition = position;
            for (var i = 0; i < numberOfCubes; i++)
            {
                Vector3 tempPosition;
                do
                {
                    tempPosition = GetRandomOrthogonalBlockPosition(currentBlockPosition);
                } while (IsBlockAtPosition((tempPosition)));

                Object.Instantiate(UnitCube, tempPosition, Quaternion.identity);
                currentBlockPosition = tempPosition;
            }
        }
    }
}