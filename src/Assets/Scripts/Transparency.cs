using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    public float transparency = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        Renderer r = gameObject.GetComponent<Renderer>();
        Color materialColor = r.material.color;
        r.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, transparency);
    }
}
