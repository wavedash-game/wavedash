using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialColorShifter : MonoBehaviour {

    public List<Material> materials;

    public float fadeSpeed;//How fast the colors fade
    public float doneZone;
    List<float> fadeSpeeds;
    List<Color> colors;

	// Use this for initialization
	void Start () {
        fadeSpeeds = new List<float>();
        colors = new List<Color>();

        foreach(Material m in materials)
        {
            m.color = Color.HSVToRGB(Random.value, 1, 1);//Assign a random color
            colors.Add(Color.HSVToRGB(Random.value, 1, 1));
            fadeSpeeds.Add(Random.Range(0, fadeSpeed));
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < materials.Count; i++)
        {
            if (Vector4.Distance(materials[i].color, colors[i]) < doneZone)
            {
                materials[i].color = colors[i];
                colors[i] = Color.HSVToRGB(Random.value, 1, 1);//Assign a random color;
            }
            else
                materials[i].color = Color.Lerp(materials[i].color, colors[i], Time.deltaTime * fadeSpeeds[i]);
        }
	}
}
