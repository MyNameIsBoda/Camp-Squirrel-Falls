using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_Playzone: MonoBehaviour
{
    public Canvas longbowCanvas;
    public Canvas campfireCanvas;
    public Canvas pondCanvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player" && this.tag == "longbowZone")
        {
            longbowCanvas.enabled = true;
        }
        else if (other.tag == "player" && this.tag == "campfireZone")
        {
            campfireCanvas.enabled = true;
        }
        else if (other.tag == "player" && this.tag == "pondZone")
        {
            pondCanvas.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player" && this.tag == "longbowZone")
        {
            longbowCanvas.enabled = false;
        }
        else if (other.tag == "player" && this.tag == "campfireZone")
        {
            campfireCanvas.enabled = false;
        }
        else if (other.tag == "player" && this.tag == "pondZone")
        {
            pondCanvas.enabled = false;
        }
    }
}
