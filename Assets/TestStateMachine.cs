using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateMachine : MonoBehaviour
{
    public Animator m_animator;

    [ContextMenu("State > Loupe")]
    public void TestStateLoupe()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), true);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
    }

    [ContextMenu("State > Normal")]
    public void TestStateNormal()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), true);
    }
}
