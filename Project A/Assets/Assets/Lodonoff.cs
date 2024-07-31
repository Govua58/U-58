using UnityEngine;
using UnityEditor;

// Provides "Tools/LOD Groups" menu methods to                             
// enable and disable all LOD Groups in the current                        
// active scene                                                            
public static class ToggleLODGroups
{
    private delegate void IterateCallback(GameObject go);

    private static GameObject[] RootGameObjects
    {
        get
        {
            return UnityEngine.SceneManagement
                              .SceneManager
                              .GetActiveScene()
                              .GetRootGameObjects();
        }
    }

    private static void Iterate(GameObject go, IterateCallback cb)
    {
        cb(go);

        for (int t = go.transform.childCount - 1; t >= 0; --t)
        {
            Transform transform = go.transform.GetChild(t);
            cb(transform.gameObject);
            Iterate(transform.gameObject, cb);
        }
    }

    private static void IterateAndToggleLODGroups(bool enabled)
    {
        foreach (GameObject root in RootGameObjects)
        {
            Iterate(root, (go) => {
                LODGroup lodGroup = go.GetComponent<LODGroup>();
                if (lodGroup != null)
                    lodGroup.enabled = enabled;
            });
        }
    }

    ///                                                                      

    [MenuItem("Tools/LOD Groups/Enable All")]
    public static void EnableAllLODGroups(MenuCommand menuCommand)
    {
        IterateAndToggleLODGroups(true);
    }

    [MenuItem("Tools/LOD Groups/Disable All")]
    public static void DisableAllLODGroups(MenuCommand menuCommand)
    {
        IterateAndToggleLODGroups(false);
    }
}