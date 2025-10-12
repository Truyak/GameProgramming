using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput,verticalInput,0) * Time.deltaTime * speed);
    }

    
}
