﻿using UnityEngine;

namespace Duskland.Controllers
{
    public class StateManager : MonoBehaviour
    {
        [Header("Init")]
        public GameObject activeModel;

        [Header("Inputs")]
        public float vertical;
        public float horizontal;
        public float moveAmount;
        public Vector3 moveDir;
        public bool l1, l2, r1, r2;
        public bool twoHanded;

        [Header("Stats")]
        public float moveSpeed = 2f;
        public float runSpeed = 3.5f;
        public float rotateSpeed = 8f;
        public float toGround = 0.5f;

        [Header("States")]
        public bool onGround;
        public bool run;
        public bool lockOn;
        public bool inAction;
        public bool canMove;
        public bool isTwoHanded;

        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public Rigidbody rigid;
        [HideInInspector]
        public AnimatorHook a_hook;
        [HideInInspector]
        public float delta;
        [HideInInspector]
        public LayerMask ignoreLayers;

        private float _actionDelay;

        public void Init()
        {
            SetupAnimator();

            rigid = GetComponent<Rigidbody>();
            rigid.angularDrag = 999;
            rigid.drag = 4;
            rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            a_hook = activeModel.AddComponent<AnimatorHook>();
            a_hook.Init(this);

            gameObject.layer = 8;
            ignoreLayers = ~(1 << 9);

            anim.SetBool("onGround", true);
        }

        private void SetupAnimator()
        {
            if (activeModel == null)
            {
                anim = GetComponentInChildren<Animator>();
                if (anim == null)
                {
                    Debug.Log("You're a dingus, there's no model");
                }
                else
                {
                    activeModel = anim.gameObject;
                }
            }

            if (anim == null)
                anim = activeModel.GetComponent<Animator>();

            anim.applyRootMotion = false;
        }

        public void FixedTick(float d)
        {
            delta = d;

            DetectAction();

            if (inAction)
            {
                anim.applyRootMotion = true;

                _actionDelay += delta;
                if(_actionDelay > 0.2f)
                {
                    inAction = false;
                    _actionDelay = 0;
                }
                else
                {
                    return;
                }
            }

            canMove = anim.GetBool("can_move");

            if (!canMove)
            {
                return;
            }

            //anim.applyRootMotion = false;

            rigid.drag = (moveAmount > 0 || onGround == false) ? 0 : 4;

            float targetSpeed = moveSpeed;
            if (run)
                targetSpeed = runSpeed;

            if(onGround)
            rigid.velocity = moveDir * (targetSpeed * moveAmount);

            if (run)
                lockOn = false;

            if (!lockOn)
            {
                Vector3 targetDir = moveDir;
                targetDir.y = 0;
                if (targetDir == Vector3.zero)
                    targetDir = transform.forward;
                Quaternion tr = Quaternion.LookRotation(targetDir);
                Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, delta * moveAmount * rotateSpeed);
                transform.rotation = targetRotation;
            }

            HandleMovementAnimations();
        }

        public void DetectAction()
        {
            if (!canMove)
                return;

            if (!r1 && !r2 && !l1 && !l2)
                return;

            string targetAnim = null;

            if (r1)
                targetAnim = "oh_attack_1";
            if (r2)
                targetAnim = "oh_attack_3";
            if (l1)
                targetAnim = "oh_attack_1";
            if (l2)
                targetAnim = "oh_attack_2";

            canMove = false;
            inAction = true;
            anim.CrossFade(targetAnim, 0.2f);
            //rigid.velocity = Vector3.zero;
        }

        public void Tick(float d)
        {
            delta = d;
            onGround = OnGround();

            anim.SetBool("onGround", onGround);
        }

        private void HandleMovementAnimations()
        {
            anim.SetBool("run", run);
            anim.SetFloat("vertical", moveAmount, 0.4f, delta); //Only vertical because no lock on mode
        }

        public bool OnGround()
        {
            bool r = false;

            Vector3 origin = transform.position + (Vector3.up * toGround);
            Vector3 dir = -Vector2.up;
            float dis = toGround + 0.3f;

            RaycastHit hit;

            if(Physics.Raycast(origin, dir, out hit, dis, ignoreLayers))
            {
                r = true;
                Vector3 targetPosition = hit.point;
                transform.position = targetPosition;
            }

            Debug.DrawRay(origin, dir, Color.red);

            return r;
        }

        public void HandleTwoHanded()
        {
            anim.SetBool("two_handed", isTwoHanded);
        }
    }
}

