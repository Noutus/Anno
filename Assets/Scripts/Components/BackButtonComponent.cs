using UnityEngine;
using UnityEngine.UI;

public class BackButtonComponent : MonoBehaviour
{
    public State State;

    private StateController stateController;
    private Button button;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
    }

    private void Start()
    {
        this.button.onClick.AddListener(this.Click);
        this.stateController = GameObject.FindObjectOfType<StateController>();
    }

    private void Click()
    {
        foreach (var building in GameObject.FindGameObjectsWithTag(Tags.Building))
        {
            GameObject.Destroy(building);
        }

        this.stateController.Set(this.State);
    }
}
