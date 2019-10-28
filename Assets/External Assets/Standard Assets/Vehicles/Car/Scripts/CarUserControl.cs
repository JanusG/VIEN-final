using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float steering = CrossPlatformInputManager.GetAxis("Axis4 RightHorizontal");
            float rev = CrossPlatformInputManager.GetAxis("Axis5 RightVertical");
            float accel = CrossPlatformInputManager.GetAxis("Axis10_RightTrigger");
            float leftTrigger = CrossPlatformInputManager.GetAxis("Axis9_LeftTrigger");
            // Debug.Log( "rightTrigger: " + accel);
            // Debug.Log( "leftTrigger: " + leftTrigger);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Axis12 RightGrip");
            m_Car.Move(steering, accel, rev, handbrake);
#else
            m_Car.Move(steering, accel, rev, 0f);
#endif
        }
    }
}
