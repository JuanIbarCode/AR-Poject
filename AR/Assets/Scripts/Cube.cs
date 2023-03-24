using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f,speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (speed == 500f)
            speed = 5;
        else speed = 500f;
    }
}
