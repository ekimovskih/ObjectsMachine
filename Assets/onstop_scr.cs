using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onstop_scr : MonoBehaviour
{
    public GameObject button = null;
    public GameObject parrent = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "reach")
        {
            if (other.tag == "Untagged" || other.tag == "lorry" || other.tag == "medival")
            {
                button.transform.GetComponent<button_scr>().access = true;
                parrent.transform.GetComponent<spawner_scr>().created = other.gameObject;
            }
        }
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "reach")
        {
            if (button.transform.GetComponent<button_scr>().access == false)
            {
                other.transform.GetComponent<OnConveir_scr>().stop = false;
            }
        }
    }
}

