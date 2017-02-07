using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDotSpawn : MonoBehaviour {

    public List<Material> materials;
    public List<GameObject> spawners;
    public List<AudioClip> explosionClips;
    public GameObject sinWave, squareWave, sawWave;

    public float ampMin, ampMax;
    public float speedMin, speedMax;
    public float lengthMin, lengthMax;
    public float damage, frequency;
    public int numOfDots;//Number of dots per unit length

    public float timeDelay;
    public float timeDelaySlope;
    public float spawnDistance;
    float currentTime = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if(currentTime >= timeDelay)
        {
            //Debug.Log(currentTime);
            SpawnEnemy();
            currentTime = 0;
            timeDelay -= timeDelaySlope;
        }
	}

    void SpawnEnemy()
    {
        int type = (int)(Random.value * 3.0f);

        GameObject g;

        switch(type)
        {
            case 0:
                g = Instantiate(sinWave) as GameObject;
                break;
            case 1:
                g = Instantiate(squareWave) as GameObject;
                break;
            case 2:
                g = Instantiate(sawWave) as GameObject;
                break;
            default:
                g = Instantiate(sinWave) as GameObject;
                break;
        }

        g.transform.position = spawners[(int)(Random.value * spawners.Count)].transform.position;
        float amp = Random.Range(ampMin, ampMax);
        float speed = Random.Range(speedMin, speedMax);
        float length = Random.Range(lengthMin, lengthMax);

        DotHost d = g.GetComponent<DotHost>() as DotHost;
        d.GetComponent<AudioSource>().clip = explosionClips[(int)Random.Range(0, explosionClips.Count)];
        d.InitDots(damage, speed, (int)((float)numOfDots * length), length, amp, 1, materials[(int)(Random.value * materials.Count)]);

    }
}
