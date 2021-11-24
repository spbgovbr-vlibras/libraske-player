using System.Collections;
using UnityEngine;

public class TrainingAnimationRepeater : MonoBehaviour
{
    [SerializeField] TrainingController _trainingController;
    [SerializeField] AvatarAnimationController _animationController;

    [SerializeField, Min(0)] float _repeatDelay = 1.5f;
    private bool _routineHasStarted;

    private void LateUpdate()
    {
        bool isPlaying = _animationController.IsPlaying();

        if (!isPlaying && !_routineHasStarted)
            StartCoroutine(RepeatAnimationCoroutine());
    }

    private IEnumerator RepeatAnimationCoroutine()
    {
        _routineHasStarted = true;

        yield return new WaitForSeconds(_repeatDelay);
        RepeatAnimation();

        _routineHasStarted = false;
    }

    private void RepeatAnimation()
    {
        if (_trainingController != null)
            _trainingController.RepeatLastAnimation();
    }
}