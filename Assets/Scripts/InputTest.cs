using UnityEngine;
using Marsheleene.Events;

public class InputTest : MonoBehaviour
{
    public ScreenStateVariable m_screenState;

    public GameEvent m_goToIntro;
    public GameEvent m_goToNormal;
    public GameEvent m_goToLoupe;
    public GameEvent m_goToMontage;
    public GameEvent m_goToSalle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Loupe
                    m_goToLoupe.Raise();
                    break;
                case ScreenState.MONTAGE:
                    //Go to Normal
                    m_goToNormal.Raise();
                    break;
                case ScreenState.SALLE:
                    //Go to Start
                    m_goToIntro.Raise(); 
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Montage
                    m_goToMontage.Raise(); ;
                    break;
                case ScreenState.LOUPE:
                    //Go to Normal
                    m_goToNormal.Raise();
                    break;
                case ScreenState.INTROLEVEL:
                    //Go to Salle
                    m_goToSalle.Raise();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Start
                    m_goToIntro.Raise();
                    break;
                case ScreenState.MONTAGE:
                    //Go to Salle
                    m_goToSalle.Raise();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.STARTMENU:
                    //Go to Intro
                    m_goToIntro.Raise();
                    break;
                case ScreenState.INTROLEVEL:
                    //Go to Normal
                    m_goToNormal.Raise();
                    break;
                case ScreenState.SALLE:
                    //Go to Montage
                    m_goToMontage.Raise();
                    break;
            }
        }
    }
}
