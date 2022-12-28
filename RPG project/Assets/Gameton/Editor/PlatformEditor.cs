using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Platform))]
[CanEditMultipleObjects]
public class PlatformEditor : Editor
{
    Platform platform;

    private void OnEnable()
    {
        // 연결된 스크립트를 가져온다
        platform= (Platform)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label("This is a Label in a Custom Editor");

        if (GUILayout.Button("콜라이더 사이즈 맞추기"))
        {
            BoxCollider2D boxCollider2D = platform.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = platform.GetComponent<SpriteRenderer>();
            if(boxCollider2D != null)
            {
                boxCollider2D.offset = spriteRenderer.localBounds.center;
                boxCollider2D.size = spriteRenderer.localBounds.size;
            }
        }
    }
}
