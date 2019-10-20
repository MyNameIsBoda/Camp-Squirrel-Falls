using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_SmoreOrder : MonoBehaviour
{
    int numberPieces = 4;
    public int currentPieces = 0;
    public 
    AudioSource ding;
    public ParticleSystem puff;
    public GameObject currentSmore;
    public GameObject currentDisplay;
    public GameObject[] smores;
    public GameObject[] displays;
    List<string> tags = new List<string>();
    bool ordering = false;

    private void Start()
    {
        ding = GetComponent<AudioSource>();
        GetOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPieces == numberPieces)
        {
            currentPieces = 0;
            OrderUp();      
        }
    }

    public void OrderUp()
    {
        ding.Play(0);
        puff.Play();
        for(int i = 0; i < numberPieces; i++)
        { 
            GameObject outline = currentSmore.transform.GetChild(i).gameObject;
            outline.tag = tags[i];
            outline.GetComponent<MeshRenderer>().enabled = true;
            outline.GetComponent<BoxCollider>().enabled = true;
            outline.transform.GetChild(0).gameObject.SetActive(false);
        }
        tags.Clear();
        currentSmore.SetActive(false);
        currentDisplay.SetActive(false);
        GetOrder();
        
    }

    public void GetOrder()
    {
        int selection = Random.Range(0, 8);
        //Debug.Log(selection);
        currentSmore = smores[selection];
        currentDisplay = displays[selection];
        numberPieces = currentSmore.transform.childCount;
        //Debug.Log(numberPieces + " Pieces");
        GetTags();
        currentSmore.SetActive(true);
        currentDisplay.SetActive(true);
        ordering = false;
    }

    public void GetTags()
    {
        for(int i = 0; i < numberPieces; i++)
        {
            tags.Add(currentSmore.transform.GetChild(i).tag);
            //Debug.Log(tags[i]);
        }
    }
}

