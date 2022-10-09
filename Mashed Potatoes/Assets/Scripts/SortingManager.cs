using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public static SortingManager Instance;
    public GameObject output;
    public GameObject g;

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
        if (uraniumSet == true && radiumSet == true && plutoniumSet == true)
        {
            //Destroy(GameObject.FindGameObjectWithTag("Destroy"));
            //Destroy(GameObject.FindGameObjectWithTag("Destroy"));
            for (var i = g.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(g.transform.GetChild(i).gameObject);
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
        Debug.Log(uraniumCount);
        Debug.Log(uraniumSet);
    }
    public void countRadium()
    {
        radiumCount += 1;
        radiumSet = true;
        Debug.Log(radiumCount);
        Debug.Log(radiumSet);
    }
    public void countPlutonium()
    {
        plutoniumCount += 1;
        plutoniumSet = true;
        Debug.Log(plutoniumCount);
        Debug.Log(plutoniumSet);
    }
}
