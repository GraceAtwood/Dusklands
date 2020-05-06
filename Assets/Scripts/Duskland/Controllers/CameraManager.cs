using InControl;
using UnityEngine;

namespace Duskland.Controllers
{
    public class CameraManager : MonoBehaviour
    {
        public bool lockon;

        public float followSpeed = 9;

        public float mouseSpeed = 2;
        public float controllerSpeed = 5;

        public Transform target;

        [HideInInspector]
        public Transform pivot;
        [HideInInspector]
        public Transform camTransform;

        private float turnSmoothing = 0f;
        public float minAngle = -25f;
        public float maxAngle = 40f;

        private float smoothX;
        private float smoothY;
        private float smoothXvelocity;
        private float smoothYvelocity;

        private CameraManager camManager;

        public float lookAngle;
        public float tiltAngle;

        public void Init(Transform t)
        {
            target = t;

            camTransform = Camera.main.transform;
            pivot = camTransform.parent;
        }

        public void Tick(float d)
        {
            // Use last device which provided input.
            var inputDevice = InputManager.ActiveDevice;

            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            float c_h = inputDevice.RightStickX;
            float c_v = inputDevice.RightStickY;

            float targetSpeed = mouseSpeed;

            if (c_h != 0 || c_v != 0)
            {
                h = c_h;
                v = c_v;
                targetSpeed = controllerSpeed;
            }

            FollowTarget(d);
            HandleRotations(d, v, h, targetSpeed);
        }

        private void FollowTarget(float d)
        {
            float speed = d * followSpeed;
            Vector3 targetPosition = Vector3.Lerp(transform.position, target.position, speed);
            transform.position = targetPosition;
        }

        private void HandleRotations(float d, float v, float h, float targetSpeed)
        {
            if (turnSmoothing > 0)
            {
                smoothX = Mathf.SmoothDamp(smoothX, h, ref smoothXvelocity, turnSmoothing);
                smoothY = Mathf.SmoothDamp(smoothY, v, ref smoothYvelocity, turnSmoothing);
            }

            else
            {
                smoothX = h;
                smoothY = v;
            }

            if (lockon)
            {

            }

            lookAngle += smoothX * targetSpeed;
            transform.rotation = Quaternion.Euler(0, lookAngle, 0);

            tiltAngle -= smoothY * targetSpeed;
            tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
            pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);
        }

        public static CameraManager singleton;

        private void Awake()
        {
            singleton = this;
        }
    }
}

