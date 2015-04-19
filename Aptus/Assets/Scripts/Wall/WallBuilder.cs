using System.Linq;
using Assets.Scripts.Settings;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Wall
{
    public struct Dimensions
    {
        public int Depth;
        public int Height;
        public int Width;

        public Dimensions(int depth, int height, int width)
        {
            Depth = depth;
            Height = height;
            Width = width;
        }

        public int Volume
        {
            get { return Depth*Height*Width; }
        }
    }

    public class WallBuilder
    {
        protected Object UnitCube;

        public WallBuilder()
        {
            UnitCube = ResourceLoader.Load(Paths.WallUnitCube);
        }

        /// <summary>
        ///     Builds a wall centered at a given position with the given dimensions
        ///     (width = x, height = y, depth = z) and hole through the middle (that
        ///     that 'block' can fit through).
        /// </summary>
        /// <param name="position">The position of the center of the wall.</param>
        /// <param name="dimensions">The dimensions of the wall.</param>
        /// <param name="block">A block object to cut a hole in the wall.</param>
        /// <param name="unitScale">The scale of the unit cubes.</param>
        /// <returns></returns>
        public GameObject Build(Vector3 position, Dimensions dimensions, GameObject block, float unitScale = 1.0f)
        {
            var wall = new GameObject("Wall");
            var totalPosition = Vector3.zero;
            for (var x = 0; x < dimensions.Width; x++)
            {
                for (var y = 0; y < dimensions.Height; y++)
                {
                    for (var z = 0; z < dimensions.Depth; z++)
                    {
                        var go =
                            (GameObject)
                                Object.Instantiate(UnitCube, new Vector3(unitScale*x, unitScale*y, unitScale*z),
                                    Quaternion.identity);
                        go.transform.parent = wall.transform;
                        go.transform.localScale = new Vector3(unitScale, unitScale, unitScale);

                        // We accumulate the positions of the cubes so that we can
                        // find an average position (centroid) of the wall
                        totalPosition += go.transform.position;
                    }
                }
            }

            // The average position of all of the cubes gives us the
            // center of shape that was built
            var averagePosition = totalPosition/dimensions.Volume;

            // Rounding to the nearest multiple of the scale will ensure that the wall's center
            // is placed at the center of the unit cube that is closest to the average position
            var centerPosition = Helper.RoundPositionToNearestMultiple(averagePosition, unitScale);

            // Subtracting the center position on all cubes, brings the shape
            // as a whole to the origin
            var cubes = wall.GetComponentsInChildren<Transform>();
            foreach (var cube in cubes)
            {
                cube.position -= centerPosition;
            }

            // We set the wall's position to the specified position
            wall.transform.position = position;

            PunchHoleThroughWall(wall, block);

            return wall;
        }

        private static void PunchHoleThroughWall(GameObject wall, GameObject block)
        {
            // We raycast from each cube center to the wall and destroy and
            // cubes that are hit. This will create the hole we desire.
            var cubes = block.GetComponentsInChildren<Transform>();
            foreach (var cube in cubes.Where(cube => cube != block.transform))
            {
                RaycastHit hitInfo;
                if (!Physics.Raycast(cube.position, Vector3.forward, out hitInfo, 100.0f, LayerMask.GetMask("Wall")))
                    continue;

                if (hitInfo.transform.parent != wall.transform) continue;

                Object.DestroyObject(hitInfo.collider.gameObject);
            }
        }
    }
}