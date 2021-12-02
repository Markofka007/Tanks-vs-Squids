using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSquidKingDeath : MonoBehaviour
{
    public GameObject squidKing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(squidKing == null)
        {
            SceneManager.LoadScene("Game Win");
        }
    }
}
