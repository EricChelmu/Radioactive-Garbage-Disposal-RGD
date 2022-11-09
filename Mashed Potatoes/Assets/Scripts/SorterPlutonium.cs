using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterPlutonium : MonoBehaviour
{
    //Check if the sorter is colliding with the correct material
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plutonium"))
        {
            //If the sorter collides with the correct material, the material is set
            //as a child of the sorting manager and obtains the "destroy" tag
            collision.transform.SetParent(SortingManager.Instance.transform);
            collision.gameObject.tag = "Destroy";
            SortingManager.Instance.countPlutonium();
            
        }
    }
}
