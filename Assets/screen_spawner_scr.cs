using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_spawner_scr : MonoBehaviour
{
    public int switcher = 0;
    public Material[] mat = new Material[12];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.GetComponent<MeshRenderer>().material = mat[switcher];
    }
}
