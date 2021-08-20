using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TweenButton : MonoBehaviour
{
    [SerializeField] private float buttonClickTime;    
    [SerializeField] private float fadeTime;    
    Vector3 fullScreenScale = new Vector3(5, 5, 1);
    float fullScreenRotation = 90;

    public void Fade(GameObject gameObject)
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), buttonClickTime);
    }

    public void FillScreen(GameObject gameObject)
    {
        LeanTween.scale(gameObject, fullScreenScale, buttonClickTime);
        LeanTween.move(gameObject, new Vector2(0,0), buttonClickTime);
        LeanTween.rotateZ(gameObject, fullScreenRotation, buttonClickTime);
        LeanTween.color(gameObject, new Color(0,0,0,0), buttonClickTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //LeanTween.alpha(gameObject.transform.GetChild(0).gameObject, 0, fadeTime);
    }

    public void FillScreen()
    {
        FillScreen(gameObject);
    }

}
