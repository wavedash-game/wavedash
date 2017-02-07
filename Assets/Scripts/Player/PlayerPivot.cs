using UnityEngine;
using System.Collections;

public class PlayerPivot : MonoBehaviour {

    public float health;
    public float deadZone;

    public float angle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone || Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI;
            transform.eulerAngles = Vector3.forward * (angle);
        }
	}

    public void Damage(float dmg)
    {
        health -= dmg;
    }
}