using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] public int pointPerBlock = 34;
    [SerializeField] public TextMeshProUGUI scopeText;
    
    private int scope = 0;
    
    void Awake()
    {
        int count = FindObjectsOfType<GameSession>().Length;
        if (count > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scopeText.text = scope.ToString();
    }

    public void UpdateScope()
    {
        scope += pointPerBlock;
    }

    public void ResetSession()
    {
        Destroy(gameObject);
    }
}
