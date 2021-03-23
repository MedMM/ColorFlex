using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] List<TabButton> tabButtons;
    [SerializeField] float tabAnimationTime = 1;

    private void Start()
    {
        OnTabSelected(tabButtons[0]);
        tabButtons[0].GetComponent<Button>().onClick.Invoke();
    }

    public void Subscribe(TabButton button)
    {
        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTabs();
        LeanTween.moveY(button.GetComponent<RectTransform>(), 0, tabAnimationTime);
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            LeanTween.moveY(button.GetComponent<RectTransform>(), -120, tabAnimationTime);
        }
    }
}
