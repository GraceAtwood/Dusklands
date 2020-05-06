using UnityEngine;

namespace Duskland.Controllers
{
    public class AnimatorHook : MonoBehaviour
    {
        private Animator anim;
        private StateManager states;

        public void Init(StateManager st)
        {
            states = st;
            anim = st.anim;
        }

        private void OnAnimatorMove()
        {
            if (states.canMove)
                return;

            states.rigid.drag = 0;
            float multiplier = 1;

            Vector3 delta = anim.deltaPosition;
            delta.y = 0;
            Vector3 v = (delta * multiplier) / states.delta;

            states.rigid.velocity = v;

        }

        public void OpenDamageColliders()
        {

        }

        public void CloseDamageColliders()
        {

        }
    }
}

