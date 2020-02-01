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
        m_animator.SetBool(Animator.StringToHash("IsStart"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Normal")]
    public void SwitchToNormal()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), true);
        m_animator.SetBool(Animator.StringToHash("IsStart"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Start")]
    public void SwitchToStart()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsStart"), true);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Montage")]
    public void SwitchToMontage()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsStart"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), true);
    }

    [ContextMenu("State > Salle")]
    public void SwitchToSalle()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsStart"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), true);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    private void Update()
    {
        switch (m_screenState.Value)
        {
            case ScreenState.LOUPE:
                {
                    SwitchToLoupe();
                    break;
                }
            case ScreenState.NORMAL:
                {
                    SwitchToNormal();
                    break;
                }
            case ScreenState.START:
                {
                    SwitchToStart();
                    break;
                }
            case ScreenState.MONTAGE:
                {
                    SwitchToMontage();
                    break;
                }
            case ScreenState.SALLE:
                {
                    SwitchToSalle();
                    break;
                }
        }
    }
}
