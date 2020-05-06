using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

namespace KM
{
    public class InputHandler : MonoBehaviour
    {
        //Left stick
        float vertical;
        float horizontal;

        //Gamepad face buttons
        bool n_input;
        bool e_input;
        bool s_input;
        bool w_input;

        //Triggers
        bool r1_input;
        float r2_value;
        bool r2_input;
        bool l1_input;
        float l2_value;
        bool l2_input;

        StateManager states;
        CameraManager camManager;

        float delta;

        // Start is called before the first frame update
        void Start()
        {
            states = GetComponent<StateManager>();
            states.Init();

            camManager = CameraManager.singleton;
            camManager.Init(this.transform);
        }

        void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            GetInput();
            UpdateStates();

            states.FixedTick(delta);
            camManager.Tick(delta);
        }

        void Update()
        {
            delta = Time.deltaTime;
            states.Tick(delta);
        }

        void GetInput()
        {
            // Use last device which provided input.
            var inputDevice = InputManager.ActiveDevice;

            vertical = inputDevice.LeftStickY;
            horizontal = inputDevice.LeftStickX;

            n_input = inputDevice.Action4.WasPressed;
            e_input = inputDevice.Action2.IsPressed;
            s_input = inputDevice.Action1.IsPressed;
            w_input = inputDevice.Action3.IsPressed;

            r1_input = inputDevice.RightBumper.IsPressed;
            r2_value = inputDevice.RightTrigger.LastValue;
            r2_input = inputDevice.RightTrigger.IsPressed;

            l1_input = inputDevice.LeftBumper.IsPressed;
            l2_value = inputDevice.LeftTrigger.LastValue;
            l2_input = inputDevice.LeftTrigger.IsPressed;

        }

        void UpdateStates()
        {
            states.horizontal = horizontal;
            states.vertical = vertical;

            Vector3 v = states.vertical * camManager.transform.forward;
            Vector3 h = states.horizontal * camManager.transform.right;

            states.moveDir = (v + h).normalized;
            float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            states.moveAmount = Mathf.Clamp01(m);

            if (e_input)
            {
                states.run = (states.moveAmount > 0);
            }
            else
            {
                states.run = false;
            }

            states.l1 = l1_input;
            states.l2 = l2_input;
            states.r1 = r1_input;
            states.r2 = r2_input;

            if (n_input)
            {
                states.isTwoHanded = !states.isTwoHanded;
                states.HandleTwoHanded();
            }
        }
    }
}
