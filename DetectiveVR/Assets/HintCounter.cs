using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HintCounter : MonoBehaviour
{
    public static HintCounter Instance { get; private set; }

    [System.Serializable]
    public class HintUI
    {
        public GameObject panel;
        public Text hintText;
        public float displayDuration = 5f;
    }

    [Header("UI Settings")]
    [SerializeField] private HintUI[] hintPopups = new HintUI[3];
    [SerializeField] private AudioClip hintSound;

    [Header("Hint Messages")]
    [TextArea][SerializeField] private string hint1Text = "There is still scent of food, someone must've been in the kitchen!";
    [TextArea][SerializeField] private string hint2Text = "Being stuck in a forest alone is tiring, I am really thirsty!";
    [TextArea][SerializeField] private string hint3Text = "Where can I find some water around here? I have a vague memory from childhood of a well outside!";

    private int _hintsCollected = 0;
    private AudioSource audioSource;
    private XRBaseInteractor currentInteractor;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            InitializeUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeUI()
    {
        foreach (var hintUI in hintPopups)
        {
            if (hintUI.panel != null)
                hintUI.panel.SetActive(false);
        }
    }

    public void CollectHint(XRBaseInteractor interactor)
    {
        currentInteractor = interactor;
        AddHint();
    }

    public void AddHint()
    {
        _hintsCollected++;
        StartCoroutine(ShowHintPopup());

        if (hintSound) audioSource.PlayOneShot(hintSound);

        switch (_hintsCollected)
        {
            case 1:
                ConfigureHintText(0, hint1Text);
                break;
            case 2:
                ConfigureHintText(1, hint2Text);
                break;
            case 3:
                ConfigureHintText(2, hint3Text);
                break;
        }
    }

    private IEnumerator ShowHintPopup()
    {
        if (_hintsCollected > 0 && _hintsCollected <= hintPopups.Length)
        {
            int hintIndex = _hintsCollected - 1;
            var currentHintUI = hintPopups[hintIndex];

            if (currentInteractor != null)
                currentInteractor.allowSelect = false;

            currentHintUI.panel.SetActive(true);

            yield return new WaitForSeconds(currentHintUI.displayDuration);

            currentHintUI.panel.SetActive(false);

            if (currentInteractor != null)
                currentInteractor.allowSelect = true;
        }
    }

    public void ConfigureHintText(int hintIndex, string hintMessage)
    {
        if (hintIndex >= 0 && hintIndex < hintPopups.Length)
        {
            hintPopups[hintIndex].hintText.text = hintMessage;
        }
    }
}
