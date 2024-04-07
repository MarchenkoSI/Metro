using UnityEditor;
using UnityEngine;

public class ScaleBetweenToObjects : MonoBehaviour
{
    public GameObject startObject;
    public GameObject endObject;
    public float width;

    private Vector2 initialScale;

    public void UpdateScale()
    {
        float distance = (Vector3.Distance(startObject.transform.position, endObject.transform.position) / 10) * 2;

        transform.localScale = new Vector3(initialScale.x, distance / 2, 1);

        Vector3 middle_point = (startObject.transform.position + endObject.transform.position) / 2f;
        transform.position = middle_point;

        Vector3 rotaton_direction = (endObject.transform.position - startObject.transform.position);
        transform.up = rotaton_direction;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ScaleBetweenToObjects))]
    public class ScaleBetweenToObjectsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ScaleBetweenToObjects myScript = (ScaleBetweenToObjects)target;
            if (GUILayout.Button("Update"))
            {
                myScript.UpdateScale();
            }
        }
    }
#endif
}
