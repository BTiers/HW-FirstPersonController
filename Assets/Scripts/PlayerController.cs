using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float cameraRotateSpeed = 20f;
    public AudioSource shotgunSound;
    private Rigidbody player;
    public Rigidbody bullet;
    public Rigidbody barrelEnd;
    private float firerate = 0.5f;
    private float lastShot = 0f;

    private void Start()
    {
        player = GetComponent<Rigidbody>();   
    }

    private bool canShoot()
    {
        lastShot += Time.deltaTime;
        return lastShot >= firerate;        
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        Vector3 rotation = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;

        if (direction.x != 0)
            player.MovePosition(player.position + transform.right * direction.x * movementSpeed * Time.deltaTime);
        if (direction.z != 0)
            player.MovePosition(player.position + transform.forward * direction.z * movementSpeed * Time.deltaTime);

        Vector3 rotateXValue = new Vector3(0, (Input.GetAxis("Mouse X") * cameraRotateSpeed * Time.deltaTime), 0);
        Vector3 rotateYValue = new Vector3(-(Input.GetAxis("Mouse Y") * cameraRotateSpeed * Time.deltaTime), 0, 0);
        transform.eulerAngles += rotateXValue;
        transform.eulerAngles += rotateYValue;

        if (Input.GetMouseButton(1))
        {
            if (canShoot())
            {
                Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
                bulletClone.velocity = transform.forward * 50f;
                lastShot = 0f;
                Destroy(bulletClone.gameObject, 5f);
                shotgunSound.Play();
            }
        }
    }

    public void endGame()
    {
        Application.Quit();
    }
}
