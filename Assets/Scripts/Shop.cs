using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    Build build;

    public TurretBlueprint turret;

    void Start()
    {
        build = Build.instance;
    }

    public void ChooseTower()
    {
        build.SetTurretToBuild(turret);
    }
}
