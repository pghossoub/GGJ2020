using UnityEngine;

using Marsheleene.Variables;
using Marsheleene.Events;

public class Timer : MonoBehaviour
{
    public FloatReference m_startingTime;
    public FloatReference m_currentTime;

    public GameEvent m_clockTickEvent;

    private float _secondCounter;


    private void Start()
    {
        m_currentTime.Value = m_startingTime.Value;
    }

    private void Update()
    {
        _secondCounter += Time.deltaTime;

        if (_secondCounter >= 1)
        {
            m_clockTickEvent.Raise();
            _secondCounter = 0;
        }

        m_currentTime.Value -= Time.deltaTime;
    }
}
