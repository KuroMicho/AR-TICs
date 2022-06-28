using UnityEngine;
using Vuforia;

public class ModelGroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Finders;

    [SerializeField]
    private GameObject[] Models;

    [SerializeField]
    private GameObject Popup;

    public void SetActiveModel(int selected)
    {
        DisableGroundModels();
        Models[selected].SetActive(true);
        Finders[selected].SetActive(true);

        // In Each Finder inside onContentPlaced, this parameter is being disabled
        Finders[selected].GetComponent<AnchorInputListenerBehaviour>().enabled = true;
    }

    public void DisableGroundModels()
    {
        if (Popup.activeSelf)
        {
            Popup.SetActive(false);
        }

        foreach (var finder in Finders)
            finder.SetActive(false);

        foreach (var model in Models)
        {
            if (model.GetComponent<AnchorBehaviour>().isActiveAndEnabled)
            {
                model.GetComponent<AnchorBehaviour>().UnconfigureAnchor();

                // Reset Anims
                if (transform.GetChild(0).GetComponentInChildren<BarAnimBehaviour>())
                    transform.GetChild(0).GetComponentInChildren<BarAnimBehaviour>().BarClose();
                if (model.GetComponent<ModelAnimController>())
                    model.GetComponent<ModelAnimController>().StopAnim();
            }

            model.SetActive(false);
        }
    }
}
