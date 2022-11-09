using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFillCheck : MonoBehaviour
{
    private MeshRenderer[] activeSlots;
    private int activeCount;
    private List<GameObject> doorObjects = new List<GameObject>();
    private Animator Door01;
    private Animator Door02;
    float timer = 0;

    private void Awake()
    {
        activeSlots = GetComponentsInChildren<MeshRenderer>();
        doorObjects.Add(GameObject.Find("Door1"));
        doorObjects.Add(GameObject.Find("Door2"));
        Door01 = doorObjects[0].GetComponent<Animator>();
        Door02 = doorObjects[1].GetComponent<Animator>();
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
            DoorClose();            
        }
    }

    private void DoorClose()
    {
        Door01.Play("DoorClose");
        Door02.Play("DoorClose");
        timer = timer + 50 * Time.deltaTime;
        Debug.Log(timer);
        if (timer > 30f)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
