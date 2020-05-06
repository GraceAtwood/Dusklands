using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class ChangePose : MonoBehaviour
    {
        private Animator anim;

        public GameObject gm;

        public int buttonPress;

        private int poseValue;

        // Start is called before the first frame update
        private void Start()
        {
            anim = gm.GetComponent<Animator>();
            poseValue = 1;
        }

        private void Update()
        {
            anim.SetInteger("pose", poseValue);
        }

        public void Onclick()
        {
            poseValue += buttonPress;
        }
    }
}
