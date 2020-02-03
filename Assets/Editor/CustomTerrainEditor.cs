using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EditorGUITable;

[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]

public class CustomTerrainEditor : Editor
{
    //propeties -------------------------
    SerializedProperty randomHeightRange;

    //fold outs ------------
    bool showRandom = false;

    private void OnEnable()
    {
        // "randomHeightRange" from CustomTerrain class
        randomHeightRange = serializedObject.FindProperty("randomHeightRange"); 
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CustomTerrain terrain = (CustomTerrain)target;

        //FOLDOUT
        showRandom = EditorGUILayout.Foldout(showRandom, "Random"); // triangle foldout image
        if (showRandom)
        {
            // this code opens the folder (foldout)
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            GUILayout.Label("Set Heights Between Random Values", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(randomHeightRange);
            if (GUILayout.Button("Random Heights"))
            {
                terrain.RandomTerrain();
            }
        }
        //END FOLDOUT

        // flatten the terrain out (starting values/level)
        if (GUILayout.Button("Reset Terrain"))
        {
            terrain.ResetTerrain();
        }

        serializedObject.ApplyModifiedProperties();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
