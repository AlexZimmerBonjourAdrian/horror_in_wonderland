using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Systema de rol template
public class CMICILSPSystem : MonoBehaviour
{
    //Madness de 0 a 10
    //Lucky de 0 a 10
    //Perception de 0 a 10
    //Charisma de 0 a 10
    //Inteligence de 0 a 10
    //Intimidate de 0 a 10
    //Seduction de 0 a 10
    //[M,I,C,I,L,S,P]

      // Atributos del sistema
   // Mejora: Usar un enum para los atributos del sistema


    private static CMICILSPSystem _instance;
    public static CMICILSPSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CMICILSPSystem");
                _instance = obj.AddComponent<CMICILSPSystem>();
                DontDestroyOnLoad(obj); // Asegurar que persista entre escenas
            }
            return _instance;
        }
    }

     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public enum Stats
    {
        Madness,
        Intelligence,
        Charisma,
        Intimidate,
        Lucky,
        Seduction,
        Perception
    }

    // Mejora: Usar un diccionario para almacenar los atributos
    private Dictionary<Stats, int> stats = new Dictionary<Stats, int>()
    {
        { Stats.Madness, 0 },
        { Stats.Intelligence, 0 },
        { Stats.Charisma, 0 },
        { Stats.Intimidate, 0 },
        { Stats.Lucky, 0 },
        { Stats.Seduction, 0 },
        { Stats.Perception, 0 }
    };

    // Constructor para inicializar los atributos (opcional)
    public CMICILSPSystem(int m = 0, int i = 0, int c = 0, int it = 0, int l = 0, int s = 0, int p = 0)
    {
        SetStat(Stats.Madness, m);
        SetStat(Stats.Intelligence, i);
        SetStat(Stats.Charisma, c);
        SetStat(Stats.Intimidate, it);
        SetStat(Stats.Lucky, l);
        SetStat(Stats.Seduction, s);
        SetStat(Stats.Perception, p);
    }

    // Método genérico para obtener el valor de un atributo
    public int GetStat(Stats stat)
    {
        return stats[stat];
    }

    // Método genérico para establecer el valor de un atributo
    public void SetStat(Stats stat, int value)
    {
        stats[stat] = Mathf.Clamp(value, 0, 10);
    }

    // Método genérico para aumentar el valor de un atributo
    public void IncreaseStat(Stats stat, int amount)
    {
        SetStat(stat, stats[stat] + amount);
    }

    // Método genérico para disminuir el valor de un atributo
    public void DecreaseStat(Stats stat, int amount)
    {
        SetStat(stat, stats[stat] - amount);
    }

    

  public class StatTemplate
    {
        public string Name;
        public Dictionary<Stats, int> BaseStats;

        public StatTemplate(string name, Dictionary<Stats, int> baseStats)
        {
            Name = name;
            BaseStats = baseStats;
        }
    }


//Neutral
//preset predeterminada - Juno


//Good
//Detective professional 
//ninia mimada - prioriza la suerte
//Heroina de capa blanca 
//lengua de plata

//Bad
//Femfatal
//Monstruo Sin Croazon
//Loca Perturbada
//Hija de politico

        public StatTemplate Detective = new StatTemplate("Detective", new Dictionary<Stats, int>() {
        { Stats.Madness, 2 },
        { Stats.Intelligence, 8 },
        { Stats.Charisma, 5 },
        { Stats.Intimidate, 7 },
        { Stats.Lucky, 4 },
        { Stats.Seduction, 3 },
        { Stats.Perception, 9 }
    });

    public StatTemplate MonstruoConRostroDeAngel = new StatTemplate("Monstruo con rostro de ángel", new Dictionary<Stats, int>() {
        { Stats.Madness, 9 },
        { Stats.Intelligence, 3 },
        { Stats.Charisma, 4 },
        { Stats.Intimidate, 8 },
        { Stats.Lucky, 2 },
        { Stats.Seduction, 7 },
        { Stats.Perception, 8 }
    });

    public void ApplyTemplate(StatTemplate template)
    {
        foreach (var stat in template.BaseStats)
        {
            SetStat(stat.Key, stat.Value);
        }
    }

}



