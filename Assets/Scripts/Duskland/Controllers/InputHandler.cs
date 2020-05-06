using InControl;
using UnityEngine;

namespace Duskland.Controllers
{
    public class InputHandler : MonoBehaviour
    {
        //Left stick
        private float vertical;
        private float horizontal;

        //Gamepad face buttons
        private bool n_input;
        private bool e_input;
        private bool s_input;
        private bool w_input;

        //Triggers
        private bool r1_input;
        private float r2_value;
        private bool r2_input;
        private bool l1_input;
        private float l2_value;
        private bool l2_input;

        private StateManager states;
        private CameraManager camManager;

        private float delta;

        // Start is called before the first frame update
        private void Start()
        {
            states = GetComponent<StateManager>();
            states.Init();

            camManager = CameraManager.singleton;
            camManager.Init(this.transform);
        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            GetInput();
            UpdateStates();

            states.FixedTick(delta);
            camManager.Tick(delta);
        }

        private void Update()
        {
            delta = Time.deltaTime;
            states.Tick(delta);
        }

        private void GetInput()
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

        private void UpdateStates()
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
