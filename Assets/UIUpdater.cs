using UnityEngine;

using TMPro;

using Marsheleene.Variables;

public class UIUpdater : MonoBehaviour
{
    public FloatReference m_timer;

    public TextMeshProUGUI m_timerUI;

    private void Update()
    {
        m_timerUI.text = m_timer.Value.ToString();
    }
}
