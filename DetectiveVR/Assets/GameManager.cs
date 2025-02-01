using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject door1;
    public GameObject door2;
    public AudioSource knockSound;
    public AudioSource doorSound;

    public UnityEvent<int> OnKeyCollected;

    private int _keysCollected = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKey()
    {
        _keysCollected++;
        Debug.Log($"Keys collected: {_keysCollected}");

        if (_keysCollected == 1)
        {
            if (knockSound != null && knockSound.clip != null) knockSound.Play();
        }

        if (_keysCollected == 2)
        {
            if (door1 != null) door1.SetActive(false);
            if (door2 != null) door2.SetActive(false);
            if (doorSound != null && doorSound.clip != null) doorSound.Play();
        }

        OnKeyCollected?.Invoke(_keysCollected);
    }

    public int GetKeysCollected()
    {
        return _keysCollected;
    }
}