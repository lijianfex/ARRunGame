using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnManagerEditor : EditorWindow
{
    [MenuItem("Tools/To Spawn Pattern")]
    static void PatternSystem()
    {
        GameObject go = GameObject.Find("PatternManager");
        if (go != null)
        {
            PatternManager patternManager = go.GetComponent<PatternManager>();
            if (patternManager != null)
            {
                if (Selection.gameObjects.Length == 1)
                {
                    var items = Selection.gameObjects[0].transform.Find("Item");
                    if (items != null)
                    {
                        Pattern pattern = new Pattern();
                        foreach (var child in items)
                        {
                            Transform childTrans = child as Transform;
                            if (childTrans != null)
                            {
                                var perfab = PrefabUtility.GetPrefabParent(childTrans.gameObject);
                                if (perfab != null)
                                {
                                    PatterItem patterItem = new PatterItem
                                    {
                                        perfabName = perfab.name,
                                        pos = childTrans.localPosition
                                    };
                                    pattern.PatterItems.Add(patterItem);
                                }
                            }
                        }
                        patternManager.Patterns.Add(pattern);
                    }
                }
            }

        }
    }


}
