using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShootBack : MonoBehaviour {
    public const double TwoPi = Mathf.PI * 2.0d;
    public List<GameObject> spawners;
    public GameObject sinWave;
    public GameObject sawWave;
    public GameObject sqrWave;
    PlayerPivot playerPivot;

    public float degreesPerDot;//Number of degrees to rotate to fire off a dot
    public int health;
    float lastAngle;
    float deadZone = 0.25f;


	// Use this for initialization
	void Start () {
        playerPivot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPivot>() as PlayerPivot;
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject.FindGameObjectWithTag("Lanes").transform.Rotate(new Vector3(0, 0, 1));
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    
        //}
        //Debug.Log(Input.GetAxis("Mouse X") + "\t" + Input.GetAxis("Mouse Y"));
        if (Input.GetAxis("Mouse Y") > deadZone || Input.GetAxis("Mouse Y") < -deadZone || Input.GetAxis("Mouse X") > deadZone || Input.GetAxis("Mouse X") < -deadZone)
        {
            float angle = Mathf.Atan2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * 180 / Mathf.PI;
            if(Mathf.Abs(angle - lastAngle) > degreesPerDot)
            {
                lastAngle = angle;
                FireSin();
                if (!GetComponent<AudioSource>().isPlaying)
                    GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }
            //Debug.Log("Angle: " + angle + "\tLast Angle: " + lastAngle + "\tDifference: " + Mathf.Abs(angle - lastAngle));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            FireSaw();
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            FireSaw();
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            FireSqr();
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            FireSqr();
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
    }

    void FireSin()
    {
        float angt = playerPivot.angle;// - (GameObject.FindGameObjectWithTag("Lanes").transform.eulerAngles.z + 45.0f);
        //Debug.Log("Angt: " + angt);
        angt += 45.0f / 2.0f;
        if (angt < 0)
            angt += 360.0f;
        GameObject g = Instantiate(sinWave) as GameObject;
        g.transform.position = playerPivot.gameObject.transform.position;
        //g.transform.eulerAngles = new Vector3(0, 0, AngleBetweenVector2(new Vector2(g.transform.position.x, g.transform.position.y), new Vector2(playerPivot.gameObject.transform.position.x, playerPivot.gameObject.transform.position.y)));// + new Vector3(0, 0, 90);

        float angle = 45.0f * Mathf.Floor(angt / 45.0f);
        //Debug.Log("Angt: " + angt + "\t" + "Spawner: " + Mathf.Floor(angt / 45.0f) + "\t" + "Angle: " + angle);
        //Debug.Log();
        g.transform.eulerAngles = new Vector3(0, 0, angle);// - 45.0f);
        //Debug.Log(g.transform.eulerAngles);
        g.GetComponent<PlayerDotHost>().InitDot(spawners[Mathf.FloorToInt(angt / 45.0f)]);
        g.GetComponent<PlayerDotHost>().health = health;
    }
    void FireSaw()
    {
        float angt = playerPivot.angle;// - (GameObject.FindGameObjectWithTag("Lanes").transform.eulerAngles.z + 45.0f);
        //Debug.Log("Angt: " + angt);
        angt += 45.0f / 2.0f;
        if (angt < 0)
            angt += 360.0f;
        GameObject g = Instantiate(sawWave) as GameObject;
        g.transform.position = playerPivot.gameObject.transform.position;
        //g.transform.eulerAngles = new Vector3(0, 0, AngleBetweenVector2(new Vector2(g.transform.position.x, g.transform.position.y), new Vector2(playerPivot.gameObject.transform.position.x, playerPivot.gameObject.transform.position.y)));// + new Vector3(0, 0, 90);

        float angle = 45.0f * Mathf.Floor(angt / 45.0f);
        //Debug.Log("Angt: " + angt + "\t" + "Spawner: " + Mathf.Floor(angt / 45.0f) + "\t" + "Angle: " + angle);
        //Debug.Log();
        g.transform.eulerAngles = new Vector3(0, 0, angle);// - 45.0f);
        //Debug.Log(g.transform.eulerAngles);
        g.GetComponent<PlayerDotHost>().InitDot(spawners[Mathf.FloorToInt(angt / 45.0f)]);
        g.GetComponent<PlayerDotHost>().health = health;
    }
    void FireSqr()
    {
        float angt = playerPivot.angle;// - (GameObject.FindGameObjectWithTag("Lanes").transform.eulerAngles.z + 45.0f);
        //Debug.Log("Angt: " + angt);
        angt += 45.0f / 2.0f;
        if (angt < 0)
            angt += 360.0f;
        GameObject g = Instantiate(sqrWave) as GameObject;
        g.transform.position = playerPivot.gameObject.transform.position;
        //g.transform.eulerAngles = new Vector3(0, 0, AngleBetweenVector2(new Vector2(g.transform.position.x, g.transform.position.y), new Vector2(playerPivot.gameObject.transform.position.x, playerPivot.gameObject.transform.position.y)));// + new Vector3(0, 0, 90);

        float angle = 45.0f * Mathf.Floor(angt / 45.0f);
        //Debug.Log("Angt: " + angt + "\t" + "Spawner: " + Mathf.Floor(angt / 45.0f) + "\t" + "Angle: " + angle);
        //Debug.Log();
        g.transform.eulerAngles = new Vector3(0, 0, angle);// - 45.0f);
        //Debug.Log(g.transform.eulerAngles);
        g.GetComponent<PlayerDotHost>().InitDot(spawners[Mathf.FloorToInt(angt / 45.0f)]);
        g.GetComponent<PlayerDotHost>().health = health;
    }
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
