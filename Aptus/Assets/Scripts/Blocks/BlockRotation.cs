using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    /// <summary>
    ///     Responsible for block rotation in
    ///     six directions.
    /// </summary>
    public class BlockRotation : MonoBehaviour
    {
        private const float RotationSpeed = 10.0f;

        // The amount in degrees that a block will
        // rotate per rotation request
        private const float RotationStep = 90.0f;

        private Quaternion _rotation = Quaternion.identity;

        private void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, RotationSpeed*Time.deltaTime);

            // If we aren't done SLERPing, the we don't want to capture any user input
            if (transform.rotation != _rotation) return;

            if (Input.GetButtonDown(Controls.Left))
            {
                _rotation = Quaternion.AngleAxis(RotationStep, Vector3.up)*transform.rotation;
            }
            else if (Input.GetButtonDown(Controls.Right))
            {
                _rotation = Quaternion.AngleAxis(-RotationStep, Vector3.up)*transform.rotation;
            }
            else if (Input.GetButtonDown(Controls.Up))
            {
                _rotation = Quaternion.AngleAxis(RotationStep, Vector3.right)*transform.rotation;
            }
            else if (Input.GetButtonDown(Controls.Down))
            {
                _rotation = Quaternion.AngleAxis(-RotationStep, Vector3.right)*transform.rotation;
            }
            else if (Input.GetButtonDown(Controls.RollLeft))
            {
                _rotation = Quaternion.AngleAxis(RotationStep, Vector3.forward)*transform.rotation;
            }
            else if (Input.GetButtonDown(Controls.RollRight))
            {
                _rotation = Quaternion.AngleAxis(-RotationStep, Vector3.forward)*transform.rotation;
            }
        }
    }
}