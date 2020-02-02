﻿using UnityEngine;
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

    [Header("Variables")]
    //public FragmentDrag fragmentDrag;
    public BoolVariable isDragging;
    public VideoFragmentVariable m_activeFragment;

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
                            switch(hit.collider.name)
                            {
                                case "Fragment_1_1_A":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect1", true);
                                    break;
                                case "Fragment_1_1_B":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect2", true);
                                    break;
                                case "Fragment_1_1_C":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect3", true);
                                    break;
                                case "Fragment_1_1_D":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect4", true);
                                    break;
                                case "Fragment_1_1_E":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect5", true);
                                    break;
                            }

                            m_activeFragment.Value = hit.collider.GetComponent<VideoFragment>();
                        }
                        else if (hit.collider.GetComponent<VideoFragment>() == m_activeFragment.Value)
                        {
                            m_activeFragment.Value = null;
                            isDragging.Value = false;
                            switch (hit.collider.name)
                            {
                                case "Fragment_1_1_A":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect1", false);
                                    break;
                                case "Fragment_1_1_B":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect2", false);
                                    break;
                                case "Fragment_1_1_C":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect3", false);
                                    break;
                                case "Fragment_1_1_D":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect4", false);
                                    break;
                                case "Fragment_1_1_E":
                                    hit.collider.GetComponentInParent<Animator>().SetBool("FragSelect5", false);
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
