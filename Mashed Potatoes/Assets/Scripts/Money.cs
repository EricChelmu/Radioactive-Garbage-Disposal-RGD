using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;
using TMPro;

public class Money : MonoBehaviour
{
    //Making the money script a singleton, so that it can be accessed by any script
    public static Money Instance;
    //Referencing the ui element
    [SerializeField] private TMP_Text moneyCounter;
    public int moneyAmount = 0;
    private void Awake()
    {
        //singleton creation
        Instance = this;
    }
    public void AddMoney(int value)
    {
        //Displaying the amount of money the player has on the screen
        moneyAmount += value;
        moneyCounter.text = "€" + moneyAmount.ToString();
    }
    public void RemoveMoney(int value)
    {
        //Displaying the amount of money the player has on the screen
        moneyAmount -= value;
        moneyCounter.text = "€" + moneyAmount.ToString();
    }
}
