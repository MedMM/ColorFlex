using System.Collections.Generic;
using DG.Tweening;
using Misc;
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
	[SerializeField] private float fadeInTime = 2; // Время за которе красится head

	private void Start()
	{
		headColor.color = defaultColor;
		GameManager.instance.SetDefaultColor(defaultColor);

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
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			CreateFragment();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			DestroyFragment();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			RevercePlatform();
		}

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
		var fragment = Instantiate(fragmentPref, leftColorsStartPoint.position, gameObject.transform.rotation,
			leftColorsStartPoint.transform);
		fragment.GetComponent<SpriteRenderer>().color = color;
		fragment.transform.localPosition += new Vector3(0, ((fragmentsLeft.Count * fragmentHeight) * -1), 0);
		fragmentsLeft.Add(fragment);
	}

	private void DestroyFragment()
	{
		Vector2 fragmentPosition = new Vector2(0, 0);
		StartCoroutine(Enumerators.SmoothLerpAndDestroy(fragmentsLeft[0].gameObject, fragmentPosition, 0.2f));

		fragmentsLeft.Remove(fragmentsLeft[0]);

		for (int i = 0; i < fragmentsLeft.Count; i++)
		{
			StartCoroutine(Enumerators.SmoothLerp(fragmentsLeft[i].gameObject,
				new Vector3(fragmentsLeft[i].gameObject.transform.localPosition.x,
					((fragmentHeight * i + fragmentHeight) * -1), 0),
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

		GameObject fragment = Instantiate(fragmentPref, rightColorsStartPoint.position + new Vector3(0, 0, 0),
			new Quaternion(0, 0, 0, 0), rightColorsStartPoint.transform);
		fragment.GetComponent<SpriteRenderer>().color = headColor.color;
		fragmentsRight.Insert(0, fragment);

		for (int i = 0; i < fragmentsRight.Count; i++)
		{
			StartCoroutine(Enumerators.SmoothLerp(fragmentsRight[i].gameObject,
				new Vector3(0, fragmentHeight * (i + 1), 0) * -1,
				0.2f));
		}
	}

	public void NextColor()
	{
		CreateFragment();
		AddFragmentToRightSide();
		headColor.DOColor(GetFragmentColor(0), fadeInTime);
		DestroyFragment();
	}
	// StartCoroutine(Enumerators.ColorLerp(headColor, GetPlatformColor(), GetFragmentColor(0),
	// 	fadeInTime));

	private void RevercePlatform()
	{
		if (fragmentsRight.Count != fragmentsLeft.Count) return;

		Debug.Log("Revercing platform...");

		for (int i = 0; i < fragmentsLeft.Count; i++)
		{
			var leftFragmentPosition = fragmentsLeft[i].transform.position;
			var leftFragmentRotation = fragmentsLeft[i].transform.rotation;
			fragmentsLeft[i].transform.SetPositionAndRotation(fragmentsRight[i].transform.position,
				fragmentsRight[i].transform.rotation);
			fragmentsRight[i].transform.SetPositionAndRotation(leftFragmentPosition, leftFragmentRotation);
		}

		var fragmentsTemp = fragmentsLeft;
		fragmentsLeft = fragmentsRight;
		fragmentsRight = fragmentsTemp;
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