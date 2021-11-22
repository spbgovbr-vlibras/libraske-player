using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    private const string CloseInFront = "closeInFront";
    private const string CloseInBottom = "closeInBottom";
    private const string CloseInFace = "closeInFace";

    public void SetClose(CameraAnimationCloses close)
    {
        _anim.SetBool(CloseInFront, close == CameraAnimationCloses.CloseInFront);
        _anim.SetBool(CloseInBottom, close == CameraAnimationCloses.CloseInBottom);
        _anim.SetBool(CloseInFace, close == CameraAnimationCloses.CloseInFace);
    }
}
