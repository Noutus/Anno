using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private StateController stateController;

    private void Awake()
    {
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
                    hit.transform.parent.gameObject.AddComponent<BuildingComponent>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == Tags.Island)
                    this.stateController.Set(State.Island);

                if (hit.transform.tag == Tags.Region)
                    this.stateController.Set(State.Region);
            }
        }
    }
}
