using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class PanTarget : MonoBehaviour
    {
        // The maximum rotation from the starting position
        // about each axis that is allowed
        private float _maxRotationX = 60.0f;
        private float _maxRotationY = 65.0f;

        [SerializeField] private float _mouseSensitivityX = 10.0f;
        [SerializeField] private float _mouseSensitivityY = 10.0f;

        private Vector3 _originalRelativePosition;

        // Rotation about the target, with (0, 0)
        // being the starting original rotation
        private float _rotationX;
        private float _rotationY;

        private Transform _target;

        public Transform Target
        {
            get { return _target; }
            set
            {
                _target = value;
                _originalRelativePosition = transform.position - _target.position;
            }
        }

        private void Update()
        {
            // We can't pan without a target
            if (Target == null) return;

            _rotationX += -Input.GetAxis(Controls.MouseY)*_mouseSensitivityY*Time.deltaTime;
            _rotationY += Input.GetAxis(Controls.MouseX)*_mouseSensitivityX*Time.deltaTime;

            _rotationX = Mathf.Clamp(_rotationX, -_maxRotationX, _maxRotationX);
            _rotationY = Mathf.Clamp(_rotationY, -_maxRotationY, _maxRotationY);

            // Rotate our relative position
            var rotatedRelativeDirection = Quaternion.Euler(_rotationX, _rotationY, 0.0f)*_originalRelativePosition;

            // Calculate our world position relative to the target
            transform.position = rotatedRelativeDirection + Target.position;

            transform.LookAt(Target);
        }
    }
}