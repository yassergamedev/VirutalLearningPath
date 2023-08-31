using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool isMoving = false;

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            // Check for touch, space key press, or remote button click
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    isMoving = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isMoving = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                isMoving = true;
            }
        }
        else if (Input.touchCount == 0 && Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Move the player character in the direction that the camera is facing
        transform.Translate(Camera.main.transform.forward * moveSpeed * Time.deltaTime);
    }
}
