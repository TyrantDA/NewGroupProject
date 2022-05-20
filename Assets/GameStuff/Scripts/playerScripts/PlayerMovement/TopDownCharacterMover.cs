using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;
    public Animator anim;
    [SerializeField]
    private bool RotateTowardMouse;
    public bool falling;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;
    ItemListUI playerInventory;
    public ItemInfo StarPotion;
    public bool notActive = false;
    Rigidbody m_Rigidbody;
    public bool timeout;

    public GameObject Map;
    bool mapOpen = false;

   
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        _input = GetComponent<InputHandler>();
        playerInventory = GetComponent<ItemListUI>();
        timeout = false;
    }


    IEnumerator running()
    {
        notActive = true;
        yield return new WaitForSeconds(10);
        notActive = false;
        MovementSpeed = 10;
        anim.SetBool("run", false);
    }
    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1);
        timeout = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && falling == false)
        {
            if (timeout == false)
            {
                timeout = true;
                StartCoroutine("cooldown");
                m_Rigidbody.AddForce(transform.up * 3000);
                falling = true;
            }
        }
        if (playerInventory.HasItem(StarPotion) > 0)
        {
            if (!notActive)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    StartCoroutine("running");
                    MovementSpeed = 20;
                    anim.SetBool("run", true);
                    playerInventory.AddItem(StarPotion, -1);
                    int achieve = PlayerPrefs.GetInt("that company property", 0);
                    if (achieve == 0)
                    {
                        PlayerPrefs.SetInt("that company property", 1);
                    }

                }
            }
        }

        //if(Input.GetKeyDown(KeyCode.F1))
        //{
        //    ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshots/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        //    UnityEditor.AssetDatabase.Refresh();
        //}

        if(Input.GetKeyDown(KeyCode.M))
        {
            if(!mapOpen)
            {
                Map.SetActive(true);
                mapOpen = true;
                Time.timeScale = 0f;
            }
            else
            {
                Map.SetActive(false);
                mapOpen = false;
                Time.timeScale = 1f;
            }
        }

            var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }

    }


    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);
  
        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        if (transform.position != targetPosition)
        {
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);

        }
        transform.position = targetPosition;
        return targetVector;

    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
    void OnCollisionStay(Collision other)
    {
        falling = false;
    }
}
