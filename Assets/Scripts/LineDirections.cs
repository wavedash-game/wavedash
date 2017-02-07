using UnityEngine;
using System.Collections;

public class LineDirections : MonoBehaviour {

    public float length;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.up*length);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * length);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * length);
    }
}
