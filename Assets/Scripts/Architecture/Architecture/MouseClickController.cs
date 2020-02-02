using UnityEngine;
using cakeslice;
using Marsheleene.Events;
using Marsheleene.Variables;

public class MouseClickController : MonoBehaviour
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
    public BoolVariable isDragging;
    public FragmentDrag fragmentDrag;

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
                    case "Loupe":
                        m_goToLoupe.Raise();
                        break;
                    case "Banc":
                        m_goToMontage.Raise();
                        break;
                    case "Fragment":
                        if (!isDragging.Value)
                        {
                            isDragging.Value = true;
                            hit.collider.GetComponent<Animator>().SetBool("isDragging", true);
                            fragmentDrag.order = hit.collider.GetComponent<VideoFragment>().m_order;
                            fragmentDrag.meshFilter = hit.collider.GetComponent<MeshFilter>();
                            fragmentDrag.fragmentName = hit.collider.name;
                            fragmentDrag.video = hit.collider.GetComponent<VideoFragment>();
                        } else if (hit.collider.name == fragmentDrag.fragmentName)
                        {
                            isDragging.Value = false;
                            hit.collider.GetComponent<Animator>().SetBool("isDragging", false);
                        }
                        break;
                }
            }
        }
    }
}
