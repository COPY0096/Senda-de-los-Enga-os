using UnityEngine;
using UnityEngine.UI;

public class FlechaSeleccion : MonoBehaviour
{
    [SerializeField] private RectTransform [] opciones;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform rect;
    private int currentPosition;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            Interact();
        }
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;
        if(_change != 0){
            SoundManager.instance.PlaySound(changeSound);
        }
        if (currentPosition < 0)
        {
            currentPosition = opciones.Length - 1;
        }
        else if (currentPosition > opciones.Length - 1)
        {
            currentPosition = 0;
        }

        rect.position = new Vector3(rect.position.x, opciones[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        opciones[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
