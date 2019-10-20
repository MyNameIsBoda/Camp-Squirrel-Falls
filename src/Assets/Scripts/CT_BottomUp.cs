using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_BottomUp : MonoBehaviour
{
    public int bottom = 1; 
    public GameObject[] mallows;

    public int GetBottom()
    {
        for (int i = 2; i >= 0; i--)
        {
            GameObject cooked = mallows[i].transform.GetChild(0).gameObject;
            GameObject placed = mallows[i].transform.GetChild(2).gameObject;
            if (mallows[i].activeSelf && !cooked.activeSelf && !placed.activeSelf)
            {
                //Debug.Log(i + 1);
                return i+1;
            }
        }
        return 1;
    }
}
