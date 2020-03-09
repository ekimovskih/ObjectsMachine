using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnConveir_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 left = new Vector3(1, 0, 0);
    public Vector3 back = new Vector3(0, 0, -1);
    public float speed = 0.5f;
    public bool stop = false;
    private float timer;
    public float vol = 0.3f;
    public bool alreadystoppedonColorer = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(vol, 0f, 1f);
        this.gameObject.GetComponent<Rigidbody>().isKinematic = stop;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "conveir")
        {
            if (other.transform.rotation.y == 0 && !stop)
            {
                this.gameObject.transform.position += left * Time.deltaTime * speed;
            }
            else if (!stop)
            {
                this.gameObject.transform.position += back * Time.deltaTime * speed;
                if (this.gameObject.tag != "medival") //да я знаю что неправильно пишу этот тег, но мне лень все исправлять
                {
                    this.gameObject.transform.rotation = new Quaternion(0, 90, 0, 0);
                }
            }
            if (!this.gameObject.transform.GetComponent<AudioSource>().isPlaying && !stop)
            {
                this.gameObject.transform.GetComponent<AudioSource>().Play();
            }
        }
        if (other.tag == "stopper" && this.gameObject.transform.GetComponent<AudioSource>().isPlaying && stop)
        {
            StartCoroutine(StopTheMusic(timer, true));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "stopper")
        {
            stop = true;
            timer = Time.time + 1f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Finish" || collision.collider.tag == "Untagged" || collision.collider.tag == "lorry" || collision.collider.tag == "medival")
        {
            this.gameObject.transform.GetComponent<AudioSource>().Stop();
        }
    }

    IEnumerator StopTheMusic(float end, bool meh)
    {
        yield return new WaitForSeconds(0.1f);
        float start = Time.time;
        if (Time.time > end)
        {
            this.gameObject.transform.GetComponent<AudioSource>().Stop();
            this.gameObject.transform.GetComponent<AudioSource>().volume = vol;
        }
        else
        {
            this.gameObject.transform.GetComponent<AudioSource>().volume = vol * (Mathf.Max(end - start, 0));
        }
        if (!stop && meh)
        {
            this.gameObject.transform.GetComponent<AudioSource>().volume = vol;
        }
    }
    

}
