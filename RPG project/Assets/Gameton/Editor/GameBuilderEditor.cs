using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameBuilder))]
[CanEditMultipleObjects]
public class GameBuilderEditor : Editor
{
    GameBuilder gameBuilder;
    

    private void OnEnable()
    {
        gameBuilder = (GameBuilder)target;
    }

    public override void OnInspectorGUI()
    {
        // 기존의 인스펙터를 그린다
        DrawDefaultInspector();

        GUILayout.Label("This is a Label in a Custom Editor");        

        if (GUILayout.Button("장애물 생성"))
        {
            Debug.Log("장애물 생성");
            // EditorGUIUtility.Load -> 에디터 용도로 Editor Default Resources 폴더에 있는 에셋을 불러온다
            // 빌드에는 포함되지 않는다, 확장자 까지 작성해줘야 정상 작동 한다
            // var go = EditorGUIUtility.Load("Platform.prefab") as GameObject;

            var go = gameBuilder.platformPF;
            Instantiate(go);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
