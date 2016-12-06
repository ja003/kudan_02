using UnityEngine;
using System.Collections;
using Kudan.AR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceMarkerlessObject: MonoBehaviour
{  
    public KudanTracker _kudanTracker;
    public GameObject car;
    public GameObject car_up;
    public GameObject cube;
    public GameObject cube_2;

    public Button rotate_left;
    public Button rotate_right;

    public Button scale_up;
    public Button scale_down;

    public Button start_tracking;
    public Button stop_tracking;

    public Texture2D texture_source;

    // Use this for initialization
    void Start () {
        rotate_left.onClick.AddListener(() => RotateCar(5));
        rotate_right.onClick.AddListener(() => RotateCar(-5));

        scale_up.onClick.AddListener(() => ScaleCar(1));
        scale_down.onClick.AddListener(() => ScaleCar(-1));

        start_tracking.onClick.AddListener(() => StartTracking());
        stop_tracking.onClick.AddListener(() => StopTracking());


        //rotate_right.OnPointerDown.AddListener(() => RotateCar(1));

    }

    private static PlaceMarkerlessObject _instance;

    public static PlaceMarkerlessObject Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    // Update is called once per frame
    void Update () {
        //ScreenDebugger.Instance.DrawTexture(new Texture());
	}
    

    void RotateCar(float value)
    {
        cube.transform.RotateAround(
            cube.transform.position,
           cube_2.transform.position - cube.transform.position,
            value);
        car.transform.RotateAround(
            car.transform.position,
           car_up.transform.position - car.transform.position,
            value);
        /*car.transform.Rotate(
        car_up.transform.position - car.transform.position,
         value);*/
        /*cube.transform.Rotate(
            cube.transform.rotation.eulerAngles * value);*/
    }

    void ScaleCar(float value)
    {
        car.transform.localScale += new Vector3(value, value, value);
        
    }

    public void PlaceClick()
    {
        ScreenDebugger.Instance.AddDebug("click");

        Vector3 position;
        Quaternion orientation;

        _kudanTracker.StartLineRendering();
        //_kudanTracker.
        _kudanTracker.FloorPlaceGetPose(out position, out orientation);
        ScreenDebugger.Instance.AddDebug("floor = " + position + "," + orientation + "; ");
        _kudanTracker.ArbiTrackStart(position, orientation);
    }

    public void StopTracking()
    {
        SceneManager.LoadScene(0);
        _kudanTracker.StopTracking();

    }
    public void StartTracking()
    {
        _kudanTracker.StartTracking();
        print("!");
        ScreenDebugger.Instance.Debug("Start");
    }
}
