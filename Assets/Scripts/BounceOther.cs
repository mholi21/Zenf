using UnityEngine;
using System.Collections;

public class BounceOther : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed); 
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = new Vector3(collision.rigidbody.velocity.x* Random.Range(-0.4f, -1.2f), 0f, collision.rigidbody.velocity.z * Random.Range(-0.4f, -1.2f));
    }
}