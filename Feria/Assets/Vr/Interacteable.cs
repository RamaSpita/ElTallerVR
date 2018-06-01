using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interacteable : MonoBehaviour
{

    public virtual void OnInteractorEnter(Interactor interactor) { }
    public virtual void OnInteractorExit(Interactor interactor) { }

    public virtual void OnTriggerPressed(Interactor interactor) { }
    public virtual void OnTriggerReleased(Interactor interactor) { }

    public virtual void OnPadTouched(Interactor interactor) { }
    public virtual void OnPadUntouched(Interactor interactor) { }

    public virtual void OnPadClicked(Interactor interactor) { }
    public virtual void OnPadUnclicked(Interactor interactor) { }

    public virtual void OnGripped(Interactor interactor) { }
    public virtual void OnUngripped(Interactor interactor) { }

}
