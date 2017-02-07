using UnityEngine;
using System.Collections;

public class SinDot : Dot {

    public const double TwoPi = Mathf.PI * 2.0d;
    public static float[] sin_table = { 0.0f, 0.0980171403295605f, 0.19509032201612808f, 0.2902846772544621f, 0.3826834323650894f, 0.4713967368259972f, 0.5555702330196017f, 0.6343932841636449f, 0.7071067811865469f, 0.7730104533627363f, 0.8314696123025447f, 0.8819212643483545f, 0.9238795325112863f, 0.9569403357322085f, 0.9807852804032302f, 0.9951847266721967f, 1.0f, 0.995184726672197f, 0.9807852804032308f, 0.9569403357322094f, 0.9238795325112875f, 0.881921264348356f, 0.8314696123025463f, 0.7730104533627385f, 0.7071067811865491f, 0.6343932841636476f, 0.5555702330196043f, 0.4713967368260002f, 0.38268343236509234f, 0.29028467725446533f, 0.19509032201613122f, 0.09801714032956392f, 3.2310891488651735e-15f, -0.0980171403295575f, -0.19509032201612486f, -0.29028467725445917f, -0.38268343236508634f, -0.4713967368259945f, -0.555570233019599f, -0.6343932841636426f, -0.7071067811865446f, -0.7730104533627344f, -0.8314696123025428f, -0.8819212643483528f, -0.9238795325112852f, -0.9569403357322076f, -0.9807852804032295f, -0.9951847266721964f, -1.0f, -0.9951847266721974f, -0.9807852804032314f, -0.9569403357322103f, -0.9238795325112887f, -0.8819212643483576f, -0.8314696123025485f, -0.7730104533627402f, -0.7071067811865515f, -0.63439328416365f, -0.5555702330196074f, -0.47139673682600264f, -0.38268343236509533f, -0.29028467725446844f, -0.19509032201613483f, -0.0980171403295667f, };
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(playerDot);
        if (!playerDot)
        {
            //Debug.Log("Checking...");
            Vector2 me = new Vector2(transform.position.x, transform.position.y);
            Vector2 you = new Vector2(player.transform.position.x, player.transform.position.y);
            if (Vector2.Distance(me, you) < 1)
            {
                //Debug.Log("Hit!");
                player.GetComponent<PlayerPivot>().Damage(damage);
                Destroy(this.gameObject);
            }
        }
	}

    public override void MoveDot(float distance)
    {
        float angle = (distance + transform.localPosition.x) * (float)TwoPi * frequency;// + startAngle;
        angle *= 180.0f / Mathf.PI;//Convert to degrees

        while (angle < 0)//Make positive
            angle+= 360;
        while (angle >= 360)//Make between 0-360
            angle -= 360;

        int index = Mathf.FloorToInt((angle / 360.0f) * 64.0f);//Calculate angle

        if(index < 0 || index > 63)
            Debug.LogError("Index: " + index + "\t" + "Angle: " + angle);
        float height = sin_table[index] * amplitude/2.0f;
        //Debug.Log("Height: " + height);
        transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
        //Debug.Log("Position: " + transform.localPosition);
        //if(playerDot)
        //   Debug.Log("Position: " + transform.localPosition);
    }
}
