using UnityEngine;

public class CameraMinimapController : MonoBehaviour
{
    private BasePlayerCharacterEntity player;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnSpawnPlayer(BasePlayerCharacterEntity newPlayer)
    {
        player = newPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update camera mini");
        if (player != null)
        {
            Debug.Log("update camera mini inside if");
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y,
                transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
    }
}