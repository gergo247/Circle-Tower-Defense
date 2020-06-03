using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color  hoverColor;
    private Color startColor;
    private Renderer rend;
    public Vector3 positionOffset;

    private GameObject turret;
    BuildManager buildmanager;
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    //click
    void OnMouseDown()
    {
        //if turret is not selected return
        if (buildmanager.GetTurretToBuild() == null)
            return;
        
        if (turret != null)
        {
            Debug.Log("Already tower here");
            return;
        }
        GameObject turretToBuild = buildmanager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    //called when mouse enters
    void OnMouseEnter()
    {
        //if ()
        {

        }

        if (buildmanager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
