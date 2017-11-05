using UnityEngine;

/* for mouse control of 360 videos */
public class MouseFollow : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 360.0f;
    [SerializeField] private float clampAngle = 85.0f;


    private Vector3 mouseRotation;
    private Vector2 currentMousePos;

    public bool enableGyro = true;
    public bool enableMouseScroll = true;
    public bool preventScreenSleep = true;

    private void Start()
    {
        //turn this script off if not the unity editor platform
        if (!Application.isEditor)
            this.enabled = false;

        if (preventScreenSleep)
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


        mouseRotation = transform.localRotation.eulerAngles;
        currentMousePos = Vector2.zero;

    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //mouse moving event
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            Vector2 deltaMouse = new Vector2(mouseX, mouseY);
            Debug.Log(Input.GetAxis("Mouse X") + "," + Input.GetAxis("Mouse Y"));

            currentMousePos.y += deltaMouse.x * mouseSensitivity * Time.deltaTime;
            currentMousePos.x += deltaMouse.y * mouseSensitivity * Time.deltaTime;

            currentMousePos.x = Mathf.Clamp(currentMousePos.x, -clampAngle, clampAngle);

            mouseRotation = new Vector3(currentMousePos.x, currentMousePos.y, 0.0f);

        }


        //gyro + mouse offset
        transform.rotation = Quaternion.Euler(mouseRotation);
    }
}
