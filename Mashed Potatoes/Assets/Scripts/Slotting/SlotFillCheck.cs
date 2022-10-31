using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFillCheck : MonoBehaviour
{
    private MeshRenderer[] activeSlots;
    private int activeCount;

    private void Awake()
    {
        activeSlots = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        activeCount = 0;
        for (int i = 0; i < activeSlots.Length; i++)
        {
            if (activeSlots[i].enabled)
            {
                activeCount++;
            }
        }
        if (activeCount == activeSlots.Length)
        {
            Money.Instance.AddMoney(150);
            Destroy(this.gameObject);
        }
    }
}
