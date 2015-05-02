using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            print("collided");
        }
    }
}