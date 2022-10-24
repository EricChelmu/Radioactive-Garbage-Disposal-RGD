using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Upgrade 2 (1 Input - 1 Output)
        if (uraniumSet == true)
        {
            Destroy(thisObject.transform.Find("Uranium").gameObject);
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            uraniumSet = false;
        }

        //Upgrade 1 (3 Input - 1 Output)
        if (uraniumSet == true && radiumSet == true && plutoniumSet == true)
        {
            for (var i = thisObject.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(thisObject.transform.GetChild(i).gameObject);
            }
            Instantiate(output, new Vector3(5.075f, 0.66f, 9.942f), transform.rotation);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
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
}
