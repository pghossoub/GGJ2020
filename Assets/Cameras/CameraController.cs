using UnityEngine;
using UnityEngine.Video;

using Marsheleene.Variables;

public class CameraController : MonoBehaviour
{
    public Animator m_animator;
    public BoolVariable isDragging;
    public StringVariable gameView;
    public FragmentDrag fragmentDrag;
    public GameObject fragmentLoupe;

    private VideoFragment videoFragment;
    private MeshFilter meshFragment;

    private void Start()
    {
        gameView.Value = "intro";
        fragmentLoupe = GameObject.FindGameObjectWithTag("posLoupe");
        videoFragment = fragmentLoupe.GetComponent<VideoFragment>();
        meshFragment = fragmentLoupe.GetComponent<MeshFilter>();
    }

    [ContextMenu("State > Intro")]
    public void SwitchToIntro()
    {
        gameView.Value = "intro";
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsTable"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Loupe")]
    public void SwitchToLoupe()
    {
        gameView.Value = "loupe";
        ActiveFragmentLoupe();
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), true);
        m_animator.SetBool(Animator.StringToHash("IsTable"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Table")]
    public void SwitchToTable()
    {
        gameView.Value = "table";
        isDragging.Value = false;
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsTable"), true);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Start")]
    public void SwitchToStart()
    {
        gameView.Value = "start";
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsTable"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    [ContextMenu("State > Montage")]
    public void SwitchToMontage()
    {
        gameView.Value = "montage";
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsTable"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), true);
    }

    [ContextMenu("State > Salle")]
    public void SwitchToSalle()
    {
        gameView.Value = "salle";
        m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
        m_animator.SetBool(Animator.StringToHash("IsTable"), false);
        m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
        m_animator.SetBool(Animator.StringToHash("IsSalle"), true);
        m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    }

    //public void youWin()
    //{
    //    m_animator.SetBool(Animator.StringToHash("ItsAWin"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsTable"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsIntro"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    //}
    //public void youLose()
    //{
    //    m_animator.SetBool(Animator.StringToHash("ItsAWin"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsLoupe"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsTable"), true);
    //    m_animator.SetBool(Animator.StringToHash("IsIntro"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsSalle"), false);
    //    m_animator.SetBool(Animator.StringToHash("IsMontage"), false);
    //}
    private void ActiveFragmentLoupe()
    {
        videoFragment = fragmentDrag.video;
        fragmentLoupe.SetActive(true);
        meshFragment.mesh = fragmentDrag.meshFilter.mesh;
    }
}