using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitsText : MonoBehaviour
{
    Text hitText;

    // Start is called before the first frame update
    void Start()
    {
        hitText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void TextUpdate(float value)
    {
        hitText.text = "Hits to Cut: " + value;
    }
}
