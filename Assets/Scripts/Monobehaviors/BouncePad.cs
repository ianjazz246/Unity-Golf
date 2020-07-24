using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    // Maximum velocity for colliding rigid body to exit from this bounce pad.
    public float maxExitVelocity;
    public float forceStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

	private void OnCollisionEnter(Collision collision)
	{
        var collisionNormal = collision.GetContact(0).normal;
        Debug.Log($"Normal: {collisionNormal}");
        Debug.DrawRay(transform.position, collision.GetContact(0).normal, Color.red, 3);
        Debug.DrawRay(collision.rigidbody.position, collision.rigidbody.velocity, Color.blue, 3);
        var bounceForce = collisionNormal.normalized * forceStrength;
        collision.rigidbody.AddForce(bounceForce, ForceMode.Impulse);
	}
}
