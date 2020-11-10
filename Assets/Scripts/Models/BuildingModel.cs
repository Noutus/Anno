using System;
using UnityEngine;

[Serializable]
public class BuildingModel
{
    public string DateTime;
    public float X;
    public float Y;
    public float Z;
    public int Id;

    public BuildingModel(int id, Vector3 position, string dateTime)
    {
        this.Id = id;
        this.X = position.x;
        this.Y = position.y;
        this.Z = position.z;
        this.DateTime = dateTime;
    }
}
