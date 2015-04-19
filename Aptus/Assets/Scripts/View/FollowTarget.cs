using UnityEngine;

namespace Assets.Scripts.View
{
    /// <summary>
    ///     The game-object that this is attached to will follow
    ///     a target that is set and will always stay at the same distance
    ///     as when the target was set.
    /// </summary>
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5.0f;

        private Vector3 _relativePositionToTarget;
        private Transform _target;

        public Transform Target
        {
            get { return _target; }
            set
            {
                _target = value;
                _relativePositionToTarget = transform.position - _target.position;
            }
        }

        private void Update()
        {
            if (Target == null) return;

            transform.position = Vector3.Lerp(transform.position, Target.position + _relativePositionToTarget,
                _movementSpeed*Time.deltaTime);
        }
    }
}