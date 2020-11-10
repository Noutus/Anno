using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingColliderComponent : MonoBehaviour
{
    public bool Blocked => this.blockers.Where(b => b != null).Any();

    private HashSet<Transform> blockers;

    private void Awake()
    {
        this.blockers = new HashSet<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == Tags.BuildingCollider || collision.transform.tag == Tags.WallCollider)
            if (!this.blockers.Contains(collision.transform))
                this.blockers.Add(collision.transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == Tags.BuildingCollider || collision.transform.tag == Tags.WallCollider)
            if (this.blockers.Contains(collision.transform))
                this.blockers.Remove(collision.transform);
    }
}
