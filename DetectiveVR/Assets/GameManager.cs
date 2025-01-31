using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

        OnKeyCollected?.Invoke(_keysCollected);
    }

    public int GetKeysCollected()
    {
        return _keysCollected;
    }
}