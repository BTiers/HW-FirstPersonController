using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed = 1f;
    public GameObject explosion;
    private Plateform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = Plateform.instance;
        transform.LookAt(target.transform.position);
        transform.Rotate(new Vector3(0,-180,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(clone, 1f);
        }

    }
}
