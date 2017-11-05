using UnityEngine;


/* For touch + gyro control of 360 videos */
public class TouchFollow : MonoBehaviour
{
    [SerializeField] private Vector2 scrollSensitivity = new Vector2(10.0f, 10.0f);
	[SerializeField] private float clampAngle = 85.0f;


    private Vector3 mouseRotation;
    private Vector2 currentMousePos;


    public bool enableGyro = true;
    public bool enableMouseScroll = true;
    public bool preventScreenSleep = true;

	private void Start ()
	{
        //turn this script on only on mobile platforms
        if (!Application.isMobilePlatform)
            this.enabled = false;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (preventScreenSleep)
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


        mouseRotation = transform.localRotation.eulerAngles;
        currentMousePos = Vector2.zero;
        InitGyro();
	}

    private void Update()
    {


        Vector3 gyroRotation = Vector3.zero;
        if (enableGyro)
        {
            //gyro controls for camera
            gyroRotation = GetGyroRotation().eulerAngles;
        }

        foreach (Touch t in Input.touches)
        {
            //mouse moving event
            float mouseX = t.deltaPosition.x;
            float mouseY = -t.deltaPosition.y;

            Vector2 deltaMouse = new Vector2(mouseX, mouseY);
            Debug.Log(Input.GetAxis("Mouse X") + "," + Input.GetAxis("Mouse Y"));

            currentMousePos.y += deltaMouse.x * scrollSensitivity.x * t.deltaTime;
            currentMousePos.x += deltaMouse.y * scrollSensitivity.y * t.deltaTime;

            currentMousePos.x = Mathf.Clamp(currentMousePos.x, -clampAngle, clampAngle);

            mouseRotation = new Vector3(currentMousePos.x, currentMousePos.y, 0.0f);
        }
        /*
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
        */

        //gyro + mouse offset
        transform.rotation = Quaternion.Euler(gyroRotation + mouseRotation);
    }



    //==============================================================
    //Gyro Manager
    //http://answers.unity3d.com/questions/434096/lock-rotation-of-gyroscope-controlled-camera-to-fo.html


    private static bool gyroInitialized = false;

    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope;
        }
    }

    private static void InitGyro()
    {
        if (HasGyroscope)
        {
            Input.gyro.enabled = true;                // enable the gyroscope
            Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
        }
        gyroInitialized = true;
    }


    public static Quaternion GetGyroRotation()
    {
        if (!gyroInitialized)
        {
            InitGyro();
        }

        return HasGyroscope
            ? new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0)
            : Quaternion.identity;
    }

}
