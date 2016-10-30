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
        TargetScale = transform.lossyScale;
    }

    void FixedUpdate()
    {
        if (transform.localScale != TargetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, Speed);
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
