using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.Video;

public class CutsceneTrigger : MonoBehaviour
{
    [Header("Object Toggling")]
    public GameObject[] objectsToDisable;
    public GameObject[] objectsToEnable;

    [Header("Audio Settings")]
    public AudioSource soundToPlay;
    public AudioSource loopedSoundToStop;

    [Header("Cutscene Settings")]
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public float delayBeforeCutscene = 5f;
    public float cutsceneDuration = 10f;

    [Header("Video Settings")]
    public VideoPlayer cutsceneVideoPlayer;

    [Header("XR Settings")]
    public GameObject xrRig; 

    [Header("UI Settings")]
    public GameObject quitUI; 

    private XRSimpleInteractable interactable;
    private bool cutsceneActive;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(_ => TriggerSequence());
    }

    private void TriggerSequence()
    {
        interactable.enabled = false;

        foreach (GameObject obj in objectsToDisable) obj.SetActive(false);
        foreach (GameObject obj in objectsToEnable) obj.SetActive(true);

        if (soundToPlay != null) soundToPlay.Play();
        if (loopedSoundToStop != null) loopedSoundToStop.Stop();

        StartCoroutine(CutsceneSequence());
    }

    private IEnumerator CutsceneSequence()
    {
        yield return new WaitForSeconds(delayBeforeCutscene);

        mainCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);

        if (cutsceneVideoPlayer != null)
        {
            cutsceneVideoPlayer.Play();
            cutsceneDuration = (float)cutsceneVideoPlayer.length;
        }

        if (xrRig != null) xrRig.SetActive(false);

        yield return new WaitForSeconds(cutsceneDuration);

        if (quitUI != null) quitUI.SetActive(true);
    }

    void Update()
    {
        if (quitUI != null && quitUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}