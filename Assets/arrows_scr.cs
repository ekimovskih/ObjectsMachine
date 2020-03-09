using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrows_scr : MonoBehaviour
{
    public GameObject spawner = null;
    public bool which = true;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hey");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && (other.tag=="reach"))
        {
            //Debug.Log("Fuck");
            if (which)
            {
                spawner.transform.GetComponent<spawner_scr>().Increase();

            }
            else
            {
                spawner.transform.GetComponent<spawner_scr>().Decreace();  
            }
        }
    }
}
