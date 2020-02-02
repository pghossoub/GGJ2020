using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marsheleene.Events;

public class PlaySound : MonoBehaviour
{
    public GameEvent m_playRepairSound;
    public GameEvent m_playEraseSound;

    public void PlaySoundRepair()
    {
        m_playRepairSound.Raise();
    }

    public void PlaySoundErase()
    {
        m_playEraseSound.Raise();
    }
}
