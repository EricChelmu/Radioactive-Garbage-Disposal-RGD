using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFillCheck : MonoBehaviour
{
    private MeshRenderer[] activeSlots;

    private void Awake()
    {
        activeSlots = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        int activeCount = 0;
        for (int i = 0; i < activeSlots.Length; i++)
        {
            if (activeSlots[i].enabled == true)
            {
                activeCount++;
            }
        }
        if (activeCount > activeSlots.Length)
        {
            Destroy(gameObject);
        }
        
    }
}
