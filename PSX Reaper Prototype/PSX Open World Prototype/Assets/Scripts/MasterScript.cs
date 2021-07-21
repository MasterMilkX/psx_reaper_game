using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{

	public int curCam = 0;
	public List<GameObject> cams;
	public GameObject player;

	//controls
    Control_Map cmap;

    //input controls
    void Awake(){
        cmap = new Control_Map();

        //debugs
        cmap.PSX_Controller.DEBUG.started += ctx => {curCam = (curCam +1 == cams.Count ? 0 : curCam+1);ToggleCams();};
    }
    void OnEnable(){
        cmap.PSX_Controller.Enable();
    }
    void OnDisable(){
        cmap.PSX_Controller.Disable();
    }

    // Start is called before the first frame update
    void Start(){
        ToggleCams();
    }

    // Update is called once per frame
    void Update(){
        
    }


    private void ToggleCams(){
    	Debug.Log(cams[curCam].name);
    	foreach(GameObject c in cams){
    		c.SetActive(false);
    	}
    	cams[curCam].SetActive(true);
    }
}
