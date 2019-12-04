using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
	private int currentLvlIndex;
    // Start is called before the first frame update
    void Start()
    {
		currentLvlIndex = SceneManager.GetActiveScene().buildIndex; 
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
		SceneManager.LoadScene(currentLvlIndex);
    }
}
