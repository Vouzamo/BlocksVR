using UnityEngine;

public class BlockExplode : MonoBehaviour
{
    public float Fuse;
    public float ExplosiveForce;
    public float Radius;

    void OnCollisionEnter(Collision hit)
    {
        var target = hit.gameObject;

        if (target.tag == "Ball")
        {
            Invoke("Explode", Fuse);
        }
    }

    void Explode()
    {
        var position = transform.position;

        var collisions = Physics.OverlapSphere(position, Radius);

        foreach (Collider hit in collisions)
        {
            if (hit.tag == "Block")
            {
                var rigidBody = hit.GetComponent<Rigidbody>();

                if (rigidBody != null)
                {
                    rigidBody.AddExplosionForce(ExplosiveForce, transform.position, Radius);
                }
            }
        }

        Destroy(gameObject);
    }
}
