using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerDotHost : MonoBehaviour {

    public GameObject dot;
    public GameObject lane;
    public float speed;

    public float amplitude;
    Dot d;

    public int health;
    bool init;

    AudioSource kb;
    GameObject dt;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(init);
        if (init == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, lane.transform.position, speed * Time.deltaTime);// (transform.right * speed * Time.deltaTime);//Move towards spawner
            d.MoveDot(Vector3.Distance(transform.position, lane.transform.position));
            //Debug.Log("Distance: " + Vector3.Distance(transform.position, lane.transform.position));
        }
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 20)
        {
            Destroy(dot);
            Destroy(gameObject);
        }
	}

    public void InitDot(GameObject lane)
    {
        kb = GameObject.FindGameObjectWithTag("PlayerKillBullet").GetComponent<AudioSource>();

        GameObject t = Instantiate(dot) as GameObject;
        t.transform.parent = transform;
        t.transform.rotation = transform.rotation;//Rotate the dot the right way
        t.transform.localPosition = Vector3.zero;
        //t.transform.localPosition = new Vector3(-(float)i * (length / (float)numOfDots) * t.transform.localScale.magnitude * 1.1f, 0, 0);//The space between dots can be changed
        //t.GetComponent<Renderer>().material = mat;
        //Debug.Log(t.transform.localPosition);
        Dot d = t.GetComponent<Dot>() as Dot;
        //d.startAngle = 2 * Mathf.PI * frequency * t.transform.localPosition.magnitude;//The start angle is a function of the distance from local 0,0,0
        //Debug.Log(t.transform.localPosition.magnitude);
        d.amplitude = 0.5f;
        d.frequency = 1;
        d.damage = 0;
        d.MoveDot(0);

        this.d = d;
        //GameObject g = Instantiate(dot) as GameObject;
        //d = dot.GetComponent<Dot>() as Dot;
        //d.amplitude = amplitude;
        //d.frequency = 1;
        //d.damage = 0;
        //d.playerDot = true;

        this.lane = lane;
        //transform.rotation = lane.transform.rotation;
        init = true;
        //d.MoveDot(Vector3.Distance(transform.position, lane.transform.position));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit");
        if(other.transform.tag == transform.tag)
        {
            Destroy(other.gameObject);
            health--;
            if(!kb.isPlaying)
                kb.PlayOneShot(kb.clip);
            if (health <= 0)
                Destroy(gameObject);
        }
    }

}
