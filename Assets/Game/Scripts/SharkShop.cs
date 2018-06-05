using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //check for collision
    private void OnTriggerStay(Collider other)
    {
        //if player
        if (other.tag == "Player")
        {
            //if e key
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if ( player != null)
                {
                    //if player has coin
                    if (player.hasCoin == true)
                    {
                        //remove the coin from player
                        player.hasCoin = false;
                        //update inventory
                        UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (_uiManager != null)
                        {
                            _uiManager.RemoveCoin();
                        }
                        //play win sound
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapons();
                    }
                    //else Debug Get out of here!
                    else {
                        Debug.Log("Get out of here!");
                    }
                }
            }
        }
    }
}
