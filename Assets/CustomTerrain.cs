﻿using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]

public class CustomTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CreateTags();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Add tags programatically
     */
    void CreateTags()
    {
        // Open tag manager
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset"));
        // Tags Property
        tagManager.Update(); // Get object current state into stream.
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        Debug.Log("tags " + tagsProp.arraySize);

        AddTheTag(tagsProp, "Terrain");
        AddTheTag(tagsProp, "Cloud");
        AddTheTag(tagsProp, "Shore");

        // apply tag changes to tag database
        tagManager.ApplyModifiedProperties();

        //take this project
        this.gameObject.tag = "Terrain";
    }

    private static void AddTheTag(SerializedProperty tagsProp, string newTag)
    {
        print("Adding tag " + newTag);
        tagsProp.InsertArrayElementAtIndex(0);
        SerializedProperty newTagProp = tagsProp.GetArrayElementAtIndex(0);
        newTagProp.stringValue = newTag;
    }
    public static void AddTag2(string tag)
    {
        SerializedObject serializedObject = new SerializedObject(
            AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("ProjectSettings/TagManager.asset")
        );
        serializedObject.Update(); // Get object current state into stream.

        SerializedProperty tags = serializedObject.FindProperty("tags");
        AddTheTag(tags, tag);
        serializedObject.ApplyModifiedProperties();
        Debug.Log("tags " + tags.arraySize);
        print("Index 0 is: " + tags.GetArrayElementAtIndex(0).stringValue);

        /*
                for (int i = 0; i < tags.arraySize; ++i)
                    if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                        return;

                tags.InsertArrayElementAtIndex(tags.arraySize);
                tags.GetArrayElementAtIndex(tags.arraySize - 1).stringValue = tag;

                serializedObject.ApplyModifiedProperties(); // Apply changes from stream to object.

            */
    }

    void AddTag(SerializedProperty tagsProp, string newTag)
    {
        print("ADDING TAG ATTEMPT : " + tagsProp.arraySize);
        bool found = false;
        //ensure the tag doesn't already exist
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            print("Looping through tags");
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(newTag))
            {
                print("Tag found " + newTag);
                found = true;
                break;
            }
            //add your tag
            if (!found)
            {
                AddTheTag(tagsProp, newTag);
            }
        }
    }
}