using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //check for collision (onTrigger)
    void OnTriggerStay(Collider other)
    {
        //check if player
        if (other.tag == "Player")
        {
            //check for e key press
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picking up coin...");
                //give player the coin
                other.gameObject.GetComponent<Player>().hasCoin = true;
                //play coin sound
                GetComponent<AudioSource>().Play();
                //destroy the coin
                Destroy(this.gameObject, 2.4f);
            }
        }
    }
}
