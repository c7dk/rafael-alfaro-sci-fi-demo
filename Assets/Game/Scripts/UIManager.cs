using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private GameObject _Coin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateAmmo(int count){
        _ammoText.text = "Ammo: " + count;
    }

    public void UpdateCoin(bool hasCoin){
        if(hasCoin == true){
            _Coin.SetActive(true);
        } else {
            _Coin.SetActive(false);
        }
    }
}
