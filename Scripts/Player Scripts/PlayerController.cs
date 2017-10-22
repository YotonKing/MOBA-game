using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public MinionScript focus;

    Camera cam;
    public LayerMask movementMask;
    PlayerMotor motor;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) //movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }

            if (Physics.Raycast(ray, out hit, 100))
            {
                MinionScript minionScript = hit.collider.GetComponent<MinionScript>();
                if (minionScript != null)
                {
                    SetFocus(minionScript);
                }
            }
        }
	}

    void SetFocus (MinionScript newFocus)
    {
        focus = newFocus;
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        focus = null;
        motor.StopFollowingTarget();
    }

}
