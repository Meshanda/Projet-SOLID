using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    [SerializeField] private List<OrdonedMonoBehaviour> _awakeComponents;
    [SerializeField] private List<OrdonedMonoBehaviour> _updateComponents;

    void Awake()
    {
        for (int i = 0; i < _awakeComponents.Count; i++)
        {
            _awakeComponents[i].DoAwake();
        }
    }
    void Update()
    {
        for (int i = 0; i < _updateComponents.Count; i++)
        {
            _updateComponents[i].DoUpdate();
        }
    }
}