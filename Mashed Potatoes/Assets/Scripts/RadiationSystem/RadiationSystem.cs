using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationSystem
{
    public float radiation;
    public float radiationMax;

    public RadiationSystem(float radiationMax)
    {
        this.radiationMax = radiationMax;
        radiation = 0f;
    }


    public void RadiationDamage(float radiationAmount)
    {
        radiation += radiationAmount * Time.deltaTime;
        if (radiation > radiationMax)
        {
            radiation = radiationMax;
        }
    }

    public void RadiationReduction(float reductionAmount)
    {
        radiation -= reductionAmount * Time.deltaTime;
        if(radiation < 0f)
        {
            radiation = 0f;
        }
    }
}
