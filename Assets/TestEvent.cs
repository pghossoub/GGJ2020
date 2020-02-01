using UnityEngine;

using Marsheleene.Events;

public class TestEvent : MonoBehaviour
{
    public GameEvent m_goToLoupe;

    [ContextMenu("GoToLoupe")]
    public void GoToLoupe()
    {
        m_goToLoupe.Raise();
    }
}
