using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public bool access = false;
    public GameObject nextbutt = null;
    public GameObject parent = null;
    public Material yes = null;
    public Material no = null;
    public GameObject stopper = null;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (access)
        {
            this.gameObject.transform.GetComponent<MeshRenderer>().material = yes;
        }
        else
        {
            this.gameObject.transform.GetComponent<MeshRenderer>().material = no;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && (other.tag == "reach") && access)
        {
            //nextbutt.transform.GetComponent<button_scr>().access = true;
            parent.transform.GetComponent<spawner_scr>().Do();
            access = false;
            nextbutt.transform.GetComponent<button_scr>().access = true;

        }
    }
}
