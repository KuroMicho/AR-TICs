using UnityEngine;

public class SpinnerBehaviour : MonoBehaviour
{
    private float ZRotation = 0;

    private void FixedUpdate()
    {
        ZRotation += 90 * 1 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, ZRotation));
    }
}
