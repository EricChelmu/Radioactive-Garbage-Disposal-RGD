using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterPlutonium : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plutonium"))
        {
            collision.transform.SetParent(SortingManager.Instance.transform);
            collision.gameObject.tag = "Destroy";
            SortingManager.Instance.countPlutonium();
            
        }
    }
}
