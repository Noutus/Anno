using UnityEngine;

public class ScreenComponent : MonoBehaviour
{
    public State State;

    private void Start()
    {
        StateController.OnChange += this.Changed;
    }

    private void OnDestroy()
    {
        StateController.OnChange -= this.Changed;
    }

    private void Changed(State oldState, State newState)
    {
        this.gameObject.SetActive(newState == this.State);
    }
}
