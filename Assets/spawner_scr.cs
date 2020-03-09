using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obj = new GameObject[12];
    public GameObject screen = null;
    public int switcher = 0;
    public Material[] letscolor = new Material[5];
    public GameObject created = null;
    public int a = 12;
    public Vector3 scale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Do()
    {
        if (this.gameObject.tag == "creator")
        {
            Instantiate(obj[switcher], transform.position, Quaternion.identity);
        }
        if (this.gameObject.tag == "colorer")
        {
            if ((created.tag == "lorry"))
            {
                created.transform.GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(screen.transform.GetComponent<MeshRenderer>().material);
            }
            else
            {
                
                created.transform.GetComponent<MeshRenderer>().material = screen.transform.GetComponent<MeshRenderer>().material;
            }
            scale = created.transform.localScale;
        }
        if (this.gameObject.tag == "sizer")
        {
            for (int i = 4; i>switcher; i--)
            {
                created.transform.localScale = Vector3.Scale(created.transform.localScale, new Vector3(0.85f, 0.85f, 0.85f));
                
            }
            created.transform.position = new Vector3(created.transform.position.x + 1.9f, created.transform.position.y, created.transform.position.z);
            created.transform.GetComponent<OnConveir_scr>().stop = false;
        }
    }
    public void Increase()
    {
        switcher++;
        if (switcher > a-1)
        {
            switcher = 0;
        }
        screen.transform.GetComponent<screen_spawner_scr>().switcher = switcher;
    }
    public void Decreace()
    {
        switcher--;
        if (switcher < 0)
        {
            switcher = a - 1;
        }
        screen.transform.GetComponent<screen_spawner_scr>().switcher = switcher;
    }
}
