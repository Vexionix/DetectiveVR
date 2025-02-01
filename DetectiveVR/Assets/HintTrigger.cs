using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HintInteractable : XRSimpleInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (args.interactorObject is XRBaseInteractor baseInteractor)
        {
            HintCounter.Instance.CollectHint(baseInteractor);
            gameObject.SetActive(false);
        }
    }
}