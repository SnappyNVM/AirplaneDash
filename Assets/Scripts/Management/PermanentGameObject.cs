using System.Collections.Generic;
using UnityEngine;

public class PermanentGameObject : MonoBehaviour
{
    // variant of singlton for don't destroy on load objects
    [SerializeField] private string ID;
    private static Dictionary<string, GameObject> _instances = new Dictionary<string, GameObject>();

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
