using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    private bool switched = false;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn(){
        for(float ft = 0f; ft <= 1; ft += 0.1f){ 
            Color color = GetComponent<Renderer>().material.color;
            color.a = ft;
            GetComponent<Renderer>().material.color = color;
            yield return new WaitForSeconds(5.0f);
            if(!switched){
                StartCoroutine("FadeOut");
            }
        }
    }

    IEnumerator FadeOut(){
        switched = true;
        for(float ft = 1f; ft >= 0; ft -= 0.1f){
            Color color = GetComponent<Renderer>().material.color;
            color.a = ft;
            GetComponent<Renderer>().material.color = color;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void LoadGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
