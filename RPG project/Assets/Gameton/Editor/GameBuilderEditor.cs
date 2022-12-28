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
        // ������ �ν����͸� �׸���
        DrawDefaultInspector();

        GUILayout.Label("This is a Label in a Custom Editor");        

        if (GUILayout.Button("��ֹ� ����"))
        {
            Debug.Log("��ֹ� ����");
            // EditorGUIUtility.Load -> ������ �뵵�� Editor Default Resources ������ �ִ� ������ �ҷ��´�
            // ���忡�� ���Ե��� �ʴ´�, Ȯ���� ���� �ۼ������ ���� �۵� �Ѵ�
            // var go = EditorGUIUtility.Load("Platform.prefab") as GameObject;

            var go = gameBuilder.platformPF;
            Instantiate(go);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
