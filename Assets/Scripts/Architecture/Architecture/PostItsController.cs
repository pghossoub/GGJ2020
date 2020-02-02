using UnityEngine;
using cakeslice;
using Marsheleene.Events;

public class PostItsController : MonoBehaviour
{
    public GameEvent m_startGame;
    public GameEvent m_goToTable;
    public GameEvent m_goToLoupe;
    public GameEvent m_goToMontage;
    public GameEvent m_goToSalle;
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
                //If the click was on Start
                switch (hit.collider.tag)
                {
                    case "StartPostIt":
                        Destroy(hit.collider.gameObject.GetComponent<MeshCollider>());
                        foreach (GameObject myObject in GameObject.FindGameObjectsWithTag("ExitPostIt"))
                        {
                            Destroy(myObject.GetComponent<MeshCollider>());
                        }
                        m_startGame.Raise();
                        break;
                    case "ExitPostIt":
                        Application.Quit();
                        break;
                    case "BackPostIt":
                        m_goToTable.Raise();
                        break;
                }
            }
        }
    }
}
