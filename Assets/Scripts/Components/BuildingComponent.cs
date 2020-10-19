using UnityEngine;

public class BuildingComponent : MonoBehaviour
{
    private const float TileSize = 0.32f;

    private void Update()
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = TileSize * Mathf.Round(position.x / TileSize);
        position.y = TileSize * Mathf.Round(position.y / TileSize);
        position.z = -0.2f;

        this.transform.position = position;
        
        var blocked = false;
        foreach (var collider in this.GetComponentsInChildren<BuildingColliderComponent>())
        {
            if (collider.Blocked)
            {
                blocked = true;
                break;
            }
        }
        
        if (!blocked && Input.GetMouseButtonUp(0))
        {
            position = this.transform.position;
            position.z = -0.1f;
            GameObject.Destroy(this);
        }
    }
}
