using UnityEngine;
using UnityEditor;

public class WindowsEditorBullet : EditorWindow
{
    // Start is called before the first frame update

  public  enum prueba {hola, como, estas};

public enum WeapondSelect {Pistol,shootGun,Sniper,RocketLauncher,carabine,smg,AsaultRifle,heavymachinegun};
    public prueba prub;
    public WeapondSelect selectwep;

    private GameObject Prefabcharacter;
    float damage = 0f;
    float chancheCritical=0f;
    float dispersion = 0f;
    bool isreload = false;
    bool SecondShoot= false;

        [MenuItem("window/example")]

    static void init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(WindowsEditorBullet));
        window.Show();
    }
    /*
    public static void showwindow()
        {
          EditorWindow.GetWindow<WindowsEditorBullet>("Example");
        
        }
    */


        void OnGUI()
        {

        //GUILayout.Label("This is a label", EditorStyles.boldLabel);
        selectwep = (WeapondSelect)EditorGUILayout.EnumPopup("Seleccione el tipo de arma", selectwep);
        
        switch(selectwep)
        {
            case WeapondSelect.Pistol:
          
                damage = EditorGUILayout.FloatField("Damage", damage);
                chancheCritical = EditorGUILayout.FloatField("Change Critical", chancheCritical);
                dispersion = EditorGUILayout.FloatField("dispersion", dispersion);
                isreload = EditorGUILayout.Toggle("Recargando", isreload);
                SecondShoot = EditorGUILayout.Toggle("Second Shoot", SecondShoot);
                break;

            case WeapondSelect.AsaultRifle:
                {
                   
                    damage = EditorGUILayout.FloatField("Damage", damage);
                    chancheCritical = EditorGUILayout.FloatField("Change Critical", chancheCritical);
                    dispersion = EditorGUILayout.FloatField("dispersion", dispersion);
                    isreload = EditorGUILayout.Toggle("Recargando", isreload);
                    SecondShoot = EditorGUILayout.Toggle("Second Shoot", SecondShoot);
                    break;
                }
             
            
        default:
            Debug.LogError("Unreconoized option");
            break;
        }

            if (GUILayout.Button("Select"))
        {
            
        }

        prub = (prueba)EditorGUILayout.EnumPopup("Probando los enums", prub);
        if (GUILayout.Button("Imprimir"))
            Debug.Log("Hola Mundo");
    
        }
      void pruebafunction(prueba prueb)
    {
        switch(prueb)
        {
            case prueba.hola:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Vector3.zero;
                break;
            case prueba.estas:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Vector3.zero;
                break;
            case prueba.como:
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.position = Vector3.zero;
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }

    }
    /*
    void SelectWeapond(WeapondSelect selectwe)
    {
        switch(selectwe)
        {

            case WeapondSelect.Pistol:
                
                
                

                
        }
    }
    */
   
        
}
