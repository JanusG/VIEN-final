using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
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
            float rev = 0;
            float accel = 0;
            // pass the input to the car!
            float steering = CrossPlatformInputManager.GetAxis("Axis4 RightHorizontal");
            if (Input.GetAxis("Axis12 RightGrip") > 0.5)
            {
                rev = CrossPlatformInputManager.GetAxis("Axis10_RightTrigger");
            }
            else
            {
                accel = CrossPlatformInputManager.GetAxis("Axis10_RightTrigger");
            }

            // Debug.Log( "rightTrigger: " + accel);
            // Debug.Log( "leftTrigger: " + leftTrigger);
            float handbrake = CrossPlatformInputManager.GetAxis("Axis12 RightGrip");
#if !MOBILE_INPUT

            m_Car.Move(steering, accel, -rev, handbrake);
#else
            m_Car.Move(steering, accel, rev, 0f);
#endif
        }
    }
}
