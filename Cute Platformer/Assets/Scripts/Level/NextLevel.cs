using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextLevel;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Level(int level)
    {
        SceneManager.LoadScene(level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Level(nextLevel);
    }
}
