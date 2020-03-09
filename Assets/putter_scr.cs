using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putter_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion lorry = new Quaternion(0, 180, 0, 180);
    public Quaternion bucket = new Quaternion(180, 180, 180, -180);
    void Start()
    {
        if (this.gameObject.tag == "lorry")
        {
            this.gameObject.transform.rotation = lorry;
        }
        else
        {
            this.gameObject.transform.rotation = bucket;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
