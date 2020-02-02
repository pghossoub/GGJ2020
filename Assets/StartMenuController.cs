using UnityEngine;
using Marsheleene.Events;
using Marsheleene.Variables;

public class StartMenuController : MonoBehaviour
{
    public GameEvent m_startGame;
    public LayerMask m_layerMask;

    private Vector3 _mousePosition;
    private Outline.Outline _monOutline;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        if (Physics.Raycast(
                            Camera.main.ScreenPointToRay(_mousePosition),
                            out hit,
                            float.PositiveInfinity,
                            m_layerMask
                            ))
        {
            _monOutline = hit.collider.gameObject.GetComponent<Outline.Outline>();

            if (hit.collider.gameObject.CompareTag("StartPostIt"))
            {
                _monOutline.OutlineWidth = 10f;
                if (Input.GetButtonDown("Fire1"))
                {
                    m_startGame.Raise();
                }
            }
            else if (hit.collider.gameObject.CompareTag("ExitPostIt"))
            {
                _monOutline.OutlineWidth = 10f;
                if (Input.GetButtonDown("Fire1"))
                {
                    Application.Quit();
                }
            }
        }
        else if(_monOutline!=null)
        {
            _monOutline.OutlineWidth = 0f;
        }
    }
}
