using System;
using UnityEngine;

public class RegionScreenComponent : ScreenComponent
{
    public GameObject BuildingPrefab;

    private BuildingController buildingController;

    protected override void Start()
    {
        base.Start();

        this.buildingController = GameObject.FindObjectOfType<BuildingController>();
    }

    protected override void Changed(State oldState, State newState)
    {
        base.Changed(oldState, newState);

        if (newState == State.Region)
        {
            var buildings = this.buildingController.Get();
            foreach (var building in buildings)
            {
                var gameObject = GameObject.Instantiate(this.BuildingPrefab, new Vector3(building.X, building.Y, building.Z), Quaternion.identity);
                var buildingComponent = gameObject.GetComponent<BuildingComponent>();

                buildingComponent.Id = building.Id;
                buildingComponent.DateTime = DateTime.Parse(building.DateTime);
            }
        }
    }
}
