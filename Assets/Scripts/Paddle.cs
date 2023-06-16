using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public float boundX = 7.5f;
    float movementHorizontal;

    private void Update()
    {
        //Palled movement
        movementHorizontal = Input.GetAxis("Horizontal");

        if((movementHorizontal > 0 && transform.position.x < boundX) || (movementHorizontal < 0 && transform.position.x > -boundX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}