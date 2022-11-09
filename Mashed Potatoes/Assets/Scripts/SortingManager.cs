using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;

public class SortingManager : MonoBehaviour
{
    //Reference for the singleton manager
    public static SortingManager Instance;

    //Referencing the outputs of the sorting machine
    public GameObject uraniumOutput;
    public GameObject radiumOutput;
    public GameObject plutoniumOutput;
    public GameObject thisObject;

    //Referencing the UI text
    public GameObject startingText;
    public GameObject upgrade2Text;
    public GameObject upgrade3Text;

    //Referencing the sorting machines
    public GameObject sortingMachine1;
    public GameObject sortingMachine2;
    public GameObject sortingMachine3;

    //Variables needed for sorting and crafting recipes
    private int uraniumCount = 0;
    private int radiumCount = 0;
    private int plutoniumCount = 0;
    private int randomOutput = 0;

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

    // Update is called once per frame
    void Update()
    {
        //Activating the first sorter, and displaying it's text
        if (sorter1 == false)
        {
            sorter1 = true;
            GameObject textClone = Instantiate(startingText, transform.position, transform.rotation);
            textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
            Destroy(textClone, 20);
        }
        //Activating the second sorter, and displaying it's text, based on the amount of money the player has earned
        else if (sorter2 == false)
        {
            if (Money.Instance.moneyAmount >= 750)
            {
                sorter2 = true;
                Money.Instance.RemoveMoney(750);
                //Destroying first sorting machine
                Destroy(sortingMachine1);
                //Activating second sorting machine
                sortingMachine2.gameObject.SetActive(true);
                //Displaying text
                GameObject textClone = Instantiate(upgrade2Text, transform.position, transform.rotation);
                textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
                Destroy(textClone, 20);
            }
        }
        else if (sorter3 == false)
        {
            if (Money.Instance.moneyAmount >= 1500)
            {
                sorter3 = true;
                Money.Instance.RemoveMoney(1500);
                //Destroying second sorting machine
                Destroy(sortingMachine2.gameObject);
                //Activating third sorting machine
                Instantiate(sortingMachine3, new Vector3(-0.23f, -0.0028512f, 4.45f), transform.rotation);
                //Displaying text
                GameObject textClone = Instantiate(upgrade3Text, transform.position, transform.rotation);
                textClone.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
                Destroy(textClone, 20);
            }
        }
        //Running the sorting script based on which upgrade the player has
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
        //Randomizing the outputs of the first sorting machine
        randomOutput = Random.Range(1, 4);

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
            //If one of each material is put into the sorting baskets, the children(materials) of the sorting manager get destroyed
            for (var i = thisObject.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(thisObject.transform.GetChild(i).gameObject);
            }
            GameObject[] toDestroy;
            toDestroy = GameObject.FindGameObjectsWithTag("Destroy");
            for (var i = 0; i < toDestroy.Length; i++)
            {
                Destroy(toDestroy[i].gameObject);
            }
            //After the children get deleted, an output is randomly spawned
            if (randomOutput == 1)
            {
                Instantiate(uraniumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }
            else if (randomOutput == 2)
            {
                Instantiate(radiumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }
            else if (randomOutput == 3)
            {
                Instantiate(plutoniumOutput, new Vector3(-0.249f, 0.512f, 8.56f), transform.rotation);
            }
            //The player earns money for the succesful sorting
            Money.Instance.AddMoney(50);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
        }
    }
    public void sortingUpgrade2()
    {
        //Upgrade 2 (1 Input - 1 Output)
        //Same as with the first sorting machine, except here after just one material is set, it gets destroyed and an output
        //of the same type as the material is spawned
        if (uraniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            GameObject[] toDestroy;
            toDestroy = GameObject.FindGameObjectsWithTag("Destroy");
            for (var i = 0; i < toDestroy.Length; i++)
            {
                Destroy(toDestroy[i].gameObject);
            }
            Instantiate(uraniumOutput, new Vector3(1.422f, 0.562f, 7.873f), transform.rotation);
            uraniumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (radiumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(radiumOutput, new Vector3(-0.274f, 0.562f, 7.873f), transform.rotation);
            radiumSet = false;
            Money.Instance.AddMoney(50);
        }
        else if (plutoniumSet == true)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(plutoniumOutput, new Vector3(-1.994f, 0.562f, 7.873f), transform.rotation);
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }

    public void sortingUpgrade3()
    {
        //Upgrade 3 (1 Input - 3 Outputs)
        //This upgrade allows the player to place any raw material into the sorter, and the sorter will always give 3 outputs
        if (uraniumSet == true || radiumSet == true || plutoniumSet)
        {
            Destroy(thisObject.transform.GetChild(0).gameObject);
            Instantiate(uraniumOutput, new Vector3(1.422f, 0.562f, 7.873f), transform.rotation);
            Instantiate(radiumOutput, new Vector3(-0.217f, 0.562f, 7.873f), transform.rotation);
            Instantiate(plutoniumOutput, new Vector3(-1.841f, 0.562f, 7.873f), transform.rotation);
            uraniumSet = false;
            radiumSet = false;
            plutoniumSet = false;
            Money.Instance.AddMoney(50);
        }
    }
}
