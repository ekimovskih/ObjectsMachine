using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_scr : MonoBehaviour
{
    private float throwForce = 500f;
    private Vector3 objectPos;
    private float distance;
    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent = null;

    public bool isHolding = false;
    // Update is called once per frame

    private void Start()
    {
        tempParent = GameObject.Find("Main Camera");
        item = this.gameObject;
    }
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 10000f)
        {
            isHolding = false;
        }
        if (isHolding == true)
        {
            item.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "reach" && Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            item.transform.GetComponent<Rigidbody>().useGravity = false;
            item.transform.GetComponent<Rigidbody>().detectCollisions = true;
            //Debug.Log("sosi");
        }
    }
}
