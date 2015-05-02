using Assets.Scripts.Blocks;
using Assets.Scripts.Utilities;
using Assets.Scripts.View;
using Assets.Scripts.Wall;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        private void Awake()
        {
            BlockBuilder b = new LooseBlock();
            var block = b.Build(new Vector3(0.0f, 0.0f, 0.0f), 8, 0.5f);
            block.AddComponent<BlockCollision>();
            var r = block.AddComponent<Rigidbody>();
            r.useGravity = false;
            block.AddComponent<BlockRotation>();
            block.AddComponent<BlockMovement>();


            Camera.main.GetComponent<PanTarget>().Target = block.transform;

            var w = new WallBuilder();
            var wall = w.Build(new Vector3(0.0f, 0.0f, 20.0f), new Dimensions(1, 21, 21), block, 0.5f);

            Helper.RandomlyOrientate(block);
        }
    }
}