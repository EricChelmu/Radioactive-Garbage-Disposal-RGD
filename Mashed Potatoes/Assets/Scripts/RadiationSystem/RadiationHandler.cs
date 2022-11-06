using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiationHandler : MonoBehaviour
{
    //Place this on the Player Character

    public RadiationSystem radiationSystem = new RadiationSystem(100f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        radiationSystem.RadiationReduction(0.1f);
        Debug.Log("Radiation is " + radiationSystem.radiation);
    }
}
