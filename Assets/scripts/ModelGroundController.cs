using UnityEngine;

public class ModelGroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject LaptopFinder;

    [SerializeField]
    private GameObject DroneFinder;

    [SerializeField]
    private GameObject Laptop;

    [SerializeField]
    private GameObject Drone;

    public void SetActiveLaptop()
    {
        LaptopFinder.SetActive(true);
        Laptop.SetActive(true);
        DroneFinder.SetActive(false);
        Drone.SetActive(false);
    }

    public void SetActiveDrone()
    {
        DroneFinder.SetActive(true);
        Drone.SetActive(true);
        LaptopFinder.SetActive(false);
        Laptop.SetActive(false);
    }

    public void DisableGroundModels()
    {
        DroneFinder.SetActive(false);
        Drone.SetActive(false);
        LaptopFinder.SetActive(false);
        Laptop.SetActive(false);
    }
}
