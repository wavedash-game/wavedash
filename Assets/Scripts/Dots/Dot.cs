using UnityEngine;
using System.Collections;

public class Dot : MonoBehaviour {

    public enum DotType  {Square=0, Sin=1, Saw=2};
    public GameObject player;
    public float amplitude;
    public float frequency;
    public float damage;
    public DotType dotType;
    public float startAngle;//Start angle in radians

    public bool playerDot;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public virtual void MoveDot(float distance)
    {
        //float angle = (distance + transform.localPosition.x) * 2.0f * Mathf.PI * frequency;// + startAngle;
        //float height = Mathf.Sin(angle) * amplitude;
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, height);
    }
}
