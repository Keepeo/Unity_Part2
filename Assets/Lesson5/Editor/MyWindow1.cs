using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
namespace Geekbrains.Editor
{
    public class MyWindow1 : EditorWindow
    {
        public GameObject ObjectInstantiate;
        string _nameObject = "Hello World";
        bool groupEnabled;
        bool _randomColor = true;
        int _countObject = 1;
        float _radius = 5;
        float _y=1;        
        float _angel2=110;        
        Color[] _colors = new Color[]
        {
            Color.green, Color.black, Color.blue, Color.clear, Color.cyan, Color.red, Color.yellow, Color.white, Color.red
        };
        [MenuItem("Lesson5/My Second Window")]
        public static void ShowWindow()
        {
            // Отобразить существующий экземпляр окна. Если его нет, создаем
            EditorWindow.GetWindow(typeof(MyWindow1));
        }
        void OnGUI()
        {
            // Здесь методы отрисовки схожи с методами в пользовательском интерфейсе, который вы разрабатывали на курсе “Unity3D. Уровень 1”
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate =
                EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true)
                    as GameObject;
            _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
            _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
            _countObject = EditorGUILayout.IntSlider("Количество объектов", _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 5, 50);
            _y = EditorGUILayout.Slider("Y", _y, -10, 10);
            _angel2 = EditorGUILayout.Slider("Угол второй спирали", _angel2, 0, 360);
            EditorGUILayout.EndToggleGroup();
            if (GUILayout.Button("Создать объекты"))
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < _countObject; i++) // Расставляем выбранный объект по окружности
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), _y*i/10, Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        if (temp.GetComponent<Renderer>() && _randomColor)
                        {
                            temp.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length - 1)];
                            // Unity предупреждает о возможной утечке памяти и предлагает использовать sharedMaterial
                        }
                    }

                    GameObject root1 = new GameObject("Root1");
                    for (int i = 0; i < _countObject; i++) // Расставляем выбранный объект по окружности
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle+ _angel2), _y * i / 10, Mathf.Sin(angle+ _angel2)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root1.transform;
                        if (temp.GetComponent<Renderer>() && _randomColor)
                        {
                            temp.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length - 1)];
                            // Unity предупреждает о возможной утечке памяти и предлагает использовать sharedMaterial
                        }
                    }
                }
            }
        }
    }
}
