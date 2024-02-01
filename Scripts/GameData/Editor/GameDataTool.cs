using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameDataTool : EditorWindow
{
    

    [MenuItem("GameTools/GameDataTool")]
    static void Init()
    {
        EditorWindow editorWindow = GetWindow(typeof(GameDataTool));
        editorWindow.Show();
    }

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameDataTool));
    }

    string create_script_path { get { return string.Format("{0}/2_Scripts/GameData/GameDatas", Application.dataPath); } }
    string m_crate_Script_name;

    void OnGUI()
    {
        if( GUILayout.Button("Open GameData", GUILayout.Width(200) ))
        {
            Application.OpenURL(Application.persistentDataPath);
        }

        GUILayout.Label("Create Scripts FilePath : " + create_script_path);
        m_crate_Script_name = EditorGUILayout.TextField("class name : ", m_crate_Script_name, GUILayout.Width(500));
        if( string.IsNullOrWhiteSpace(m_crate_Script_name) == false &&  GUILayout.Button("Create", GUILayout.Width(100)))
        {
            CreateGameDataScript(m_crate_Script_name);
        }
    }

    void CreateGameDataScript(string _name )
    {
        string _classFilePath = string.Format("{0}/{1}.cs", create_script_path, _name);
        if (System.IO.File.Exists(_classFilePath) == true)
        {
            EditorUtility.DisplayDialog("error", "File Exist", "OK");
            return;
        }    

        System.Text.StringBuilder _sb = new System.Text.StringBuilder();

        _sb.Append("[System.Serializable]");
        _sb.Append("\n");
        _sb.AppendFormat("public class {0} : GameData \n", _name);
        _sb.Append("{\n");
        _sb.AppendFormat("\tstatic {0} m_instance;", _name);
        _sb.Append("\n");
        _sb.Append("\t");
        _sb.AppendFormat("public static {0} Instance ", _name);
        _sb.Append("{ get { if (m_instance == null) { m_instance = GameDataManager.Instance.GetGameData");
        _sb.AppendFormat("<{0}>(); ", _name);
        _sb.Append("} return m_instance; } }");
        _sb.Append("\n");
        _sb.Append("\tpublic override void Init()\n");
        _sb.Append("\t{\n");
        _sb.Append("\t\tbase.Init();");
        _sb.Append("\n\t}");
        _sb.Append("\n}");

        FileUtil.Save(_classFilePath, _sb.ToString() );
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("success", "script create success", "OK");
    }
}
