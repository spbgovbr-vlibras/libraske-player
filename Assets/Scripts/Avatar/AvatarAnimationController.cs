using Lavid.Libraske.DataStruct;
using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    [SerializeField] protected Wrapper<Animator> _avatarAnimators;

    public void SetInteger(string key, int value)
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
        {
            if (_avatarAnimators[i] != null)
                _avatarAnimators[i].SetInteger(key, value);
        }
    }

    public void EnableAnimations(bool value)
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].enabled = value;
    }

    public void SetController(RuntimeAnimatorController newController)
    {
        if (newController != null)
        {
            for (int i = 0; i < _avatarAnimators.Length; i++)
            {
                if (_avatarAnimators[i] != null)
                    _avatarAnimators[i].runtimeAnimatorController = newController;
            }
        }
        else
        {
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(new InGameError("Houve um erro ao iniciar os avatares"));
        }
    }
}