using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // public void CheckRespawn()
    // {

    //     if(currentCheckpoint == null)
    //     {

    //         uiManager.GameOver();

    //         return;
    //     }
    //     transform.position = currentCheckpoint.position;
    //     playerHealth.Respawn();

    //     Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    //     if (currentCheckpoint != null)
    //     {
    //         DeactivateCheckpoint();
    //     }
    // }
    public void CheckRespawn()
{
    if (currentCheckpoint == null)
    {
        uiManager.GameOver();
        return;
    }

    transform.position = currentCheckpoint.position;
    playerHealth.Respawn();

    Transform checkpointRoom = currentCheckpoint.parent;
    if (checkpointRoom != null)
    {
        Debug.Log("Moving camera to checkpoint room: " + checkpointRoom.name);
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(checkpointRoom);
    }
    else
    {
        Debug.LogWarning("Checkpoint room is null.");
    }

    DeactivateCheckpoint();
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
        private void DeactivateCheckpoint()
    {
        if (currentCheckpoint != null)
        {
            currentCheckpoint.gameObject.SetActive(false);
            currentCheckpoint = null; 
        }
    }

}
