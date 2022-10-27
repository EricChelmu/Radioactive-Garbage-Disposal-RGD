using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;
using TMPro;

public class Money : MonoBehaviour
{
    public static Money Instance;
    [SerializeField] private TMP_Text moneyCounter;
    public int moneyAmount = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void AddMoney(int value)
    {
        moneyAmount += value;
        moneyCounter.text = "€" + moneyAmount.ToString();
    }
    public void RemoveMoney(int value)
    {
        moneyAmount -= value;
        moneyCounter.text = "€" + moneyAmount.ToString();
    }
}
