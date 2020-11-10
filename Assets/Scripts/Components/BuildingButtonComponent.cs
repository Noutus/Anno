using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingButtonComponent : MonoBehaviour, IPointerDownHandler
{
    public GameObject Prefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        var gameObject = GameObject.Instantiate(this.Prefab);
        gameObject.AddComponent<PlacementComponent>();
    }
}
