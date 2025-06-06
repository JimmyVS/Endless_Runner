using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3;
    public float leftRightSpeed = 4;
    static public bool canMove = false;

    public bool isJumping = false;
    public bool comingDown = false;

    public GameObject playerObject;
    public AudioSource JumpSound;
    public AudioSource footsteps;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (this.gameObject.transform.position.x > LevelBoundaries.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (this.gameObject.transform.position.x < LevelBoundaries.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");

                    StartCoroutine(JumpSequence());
                }
            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }

            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        footsteps.Stop();

        yield return new WaitForSeconds(0.45f);
        comingDown = true;

        yield return new WaitForSeconds(0.45f);
        JumpSound.Play();
        footsteps.Play();

        comingDown = false;
        isJumping = false;

        playerObject.GetComponent<Animator>().Play("Fast Run");
    }
}
