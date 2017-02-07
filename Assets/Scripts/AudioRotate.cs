using UnityEngine;
using System.Collections;

public class AudioRotate : MonoBehaviour {

    public float speed;

	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
