using UnityEngine;

public class BlockScale : MonoBehaviour
{
    private bool canScale;
    private Vector3 TargetScale;

    public float Scale;
    public float Speed;

    void Awake()
    {
        canScale = true;
    }

    void FixedUpdate()
    {
        if(canScale)
        {
            TargetScale = transform.localScale;
        }
        else if (transform.localScale != TargetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Speed);

            var position = transform.position;

            var collisions = Physics.OverlapSphere(position, 5f);

            foreach (Collider hit in collisions)
            {
                if (hit.tag == "Block")
                {
                    var rigidBody = hit.GetComponent<Rigidbody>();

                    if (rigidBody != null)
                    {
                        rigidBody.WakeUp();
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        var target = hit.gameObject;

        if (canScale && target.tag == "Ball")
        {
            TargetScale.Scale(new Vector3(Scale, Scale, Scale));
            canScale = false;
        }
    }
}
