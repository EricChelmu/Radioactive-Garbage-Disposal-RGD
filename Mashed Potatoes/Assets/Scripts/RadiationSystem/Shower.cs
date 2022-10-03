using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : RadiationNull
{
    //Place this on the Shower

    private SphereCollider spCollider;


    // Start is called before the first frame update
    void Start()
    {
        RadioPower = 1f;
        RadioRadius = 2f;

        spCollider = GetComponent<SphereCollider>();
        spCollider.radius = this.RadioRadius;

        radiationHandler = Player.GetComponent<RadiationHandler>();

    }
}
