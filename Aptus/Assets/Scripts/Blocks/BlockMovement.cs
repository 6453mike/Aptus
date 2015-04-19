using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockMovement : MonoBehaviour
    {
        private const float MovementSpeed = 10.0f;

        private void Update()
        {
            // TODO: This shouldn't be controlled by the user
            if (Input.GetKey(KeyCode.I))
            {
                GetComponent<Rigidbody>()
                    .MovePosition(transform.position + MovementSpeed*Vector3.forward*Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K))
            {
                GetComponent<Rigidbody>().MovePosition(transform.position + MovementSpeed*Vector3.back*Time.deltaTime);
            }
        }
    }
}