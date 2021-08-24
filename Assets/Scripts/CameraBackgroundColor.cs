using UnityEngine;

public class CameraBackgroundColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] private Color color1 = Color.red;
    [SerializeField] private Color color2 = Color.blue;
    [SerializeField] private float duration = 3.0F;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        mainCamera.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void SetColors(Color color1, Color color2)
    {
        this.color1 = color1;
        this.color2 = color2;
    }

    public void SetDuration(float time)
    {
        duration = time;
    }
}
