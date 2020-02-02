using System.Collections;
using UnityEngine;

using DG.Tweening;

using Marsheleene.Variables;

public class WorkbenchController : MonoBehaviour
{
    public VideoFragmentVariable m_activeFragment;
    public VideoFragmentList m_workbenchFragments;
    public BoolVariable m_isDragging;

    public Transform m_activeFragmentPosition;
    public Transform m_slot1Position;
    public Transform m_slot2Position;
    public Transform m_slot3Position;
    public Transform m_slot4Position;
    public Transform m_slot5Position;

    public FloatReference m_changePositionDelay;

    private Vector3 _originalPosition;

    private void OnWorkbenchClicked()
    {
        if (m_isDragging.Value)
        {
            _originalPosition = m_activeFragment.Value.transform.position;

            m_activeFragment.Value.transform.DOMove(m_activeFragmentPosition.position, m_changePositionDelay.Value).SetEase(Ease.InOutSine);
        }
    }

    private void OnBackPostItClicked()
    {
        StartCoroutine(_ChangePositionDelayed());
    }

    private IEnumerator _ChangePositionDelayed()
    {
        yield return new WaitForSeconds(m_changePositionDelay.Value);
        m_activeFragment.Value.transform.DOMove(_originalPosition, m_changePositionDelay.Value).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            m_activeFragment.Value.GetComponentInParent<Animator>().enabled = true;
        });
    }


    private void OnSlot1Clicked()
    {
        if (m_isDragging.Value)
        {
            m_workbenchFragments.m_list[0] = m_activeFragment.Value;
            m_activeFragment.Value = null;
            m_isDragging.Value = false;
            // Faire apparaître le fragment sur le slot 1
            m_activeFragment.Value.transform.position = m_slot1Position.position;
        }
    }
    private void OnSlot2Clicked()
    {
        if (m_isDragging.Value)
        {
            m_workbenchFragments.m_list[1] = m_activeFragment.Value;
            m_activeFragment.Value = null;
            m_isDragging.Value = false;
            // Faire apparaître le fragment sur le slot 2
            m_activeFragment.Value.transform.position = m_slot2Position.position;
        }
    }
    private void OnSlot3Clicked()
    {
        if (m_isDragging.Value)
        {
            m_workbenchFragments.m_list[2] = m_activeFragment.Value;
            m_activeFragment.Value = null;
            m_isDragging.Value = false;
            // Faire apparaître le fragment sur le slot 3
            m_activeFragment.Value.transform.position = m_slot3Position.position;
        }
    }
    private void OnSlot4Clicked()
    {
        if (m_isDragging.Value)
        {
            m_workbenchFragments.m_list[3] = m_activeFragment.Value;
            m_activeFragment.Value = null;
            m_isDragging.Value = false;
            // Faire apparaître le fragment sur le slot 4
            m_activeFragment.Value.transform.position = m_slot4Position.position;
        }
    }
    private void OnSlot5Clicked()
    {
        if (m_isDragging.Value)
        {
            m_workbenchFragments.m_list[4] = m_activeFragment.Value;
            m_activeFragment.Value = null;
            m_isDragging.Value = false;
            // Faire apparaître le fragment sur le slot 5
            m_activeFragment.Value.transform.position = m_slot5Position.position;
        }
    }
}
