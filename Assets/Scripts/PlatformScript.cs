using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject fragmentPref; //Префаб цветного фрагмента
    [SerializeField] private Transform leftColorsStartPoint; //Начальная позиция левых цветных фрагментов
    [SerializeField] private Transform rightColorsStartPoint; //Начальная позиция правых цветных фрагментов
    [SerializeField] private SpriteRenderer headColor; //Цвет верхней поверхности
    [SerializeField] private float fragmentHeight = 2.8f; //Высота фрагмента
    [SerializeField] private List<GameObject> fragmentsLeft; //List фрагментов слева
    [SerializeField] private List<GameObject> fragmentsRight; //List фрагментов справа
    [SerializeField] private Color defaultColor; 
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float fadeInTime = 2; // Время за которе красится head

    private void Start()
    {
        //headColor.color = defaultColor;
        headColor.color = defaultColor;
        GameManager.instance.SetDefaultColor(defaultColor);
        ////fragmentHeight = fragmentPref.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        for (int i = 0; i < 2; i++)
        {
            CreateFragment(defaultColor);
            AddFragmentToRightSide();
        }
        CreateFragment();
        CreateFragment();
        CreateFragment();
        CreateFragment();
        NextColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { CreateFragment();  }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { DestroyFragment(); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { RevercePlatform(); }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextColor();
        }
        
    }

    private void CreateFragment()
    {
        CreateFragment(GameManager.instance.GetRandomColor());
    }

    private void CreateFragment(Color color)
    {
        //GameObject fragment = Instantiate(fragmentPref, leftColorsStartPoint.position, Quaternion.identity , leftColorsStartPoint.transform);
        GameObject fragment = Instantiate(fragmentPref, leftColorsStartPoint.position, gameObject.transform.rotation , leftColorsStartPoint.transform);
        fragment.GetComponent<SpriteRenderer>().color = color;
        fragment.transform.localPosition += new Vector3(0, ((fragmentsLeft.Count * fragmentHeight) * -1), 0);
        fragmentsLeft.Add(fragment);
    }

    private void DestroyFragment()
    {
        Vector2 fragmentPosition = new Vector2(0, 0);
        StartCoroutine(IEnumerators.SmoothLerpAndDestroy(fragmentsLeft[0].gameObject, fragmentPosition,  0.2f));

        fragmentsLeft.Remove(fragmentsLeft[0]);

        for (int i = 0; i < fragmentsLeft.Count; i++)
        {
            StartCoroutine(IEnumerators.SmoothLerp(fragmentsLeft[i].gameObject,
                new Vector3( fragmentsLeft[i].gameObject.transform.localPosition.x, ((fragmentHeight * i + fragmentHeight) * -1), 0),
                0.2f));
            
        }
    }

    private void AddFragmentToRightSide()
    {
        if (fragmentsRight.Count > 5)
        {
            Destroy(fragmentsRight[fragmentsRight.Count - 1]);
            fragmentsRight.Remove(fragmentsRight[fragmentsRight.Count - 1]);
        }

        GameObject fragment = Instantiate(fragmentPref, rightColorsStartPoint.position + new Vector3(0,0,0), new Quaternion(0,0,0,0), rightColorsStartPoint.transform);
        fragment.GetComponent<SpriteRenderer>().color = headColor.color;
        fragmentsRight.Insert(0, fragment);

        for (int i = 0; i < fragmentsRight.Count; i++)
        {
            StartCoroutine(IEnumerators.SmoothLerp(fragmentsRight[i].gameObject, 
                new Vector3(0, fragmentHeight * (i + 1) , 0) *-1,
                0.2f));
            //fragmentsRight[i].transform.localPosition = new Vector3(0, (i * fragmentHeight) *-1, 0);
        }

    }

    public void NextColor()
    {
        CreateFragment();
        AddFragmentToRightSide();
        StartCoroutine(IEnumerators.ColorLerp(headColor, GetPlatformColor(), GetFragmentColor(0), fadeInTime)); //покрасить верхнюю поверхность
        DestroyFragment();
    }

    public bool RotateWhenRevercing = false;
    public void RevercePlatform()
    {
        if (fragmentsRight.Count != fragmentsLeft.Count) return;

        Debug.Log("Revercing platform...");

        for (int i = 0; i < fragmentsLeft.Count; i++)
        {
            var leftFragmentPosition = fragmentsLeft[i].transform.position;
            var leftFragmentRotation = fragmentsLeft[i].transform.rotation;
            fragmentsLeft[i].transform.SetPositionAndRotation(fragmentsRight[i].transform.position, fragmentsRight[i].transform.rotation);
            fragmentsRight[i].transform.SetPositionAndRotation(leftFragmentPosition, leftFragmentRotation);
        }

        var fragmentsTemp = fragmentsLeft;
        fragmentsLeft = fragmentsRight;
        fragmentsRight = fragmentsTemp;

        if (RotateWhenRevercing) transform.Rotate(new Vector3(0, 180, 0));
    }

    public Color GetFragmentColor(int index)
    {
        return fragmentsLeft[index].GetComponent<SpriteRenderer>().color;
    }

    public Color GetPlatformColor()
    {
        return headColor.color;
    }

    public Color GetDefaultColor()
    {
        return defaultColor;
    }
}
