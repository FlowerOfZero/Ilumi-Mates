using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfter : MonoBehaviour
{
    public string scene;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitLoad()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
