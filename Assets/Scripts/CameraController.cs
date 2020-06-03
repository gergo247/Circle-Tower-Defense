using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool moveCamera = true;

    public float panSpeed = 30f;
    public float panZoneSize = 20f;
    public float scrollSpeed = 5f;
    public float minScrollY = 10f;
    public float maxScrollY = 120f;


    // Update is called once per frame
    void Update()
    {
        //toggle camera movement
        if (Input.GetKeyDown("m"))
            moveCamera = !moveCamera;
        if (!moveCamera)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panZoneSize)
        {
            //move without physics , forward - 0 0 1
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x < panZoneSize)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <=  panZoneSize)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panZoneSize)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        //scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 *  scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minScrollY, maxScrollY);
        transform.position = pos;
    }
}
