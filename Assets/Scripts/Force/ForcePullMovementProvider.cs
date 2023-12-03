/*
 * From Oculus SDK MoveTowardsTargetProvider 
 */

using UnityEngine;

namespace Oculus.Interaction.HandGrab
{
    public class ForcePullMovementProvider : MonoBehaviour, IMovementProvider
    {
        [SerializeField]
        private PoseTravelData _travellingData = PoseTravelData.FAST;

        [SerializeField]
        private float _offsetFromHand = .1f;

        public IMovement CreateMovement()
        {
            return new ForcePullMovement(_travellingData, _offsetFromHand);
        }

        #region Inject
        public void InjectAllMoveTowardsTargetProvider(PoseTravelData travellingData)
        {
            InjectTravellingData(travellingData);
        }

        public void InjectTravellingData(PoseTravelData travellingData)
        {
            _travellingData = travellingData;
        }
        #endregion
    }

    public class ForcePullMovement : IMovement
    {
        private PoseTravelData _travellingData;
        private float _offsetFromHand;
        public Pose Pose => _tween.Pose;
        public bool Stopped => _tween != null && _tween.Stopped;

        private Tween _tween;
        private Pose _source;
        private Pose _target;


        public ForcePullMovement(PoseTravelData travellingData, float offsetFromhand)
        {
            _travellingData = travellingData;
            _offsetFromHand = offsetFromhand;
        }

        public void MoveTo(Pose target)
        {
            _target = target;
            _tween = _travellingData.CreateTween(_source, target);
        }

        public void UpdateTarget(Pose target)
        {
            if (_target != target)
            {
                _target = target;
                // Move position to 
                _target.position.y += _offsetFromHand;
                _tween.UpdateTarget(_target);
            }
        }

        public void StopAndSetPose(Pose pose)
        {
            _source = pose;
            _tween?.StopAndSetPose(_source);
        }

        public void Tick()
        {
            _tween.Tick();
        }
    }
}
