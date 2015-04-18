using Assets.Scripts.Blocks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            BlockBuilder b = new LooseBlock();
            var block = b.Build(new Vector3(0.0f, 0.0f, 0.0f), 0.5f, 20);

            block.AddComponent<BlockRotation>();
        }
    }
}