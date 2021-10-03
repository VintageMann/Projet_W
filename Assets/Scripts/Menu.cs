using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public Button btn;
	public string scenename;
    // Start is called before the first frame update
    void Start()
    {
    	btn.onClick.AddListener(LoadScene);
        
    }

	void LoadScene(){
		SceneManager.LoadScene(scenename);
	}
}
