using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Vector2 shootLocation;
    public float speed = 20f;
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }


    void Fire()
    {
        shootLocation = new Vector2(bulletSpawn.transform.position.x, bulletSpawn.transform.position.y);
        // Create the Bullet from the Bullet Prefab


        // Add velocity to the bullet
        // bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;
        //bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10), ForceMode2D.Impulse);

        GameObject clone = Instantiate(bulletPrefab, shootLocation, Quaternion.identity) as GameObject;
        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        clonerb.AddRelativeForce(transform.TransformDirection(new Vector2((Mathf.Cos(transform.rotation.z * Mathf.Deg2Rad) * speed),
                                                                             (Mathf.Sin(transform.rotation.z * Mathf.Deg2Rad) * speed))),
                                                                             ForceMode2D.Impulse);

        // Destroy the bullet after 2 seconds

    }



}