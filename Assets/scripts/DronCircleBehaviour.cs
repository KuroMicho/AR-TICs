using UnityEngine;

public class DronCircleBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Circle;
    private float RotationZ;

    private void Start()
    {
        RotationZ = Circle.transform.localRotation.z;
    }

    private void Update()
    {
        RotationZ += 1 * Time.deltaTime;
        Circle.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, RotationZ * 360));
    }
}
