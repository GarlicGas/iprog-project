using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    private float speed = 3f;
    public int turretSlot;
    public GameObject target;
    private GvrControllerInputDevice controller;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        controller = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 tgtPos = new Vector3(target.transform.position.x, 0, target.transform.position.z) - transform.position;
            Vector3 turRotation = Vector3.RotateTowards(transform.forward, tgtPos, speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(turRotation);
        }

        if (controller.GetButtonDown(GvrControllerButton.TouchPadButton) && passThres())
        {
            target = GvrPointerInputModule.CurrentRaycastResult.gameObject;
        }
    }

    private bool passThres()
    {
        switch (turretSlot)
        {
            case 1:
                if (controller.TouchPos.y > 0.707f)
                {
                    return true;
                }
                else return false;

            case 2:
                if (controller.TouchPos.x > 0.707f)
                {
                    return true;
                }
                else return false;

            case 3:
                if (controller.TouchPos.y < -0.707f)
                {
                    return true;
                }
                else return false;

            case 4:
                if (controller.TouchPos.x < -0.707f)
                {
                    return true;
                }
                else return false;

            default:
                return false;
        }
    }
}
