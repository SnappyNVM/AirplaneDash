using System.Collections.Generic;
using UnityEngine;

public class PermanentGameObject : MonoBehaviour
{
    // variant of singlton for don't destroy on load objects
    private static Dictionary<int, GameObject> _instances = new Dictionary<int, GameObject>();
    [SerializeField] private int ID;

    private void Awake()
    {
        if (_instances.ContainsKey(ID))
        {
            var existing = _instances[ID];

            if (existing != null)
            {
                if (ReferenceEquals(gameObject, existing))
                    return;

                Destroy(gameObject);
                return;
            }
        }

        _instances[ID] = gameObject;
        DontDestroyOnLoad(gameObject);
    }
}
