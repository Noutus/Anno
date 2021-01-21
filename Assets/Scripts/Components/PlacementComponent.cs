using UnityEngine;

public class PlacementComponent : MonoBehaviour
{
    private const float TileSize = 0.96f;

    private BuildingController buildingController;

    public Vector3 BasePosition { private get; set; }

    private void Start()
    {
        this.buildingController = GameObject.FindObjectOfType<BuildingController>();
    }

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
        
        if (Input.GetMouseButtonUp(0))
        {
            if (blocked)
            {
                if (this.BasePosition != null && this.BasePosition != Vector3.zero)
                {
                    this.transform.position = this.BasePosition;
                    GameObject.Destroy(this);
                }
                else
                {
                    this.buildingController.Remove(this.gameObject);
                    GameObject.Destroy(this.gameObject);
                }
            }

            else
            {
                position = this.transform.position;
                position.z = -0.1f;

                this.buildingController.Set(this.GetComponent<BuildingComponent>());
                GameObject.Destroy(this);
            }
        }
    }
}
