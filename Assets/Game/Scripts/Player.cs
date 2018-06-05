using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;
    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        //if left click
        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            Shoot();
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo == 0){
            StartCoroutine("Reload");
        }

        //if esc key pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //unhide mouse cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    void Shoot(){
        _muzzleFlash.SetActive(true);
        currentAmmo--;
        if (_weaponAudio.isPlaying == false)
        {
            _weaponAudio.Play();
        }
        //cast ray from center point of main camera
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit " + hitInfo.transform.name);
            GameObject hitMarker = (GameObject)Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
        }
    }

    IEnumerator Reload(){
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
    }

}
