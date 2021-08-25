using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
    [SerializeField] Animator _anim;

    private const string CloseInFront = "closeInFront";
    private const string CloseBySide = "closeBySide";
    private const string CloseInFace = "closeInFace";

    public void SetClose(CameraAnimationCloses close)
    {
        _anim.SetBool(CloseInFront, close == CameraAnimationCloses.CloseInFront);
        _anim.SetBool(CloseBySide, close == CameraAnimationCloses.CloseBySide);
        _anim.SetBool(CloseInFace, close == CameraAnimationCloses.CloseInFace);
    }
}
