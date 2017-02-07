using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DotHost : MonoBehaviour {

    public float damage;
    public float speed;
    public int numOfDots;
    public GameObject dot;
    public GameObject hitter;
    public float length;
    public float amplitude, frequency;
    public Material mat;
    Vector3 startPos;
    List<Dot> dots;
    bool initialized = false;
    bool dead = false;
    float lastPos;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (initialized)
        {
            float distance = Vector3.Distance(transform.position, startPos);
            for(int i = dots.Count - 1; i >= 0; i--)
            {
                if (dots[i] == null)
                {
                    dots.RemoveAt(i);
                }
                else
                    dots[i].MoveDot(distance);

            }
            if (dots.Count == 0)
            {
                if (!dead)
                {
                    dead = true;
                    GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                    hitter.GetComponent<ParticleSystem>().Play();
                }
                speed = 0;
                if (!GetComponent<AudioSource>().isPlaying && !hitter.GetComponent<ParticleSystem>().isPlaying)//Wait until clip is done to destroy
                    Destroy(this.gameObject);
            }

            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void InitDots(float dmg, float spd, int dotCount, float lngth, float amp, float freq, Material mat)
    {
        this.mat = mat;
        damage = dmg;
        speed = spd;
        numOfDots = dotCount;
        length = lngth;
        amplitude = amp;
        frequency = freq;
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        SetAngle();
        dots = new List<Dot>();
        startPos = transform.position;
        for (int i = 0; i < numOfDots; i++)
        {
            GameObject t = Instantiate(dot) as GameObject;
            t.transform.parent = transform;
            t.transform.rotation = transform.rotation;//Rotate the dot the right way
            t.transform.localPosition = Vector3.zero;
            t.transform.localPosition = new Vector3(-(float)i * (length / (float)numOfDots) * t.transform.localScale.magnitude * 1.1f, 0, 0);//The space between dots can be changed
            t.GetComponent<Renderer>().material = mat;
            //Debug.Log(t.transform.localPosition);
            Dot d = t.GetComponent<Dot>() as Dot;
            //d.startAngle = 2 * Mathf.PI * frequency * t.transform.localPosition.magnitude;//The start angle is a function of the distance from local 0,0,0
            //Debug.Log(t.transform.localPosition.magnitude);
            d.amplitude = amplitude;
            d.frequency = frequency;
            d.damage = damage / numOfDots;
            d.MoveDot(0);
            dots.Add(d);

            GameObject des = Instantiate(hitter) as GameObject;
            des.transform.parent = transform;
            des.transform.rotation = transform.rotation;//Rotate the dot the right way
            des.transform.localPosition = Vector3.zero;
            des.transform.localPosition = new Vector3(-(float)i * (length / (float)numOfDots) * t.transform.localScale.magnitude * 1.1f, 0, 0);//The space between dots can be changed
            des.transform.localScale = new Vector3(des.transform.localScale.x, amplitude, des.transform.localScale.z);
        }
        hitter.transform.localPosition = dots[dots.Count - 1].transform.localPosition;
        initialized = true;
    }

    void SetAngle()
    {
        Vector3 tPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 playerPos = new Vector2(tPos.x, tPos.y);
        Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);

        Vector2 diff = playerPos - thisPos;

        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(diff.y, diff.x) * 180 / Mathf.PI);

    }
}
