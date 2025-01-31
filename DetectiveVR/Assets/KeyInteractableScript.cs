using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

[RequireComponent(typeof(XRSimpleInteractable))]
public class KeyInteractable : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        StartCoroutine(DeactivateAfterFrame());
    }

    private IEnumerator DeactivateAfterFrame()
    {
        if (interactable.interactionManager != null)
        {
            interactable.interactionManager.CancelInteractableSelection(
                (IXRSelectInteractable)interactable
            );
        }

        GameManager.Instance.AddKey();
        yield return null;
        gameObject.SetActive(false);
    }
}