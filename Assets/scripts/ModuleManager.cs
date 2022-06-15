using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleManager : MonoBehaviour
{

    public GameObject ModuleOption1;
    public GameObject ModuleOption2;
    public GameObject ModuleOption3;

    public static bool IsModule1 = false;
    public static bool IsModule2 = false;
    public static bool IsModule3 = false;

    void Update()
    {
        ModuleOption1.GetComponent<Button>().onClick.AddListener(() =>
        {
            IsModule1 = true; 
            ModuleOption1.GetComponent<Button>().onClick.RemoveAllListeners();
        });
        ModuleOption2.GetComponent<Button>().onClick.AddListener(() => {
            IsModule2 = true;
            ModuleOption2.GetComponent<Button>().onClick.RemoveAllListeners();
        });
        ModuleOption3.GetComponent<Button>().onClick.AddListener(() => {
            IsModule3 = true;
            ModuleOption3.GetComponent<Button>().onClick.RemoveAllListeners();
        });

    }
}
