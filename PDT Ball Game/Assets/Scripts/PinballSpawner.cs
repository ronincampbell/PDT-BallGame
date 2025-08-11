using UnityEngine;

public class PinballSpawner : MonoBehaviour
{
    [SerializeField] GameObject pinballObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(pinballObj, transform.position, Quaternion.identity);
        }
    }
}
