using System.Collections.Generic;
using UnityEngine;

public class ScreenComponent : MonoBehaviour
{
    public List<State> States;

    protected virtual void Start()
    {
        StateController.OnChange += this.Changed;
    }

    private void OnDestroy()
    {
        StateController.OnChange -= this.Changed;
    }

    protected virtual void Changed(State oldState, State newState)
    {
        this.gameObject.SetActive(this.States.Contains(newState));
    }
}
