using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TabGroup tabGroup;
    [SerializeField] UnityEvent OnTabSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
        OnTabSelected.Invoke();
    }

    void Start()
    {
        tabGroup.Subscribe(this);
    }
}
