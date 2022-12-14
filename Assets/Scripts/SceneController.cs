using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject[] ListSceneLayout;

    // Start is called before the first frame update
    void Start()
    {
        ListSceneLayout = GameObject.FindGameObjectsWithTag("SceneLayout");
        //OpenScene
        OpenScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            OpenScene(0);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            OpenScene(1);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            OpenScene(2);
        }
    }
    private void OpenScene(int IndexScene)
    {
        foreach(var x in ListSceneLayout)
        {
            x.SetActive(false);
        }
       ListSceneLayout[IndexScene].SetActive(true);
       
    }
    public void Btn_KhoiDong()
    {
        OpenScene(1);
    }
    public void Btn_ChoseCenterObject()
    {
       OpenScene(2); 
    }
    public void Btn_Back()
    {
        OpenScene(1);
    }
}
