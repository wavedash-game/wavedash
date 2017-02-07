using UnityEngine;
using System.Collections;

public class SquareDot : Dot
{

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDot)
        {
            Vector2 me = new Vector2(transform.position.x, transform.position.y);
            Vector2 you = new Vector2(player.transform.position.x, player.transform.position.y);
            if (Vector2.Distance(me, you) < 1)
            {
                player.GetComponent<PlayerPivot>().Damage(damage);
                Destroy(this.gameObject);
            }
        }
    }

    public override void MoveDot(float distance)
    {
        //Height is (distance from start - (int)distance from start - 1) * amplitude
        //float angle = (distance + transform.localPosition.x) * 2.0f * Mathf.PI * frequency;// + startAngle;
        float height = ((distance + transform.localPosition.x) - Mathf.Floor((distance + transform.localPosition.x)));
        height = Mathf.Lerp(-1.0f, 1.0f, height);
        if (height <= -0.50)
            height = amplitude / 2.0f;
        else if (height <= 0.00)
            height = -amplitude / 2.0f;
        else if (height <= 0.50)
            height = amplitude / 2.0f;
        else
            height = -amplitude / 2.0f;

        transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
    }

    void OnCollisionEnter2(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            //Debug.Log("Hit!");
            other.gameObject.GetComponent<PlayerPivot>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
