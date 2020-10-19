using System.Collections;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public delegate void StateEvent(State oldState, State newState);
    public static event StateEvent OnChange;

    private State current;

    private void Start()
    {
        this.StartCoroutine(this.DelayedSet(State.World));
    }

    public void Set(State state)
    {
        this.StartCoroutine(this.DelayedSet(state));
    }

    private IEnumerator DelayedSet(State state)
    {
        yield return null;

        var oldState = this.current;
        this.current = state;

        OnChange?.Invoke(oldState, this.current);
    }
}
