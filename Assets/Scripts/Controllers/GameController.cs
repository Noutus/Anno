using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BuildingController buildingController;
    private StateController stateController;

    private void Awake()
    {
        this.buildingController = this.GetComponent<BuildingController>();
        this.stateController = this.GetComponent<StateController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == Tags.BuildingCollider)
                {
                    var building = hit.transform.parent.gameObject.GetComponent<BuildingComponent>();
                    if (building != null)
                        building.Collect();

                    this.StartCoroutine(this.WaitForPlacement(hit.transform.parent));
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.StopAllCoroutines();

            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == Tags.Island)
                {
                    var islandComponent = hit.transform.GetComponent<IslandComponent>();
                    if (islandComponent != null)
                        this.buildingController.CurrentIsland = islandComponent;

                    this.stateController.Set(State.Island);
                }
                
                if (hit.transform.tag == Tags.Region)
                {
                    var regionComponent = hit.transform.GetComponent<RegionComponent>();
                    if (regionComponent != null)
                        this.buildingController.RegionId = regionComponent.Id;

                    this.stateController.Set(State.Region);
                }
            }
        }
    }

    private IEnumerator WaitForPlacement(Transform buildingObject)
    {
        yield return new WaitForSeconds(0.25f);

        var placement = buildingObject.gameObject.AddComponent<PlacementComponent>();
        if (placement != null)
            placement.BasePosition = buildingObject.position;
    }
}
