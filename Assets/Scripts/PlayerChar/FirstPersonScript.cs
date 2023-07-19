using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonScript : MonoBehaviour
{
    [Header("Player settings")]

    public Rigidbody rb;
    public GameObject mesh;
    public float walk_speed_mod;
    public float look_rot_mod;

    public float max_speed;

    [Header("Camera settings")]

    public Camera cam;

    private Vector2 _movement_direction;
    private Vector2 _look_rotation;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            print("No rigidbody found!");
        }

        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {

        Vector3 move_dir = new Vector3(_movement_direction.x, 0.0f, _movement_direction.y);

        if (rb.velocity.x + rb.velocity.z < max_speed)
        {
            rb.AddRelativeForce(move_dir * walk_speed_mod);
        }
    }

    private void RotatePlayer()
    {
        Vector2 mouse_screen_pos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mouse_screen_pos);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f) )
        {
            Vector3 look_at_spot = hit.point;
            look_at_spot.y = 0.0f;

            mesh.transform.LookAt(look_at_spot);
            mesh.transform.eulerAngles = new Vector3(0.0f, mesh.transform.eulerAngles.y, 0.0f);
            print(look_at_spot);

        }
    }


    public void UpdateRotation(Vector2 rot)
    {
        _look_rotation = rot;
    }

    public void UpdateDirection(Vector2 direction)
    {
        _movement_direction = direction;
    }
}
