using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public bool GameState;
    public GameObject menuElement;
    private void Awake()
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameState = true;
        menuElement.SetActive(false);
    }

}
