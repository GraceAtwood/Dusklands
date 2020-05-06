using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class CreationAnims : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void OnClick()
        {
            anim.SetTrigger("trigger");
        }
    }
}
