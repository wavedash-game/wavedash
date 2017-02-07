using UnityEngine;
using System.Collections;

public class DotDestroy : MonoBehaviour {

    public float damage;
    public GameObject dot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (dot == null)
            Destroy(this.gameObject);
	}

    //A bullet hit the hitbox
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Bullet")
        {
            Destroy(dot);
            Destroy(this.gameObject);
        }
    }
}
