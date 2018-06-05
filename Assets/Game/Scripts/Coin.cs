using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField]
    private AudioClip _coinPickUp;

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
                
                //give player the coin
                Player player = other.GetComponent<Player>();
                if(player != null){
                    player.hasCoin = true;
                    //play coin sound
                    AudioSource.PlayClipAtPoint(_coinPickUp, transform.position, 1f);
                    //destroy the coin
                    UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if(_uiManager != null){
                        _uiManager.CollectedCoin();
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
