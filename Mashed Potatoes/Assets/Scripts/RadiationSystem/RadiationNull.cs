
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationNull : MonoBehaviour
{
    [System.NonSerialized] public float RadioPower;
    [System.NonSerialized] public float RadioRadius;
    [System.NonSerialized] public RadiationHandler radiationHandler;

    public Transform Player;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            radiationHandler.radiationSystem.RadiationReduction(this.RadioPower);
        }
    }
}
