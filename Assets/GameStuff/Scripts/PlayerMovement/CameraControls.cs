using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Camera cam;
    public GameObject player;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5.0f, Vector3.up) * offset;
        cam.transform.position = player.transform.position + offset;
        Vector3 hold = new Vector3(player.transform.position.x, cam.transform.position.y, player.transform.position.z);
        transform.LookAt(hold);
    }
}
