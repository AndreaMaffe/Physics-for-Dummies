using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucaManager : InteractiveObject
{



    public SphereManager sphereManager;
    public HouseManager houseManager;
    public PhysicMaterial elasticSphere;
    public PhysicMaterial elasticWall;
    public PhysicMaterial anelasticSphere;
    public PhysicMaterial anelasticWall;
    public GameObject impactHouse;
    private bool elastic = true;
    void Start()
    {
        SetData();
    }

    public override void OnArrowDown() {}
    public override void OnArrowUp() {}

    public override void OnClick()
    {
        SetData();

    }

    void SetData()
    {
        if (!elastic)
        {   
            sphereManager.SetMaterial(elasticSphere);
            houseManager.SetMaterial(elasticWall);
        }
        else
        {
            sphereManager.SetMaterial(anelasticSphere);
            houseManager.SetMaterial(anelasticWall);
        }
        elastic = !elastic;
    }


}
