using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics;

public class SlotFill : MonoBehaviour
{
    private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rend.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(this.gameObject.tag) && rend.enabled == false)
        {
            rend.enabled = true;
            Money.Instance.AddMoney(50);
            Destroy(other.gameObject);
        }
    }
}
