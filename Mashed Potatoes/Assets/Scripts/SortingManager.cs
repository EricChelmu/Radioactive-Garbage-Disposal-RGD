using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;

public class SortingManager : MonoBehaviour
{
    public static SortingManager Instance;
    public GameObject output;
    public GameObject thisObject;

    private int uraniumCount = 0;
    private int radiumCount = 0;
    private int plutoniumCount = 0;

    private bool uraniumSet = false;
    private bool radiumSet = false;
    private bool plutoniumSet = false;

    private bool sorter1 = false;
    private bool sorter2 = false;
    private bool sorter3 = false;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sorter1 == false)
        {
            sorter1 = true;
        }
        else if (sorter2 == false)
        {
            if (Money.Instance.moneyAmount >= 1000)
            {
                sorter2 = true;
                Money.Instance.RemoveMoney(1000);
            }
        }
        else if (sorter3 == false)
        {
            if (Money.Instance.moneyAmount >= 3000)
            {
                sorter3 = true;
                Money.Instance.RemoveMoney(3000);
            }
        }
        if (sorter1 == true && sorter2 == false)
        {
            sortingUpgrade1();
        }
        else if (sorter2 == true && sorter3 == false)
        {
            sortingUpgrade2();
        }    
        else if (sorter3 == true)
        {
            sortingUpgrade3();
        }
    }

    public void countUranium()
    {
        uraniumCount += 1;
        uraniumSet = true;
    }
    public void countRadium()
    {
        radiumCount += 1;
        radiumSet = true;
    }
    public void countPlutonium()
    {
        plutoniumCount += 1;
        plutoniumSet = true;
    }
    public void sortingUpgrade1()
    {
        //Upgrade 1 (3 Input - 1 Output)
        if (uraniumSet == true && radiumSet == true && plutoniumSet == true)
        {
            for (var i = thisObject.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(thisObject.transform.GetChild(i).gameObject);
            }
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            Money.Instance.AddMoney(50);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
        }
    }
    public void sortingUpgrade2()
    {
        //Upgrade 2 (1 Input - 1 Output)
        if (uraniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            uraniumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (radiumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            radiumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (plutoniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }

    public void sortingUpgrade3()
    {
        //Upgrade 3 (1 Input - 3 Outputs)
        if (uraniumSet == true || radiumSet == true || plutoniumSet)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }
}
