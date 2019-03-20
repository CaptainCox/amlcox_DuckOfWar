using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    public float speed = 50f;

    public Text scoreText;
    public Text finishText;
    private int score;
    Vector3 mechMove;
    Rigidbody mechRigid;
    int floorMask;
    private Camera mainCamera;
    public static Vector3 Point;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        score = 0;
        setScore();
        finishText.text = "";
    }

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        mechRigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        MechMove(horiz, vert);
        
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void MechMove(float horiz, float vert)
    {
        mechMove.Set(horiz, 0f, vert); // deciding vector for moving

        mechMove = mechMove.normalized * speed * Time.deltaTime; // making the movement based on speed per second

        mechRigid.MovePosition(transform.position + mechMove); // moving the rigid body
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            setScore();
        }
    }
    void setScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 16)
        {
            finishText.text = "Congratulations! You got all of the pickups!";
        }
    }
}
