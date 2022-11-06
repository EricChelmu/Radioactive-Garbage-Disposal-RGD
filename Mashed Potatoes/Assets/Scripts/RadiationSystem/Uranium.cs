using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uranium : RadioactiveMaterial
{
    //Place this on the Uranium

    private SphereCollider spCollider;    

    // Start is called before the first frame update
    void Start()
    {
        spCollider = GetComponent<SphereCollider>();
        spCollider.radius = this.RadioRadius;        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            radiationHandler = other.GetComponent<RadiationHandler>();
            radiationHandler.radiationSystem.RadiationDamage(this.RadioPower);
        }
    }
}
