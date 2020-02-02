using UnityEngine;
using cakeslice;
using Marsheleene.Events;

public class StartMenuController : MonoBehaviour
{
    public GameEvent m_startGame;
    public LayerMask m_layerMask;

    private Vector3 _mousePosition;

    private Outline _outline;
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(_mousePosition), out hit, float.PositiveInfinity, m_layerMask))
            {
                if (hit.collider.tag == "StartPostIt")
                {
                    m_startGame.Raise();
                }
                else if (hit.collider.tag == "ExitPostIt")
                {
                    Application.Quit();
                }
            }
        }
    }
}
