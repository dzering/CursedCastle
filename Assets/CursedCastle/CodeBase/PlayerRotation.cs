using UnityEngine;
using Input = CursedCastle.InputSystem.Input;

namespace CursedCastle.CodeBase
{
    public class PlayerRotation : MonoBehaviour
    {
        private float _yaw;
        private Input _input;
        private readonly float _deltaTimeMultiplier = 1f;

        public void Construct(Input input)
        {
            _input = input;
        }
        void Start()
        {
            _yaw = transform.rotation.eulerAngles.x;
        }

        // Update is called once per frame
        void Update()
        {
            _yaw += _input.Look.x * _deltaTimeMultiplier;
            _yaw = ClampAngle(_yaw, float.MinValue, float.MaxValue);
        
            transform.rotation = Quaternion.Euler(0f, _yaw, 0.0f);
        }
    
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}
