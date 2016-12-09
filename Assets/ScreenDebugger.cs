using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenDebugger : MonoBehaviour
{
    public Text textField;

    private static ScreenDebugger _instance;

    public static ScreenDebugger Instance { get { return _instance; } }

    public Texture roadTex;

    WebCamTexture camTex;
    public Material mat_quad_cam_debug;

    void Start()
    {        
        //camTex = new WebCamTexture();
        //mat_quad_cam_debug.mainTexture = camTex;
        //camTex.Play();
    }

    void Update()
    {
        //roadTex = camTex;
    }

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

    public void AddDebug(string text)
    {
        AddDebug(text, ",");
    }
    public void AddDebug(string text, string separator)
    {
        textField.text += text + separator;
        if (textField.text.Length > 300)
            textField.text = "";
    }
    public void AddDebugInFrame(string text, int frequency)
    {
        if (Time.frameCount % frequency*2 == 0)
            AddDebug(text);
    }
    
    public Image image;

    public void DrawTexture(Texture texture)
    {
        image.material.mainTexture = texture;
    }

    /* public void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, 60, 60), texture, ScaleMode.ScaleToFit, true, 10.0F);
    }*/


    public void Debug(string text)
    {
        textField.text = text;
    }
}
