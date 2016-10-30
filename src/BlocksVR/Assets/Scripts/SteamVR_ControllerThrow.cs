using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class SteamVR_ControllerThrow : MonoBehaviour
{
    public GameObject Projectile;
    public float Multiplier;

    private LevelManager LevelManager;

    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        LevelManager = LevelManager.Instance;
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (LevelManager.Data.Ammo > 0)
            {
                var projectile = (GameObject)Instantiate(Projectile, gameObject.transform.position, gameObject.transform.rotation);

                joint = projectile.AddComponent<FixedJoint>();
                joint.connectedBody = gameObject.GetComponent<Rigidbody>();

                LevelManager.Data.Ammo--;
            }
        }
        else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            var projectile = joint.gameObject;
            var rigidbody = projectile.GetComponent<Rigidbody>();
            DestroyImmediate(joint);
            joint = null;
            Destroy(projectile, 15.0f);

            var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(device.velocity) * Multiplier;
                rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
            }
            else
            {
                rigidbody.velocity = device.velocity;
                rigidbody.angularVelocity = device.angularVelocity;
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
    }
}
