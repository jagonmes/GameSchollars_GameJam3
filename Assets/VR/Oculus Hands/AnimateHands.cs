using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    [SerializeField] private InputActionReference _grip;
    [SerializeField] private InputActionReference _trigger;

    [SerializeField]private Animator _handAnimator;
    private float _gripValue;
    private float _triggerValue;

    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = _grip.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }

    private void AnimateTrigger()
    {
        _triggerValue = _trigger.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }

}
