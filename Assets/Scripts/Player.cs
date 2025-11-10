using UnityEngine;

public class Player : Entity 
{
    public string playerName = "Murphy";
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        float movedistance = Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W)) movement += Vector3.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.down;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;

        if (movement.magnitude > 0)
        {
            transform.Translate(movement.normalized * movedistance, Space.World);
        }
    }


}

