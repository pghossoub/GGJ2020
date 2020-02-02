using UnityEngine;

using Marsheleene.Variables;

public class CameraController : MonoBehaviour
{
    public Animator m_animator;

    [ContextMenu("State > Intro")]
    public void SwitchToIntro()
    {
        //m_animator.SetBool(Animator.StringToHash("GameStarted"), true);
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Loupe")]
    public void SwitchToLoupe()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), true);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Normal")]
    public void SwitchToNormal()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), true);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Start")]
    public void SwitchToStart()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Montage")]
    public void SwitchToMontage()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), true);
    }

    [ContextMenu("State > Salle")]
    public void SwitchToSalle()
    {
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), true);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    //public void youWin()
    //{
    //    m_animator.SetBool(Animator.StringToHash("ItsAWin"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsNormal"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    //}
    //public void youLose()
    //{
    //    m_animator.SetBool(Animator.StringToHash("ItsAWin"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsNormal"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    //}

}