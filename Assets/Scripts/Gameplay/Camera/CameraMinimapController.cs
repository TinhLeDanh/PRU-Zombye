using UnityEngine;

public class CameraMinimapController : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update mini camera" + "/" + GameObject.Find("MainCamera").transform.position.x);
        transform.position = new Vector3(GameObject.Find("MainCamera").transform.position.x, GameObject.Find("MainCamera").transform.position.y + 2f, 0);
    }
}