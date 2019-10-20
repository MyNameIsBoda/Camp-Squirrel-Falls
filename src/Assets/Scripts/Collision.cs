////using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Collision : MonoBehaviour
//{
//    public TextMeshPro scoreText;
//    int currentScore = 0;
//    AudioSource audioData;
//    void Start()
//    {
//        audioData = GetComponent<AudioSource>();
//    }
    
//    void OnTriggerEnter(Collider other){
//        if(this.tag == other.tag){
//            other.tag = "Hit";
//            other.gameObject.GetComponent<Mole>().current_state = Mole.MOLE_STATE.DIG;
//            audioData.Play(0);
//            currentScore ++;;
//        } else if(other.tag == "Red" || other.tag == "Blue"){
//            currentScore = 0;
//        } else if(other.tag == "Play"){
//            if(other.GetComponent<MoleController>().game_state == MoleController.GAME_STATES.READY_TO_PLAY)
//            {
//                other.GetComponent<MoleController>().game_state = MoleController.GAME_STATES.SETUP;
//            }
//        } else if(other.tag == "Stop"){
//            if(other.GetComponent<MoleController>().game_state == MoleController.GAME_STATES.PLAY)
//            {
//                other.GetComponent<MoleController>().game_state = MoleController.GAME_STATES.RESET;
//            }
//        }
//        scoreText.text = "Score: " + currentScore;
//    }
//}

