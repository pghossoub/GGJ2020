using UnityEngine;

public class InputTest : MonoBehaviour
{
    public ScreenStateVariable m_screenState;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Loupe
                    m_screenState.Value = ScreenState.LOUPE;
                    break;
                case ScreenState.MONTAGE:
                    //Go to Normal
                    m_screenState.Value = ScreenState.NORMAL;
                    break;
                case ScreenState.SALLE:
                    //Go to Start
                    m_screenState.Value = ScreenState.START;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Montage
                    m_screenState.Value = ScreenState.MONTAGE;
                    break;
                case ScreenState.LOUPE:
                    //Go to Normal
                    m_screenState.Value = ScreenState.NORMAL;
                    break;
                case ScreenState.START:
                    //Go to Salle
                    m_screenState.Value = ScreenState.SALLE;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.NORMAL:
                    //Go to Start
                    m_screenState.Value = ScreenState.START;
                    break;
                case ScreenState.MONTAGE:
                    //Go to Salle
                    m_screenState.Value = ScreenState.SALLE;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (m_screenState.Value)
            {
                case ScreenState.START:
                    //Go to Normal
                    m_screenState.Value = ScreenState.NORMAL;
                    break;
                case ScreenState.SALLE:
                    //Go to Montage
                    m_screenState.Value = ScreenState.MONTAGE;
                    break;
            }
        }
    }
}
