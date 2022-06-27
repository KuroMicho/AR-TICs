using UnityEngine;

public class ModelGroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Finders;

    [SerializeField]
    private GameObject[] Models;

    public void SetActiveModel(int selected)
    {
        DisableGroundModels();
        Models[selected].SetActive(true);
        Finders[selected].SetActive(true);
    }

    public void DisableGroundModels()
    {
        foreach (var finder in Finders)
            finder.SetActive(false);

        foreach (var model in Models)
            model.SetActive(false);
    }
}
