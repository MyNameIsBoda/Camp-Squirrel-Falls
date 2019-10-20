using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementText : MonoBehaviour
{
    Text percentageText;

    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void TextUpdate (float value)
    {
        percentageText.text = "Movement Speed: " + Mathf.RoundToInt(value * 100) + "%";
    }
}
