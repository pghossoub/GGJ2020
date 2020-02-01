using UnityEngine;

using Marsheleene.Variables;

public class TestStateMachine : MonoBehaviour
{
    public Animator m_animator;

    public ScreenStateVariable m_screenState;

    [ContextMenu("State > Loupe")]
    public void SwitchToLoupe()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), true);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
    }

    [ContextMenu("State > Normal")]
    public void SwitchToNormal()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), true);
    }
}
