using UnityEngine;

using Marsheleene.Variables;

public class Timer : MonoBehaviour
{
    public FloatReference m_startingTime;
    public FloatReference m_currentTime;

    private void Start()
    {
        m_currentTime.Value = m_startingTime.Value;
    }

    private void Update()
    {
        m_currentTime.Value -= Time.deltaTime;
    }
}
