using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class RegionModel
{
    public List<BuildingModel> Buildings;
    public int Id;

    public RegionModel(int id)
    {
        this.Buildings = new List<BuildingModel>();
        this.Id = id;
    }

    public void Set(BuildingComponent buildingComponent)
    {
        var building = this.Buildings.Where(b => b.Id == buildingComponent.Id).FirstOrDefault();
        if (building == null)
        {
            var id = 1;
            var newestBuilding = this.Buildings.OrderByDescending(b => b.Id).FirstOrDefault();
            if (newestBuilding != null)
                id = newestBuilding.Id + 1;

            buildingComponent.Id = id;
            building = new BuildingModel(id, buildingComponent.transform.position, buildingComponent.DateTime.ToString());

            this.Buildings.Add(building);
        }

        else
        {
            building.Id = buildingComponent.Id;
            building.X = buildingComponent.transform.position.x;
            building.Y = buildingComponent.transform.position.y;
            building.Z = buildingComponent.transform.position.z;
            building.DateTime = buildingComponent.DateTime.ToString();
        }
    }

    public void Remove(GameObject buildingObject)
    {
        var buildingComponent = buildingObject.GetComponent<BuildingComponent>();

        var building = this.Buildings.Where(b => b.Id == buildingComponent.Id).FirstOrDefault();
        if (building == null)
            return;

        this.Buildings.Remove(building);
    }
}
