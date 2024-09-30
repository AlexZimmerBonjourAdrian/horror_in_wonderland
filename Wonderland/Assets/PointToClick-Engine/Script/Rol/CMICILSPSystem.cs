using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Systema de rol template
public class CMICILSPSystem : MonoBehaviour
{
    //SINGLETON
    private static CMICILSPSystem _instance;
    public static CMICILSPSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CMICILSPSystem");
                _instance = obj.AddComponent<CMICILSPSystem>();
                DontDestroyOnLoad(obj); 
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
        Sanity,
        Charm,
        Wits,
        Composure,
        Empathy
    }

    private Dictionary<Stats, int> stats = new Dictionary<Stats, int>()
    {
        { Stats.Sanity, 5 },
        { Stats.Charm, 5 },
        { Stats.Wits, 5 },
        { Stats.Composure, 5 },
        { Stats.Empathy, 5 }
    };

    // Constructor para inicializar los atributos (opcional)
    public void InitializeStats(int sa = 5, int ch = 5, int wi = 5, int wil = 5, int em = 5)
    {
        SetStat(Stats.Sanity, sa);
        SetStat(Stats.Charm, ch);
        SetStat(Stats.Wits, wi);
        SetStat(Stats.Composure, wil);
        SetStat(Stats.Empathy, em);
    }

    public int GetStat(Stats stat)
    {
        return stats[stat];
    }

    public void SetStat(Stats stat, int value)
    {
        stats[stat] = Mathf.Clamp(value, 1, 10);
    }

    public void IncreaseStat(Stats stat, int amount)
    {
        SetStat(stat, stats[stat] + amount);
    }

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

    // Plantillas de atributos
    public StatTemplate Detective = new StatTemplate("Detective", new Dictionary<Stats, int>() {
        { Stats.Sanity, 7 },
        { Stats.Charm, 5 },
        { Stats.Wits, 8 },
        { Stats.Composure, 6 },
        { Stats.Empathy, 4 }
    });

    public StatTemplate NinaMimada = new StatTemplate("Niña Mimada", new Dictionary<Stats, int>() {
        { Stats.Sanity, 6 },
        { Stats.Charm, 7 },
        { Stats.Wits, 4 },
        { Stats.Composure, 4 },
        { Stats.Empathy, 6 }
    });

    public StatTemplate HeroinaDeCapaBlanca = new StatTemplate("Heroína de Capa Blanca", new Dictionary<Stats, int>() {
        { Stats.Sanity, 8 },
        { Stats.Charm, 8 },
        { Stats.Wits, 6 },
        { Stats.Composure, 7 },
        { Stats.Empathy, 8 }
    });

    public StatTemplate LenguaDePlata = new StatTemplate("Lengua de Plata", new Dictionary<Stats, int>() {
        { Stats.Sanity, 6 },
        { Stats.Charm, 9 },
        { Stats.Wits, 7 },
        { Stats.Composure, 5 },
        { Stats.Empathy, 6 }
    });

    public StatTemplate FemmeFatale = new StatTemplate("Femme Fatale", new Dictionary<Stats, int>() {
        { Stats.Sanity, 6 },
        { Stats.Charm, 9 },
        { Stats.Wits, 7 },
        { Stats.Composure, 6 },
        { Stats.Empathy, 5 }
    });

    public StatTemplate MonstruoSinCorazon = new StatTemplate("Monstruo Sin Corazón", new Dictionary<Stats, int>() {
        { Stats.Sanity, 2 },
        { Stats.Charm, 3 },
        { Stats.Wits, 6 },
        { Stats.Composure, 8 },
        { Stats.Empathy, 2 }
    });

    public StatTemplate LocaPerturbada = new StatTemplate("Loca Perturbada", new Dictionary<Stats, int>() {
        { Stats.Sanity, 1 },
        { Stats.Charm, 4 },
        { Stats.Wits, 7 },
        { Stats.Composure, 3 },
        { Stats.Empathy, 3 }
    });

    public StatTemplate HijaDePolitico = new StatTemplate("Hija de Político", new Dictionary<Stats, int>() {
        { Stats.Sanity, 7 },
        { Stats.Charm, 8 },
        { Stats.Wits, 6 },
        { Stats.Composure, 7 },
        { Stats.Empathy, 4 }
    });

    public void ApplyTemplate(StatTemplate template)
    {
        foreach (var stat in template.BaseStats)
        {
            SetStat(stat.Key, stat.Value);
        }
    }
}


