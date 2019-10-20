//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Quiver : MonoBehaviour
{
    public GameObject quiverSelection;
    public GameObject arrowHand;
    int quiverType;

    private void Start()
    {
        arrowHand = GameObject.Find("ArrowHand");
    }

    public void Change()
    {
        int quiver = quiverSelection.GetComponent<Dropdown>().value + 1;
        switch (quiverType)
        {
            case 1:
                arrowHand.GetComponent<Valve.VR.InteractionSystem.ArrowHand>().quiver = GameObject.Find("Quiver (Neck)");
                break;
            case 2:
                arrowHand.GetComponent<Valve.VR.InteractionSystem.ArrowHand>().quiver = GameObject.Find("Quiver (Shoulder)");
                break;
            case 3:
                arrowHand.GetComponent<Valve.VR.InteractionSystem.ArrowHand>().quiver = GameObject.Find("Quiver (Chest)");
                break;
            default:
                print("Oops");
                break;
        }
    }

    public void Disable()
    {
        arrowHand.GetComponent<Valve.VR.InteractionSystem.ArrowHand>().noQuiver ^= true;
    }
}
