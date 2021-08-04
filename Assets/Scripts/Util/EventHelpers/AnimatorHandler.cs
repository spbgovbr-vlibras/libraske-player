using UnityEngine;

namespace Lavid.Libraske.Util 
{
    public class AnimatorHandler : MonoBehaviour
    {
        [SerializeField] Animator _anim;

        public void SetAsFalse(string param) => _anim.SetBool(param, false);
        public void SetAsTrue(string param) => _anim.SetBool(param, true);
    }
}