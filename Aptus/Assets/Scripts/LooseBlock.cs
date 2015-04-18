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
        public override GameObject Build(Vector3 position, float cubeSize, int numberOfCubes)
        {
            var block = new GameObject("Block");

            // We keep track of the current cube position (the most recently
            // created cube) so that we can construct a shape that is not disconnected
            var currentCubePosition = position;
            var totalPosition = Vector3.zero;
            for (var i = 0; i < numberOfCubes; i++)
            {
                Vector3 tempPosition;
                do
                {
                    // Get a random position adjacent to the current cube
                    tempPosition = GetRandomOrthogonalBlockPosition(currentCubePosition, cubeSize);
                } while (IsCubeAtPosition((tempPosition)));

                var go = (GameObject) Object.Instantiate(UnitCube, tempPosition, Quaternion.identity);
                go.transform.parent = block.transform;
                go.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

                currentCubePosition = tempPosition;

                // We accumulate the positions of the cubes so that we can
                // find an average position (centroid) of the block
                totalPosition += tempPosition;
            }

            // The average position of all of the cubes gives us the
            // center of shape that was built
            var averagePosition = totalPosition/numberOfCubes;

            // Subtracting the average position on all cubes, brings the shape
            // as a whole to the origin
            var cubes = block.GetComponentsInChildren<Transform>();
            foreach (var cube in cubes)
            {
                cube.position -= averagePosition;
            }

            // We set the block's position to the specified position
            block.transform.position = position;

            return block;
        }
    }
}