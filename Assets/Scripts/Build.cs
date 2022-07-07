using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject turret;
    private TurretBlueprint turretToBuild;


    public static Build instance;
    public bool CanBuild { get {  return turretToBuild != null; } }

    void Awake()
    {
        instance = this;
    }

    public void BuildTurretOn(Node node)
    {
        if (Stats.Money < turretToBuild.cost)
        {
            return;
        }

        Stats.Money -= turretToBuild.cost;
        GameObject tower = (GameObject)Instantiate(turretToBuild.obj, node.transform.position + node.turretPos, Quaternion.identity);
        node.turret = tower;
        SetTurretToBuild(null);
        Debug.Log("Money: " + Stats.Money);
    }

 

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
