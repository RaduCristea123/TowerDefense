using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer r;
    private Color startColor;
    public GameObject turret;
    public Vector3 turretPos;
    public Color hoverColor;

    Build build;

    void Start()
    {
        r = GetComponent<Renderer>();
        startColor = r.material.color;

        build = Build.instance;
    }

    void OnMouseEnter()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }
        if (!build.CanBuild)
        {
            return;
        }
        r.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }
        if (turret != null)
        {
            return;
        }
        if (!build.CanBuild)
        {
            return;
        } 
        
        build.BuildTurretOn(this);
    }

    void OnMouseExit()
    {
        r.material.color = startColor;
    }
    
}
