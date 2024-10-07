using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Fps
{
    public class CManagerWeapon : MonoBehaviour //IDataPersistence
    {
        //}
        [SerializeField]
        private GameObject[] _allWeapon = new GameObject[4];
        [SerializeField] private List<GameObject> _allWeaponAssets;
        [SerializeField] private List<GameObject> weapons = new List<GameObject>();

        public List<CWeapon> armas = new List<CWeapon>();

        [SerializeField] private Vector3 vectorOffsetSpawnWeapon;
        [SerializeField] private Vector3 vectorOffsetRotationWeapon; 
        private GameObject CurrentWeapon;
        [SerializeField]private Transform _trasnformWeapon;
        private static CManagerWeapon Inst;
        public Transform SpawnCollection;
        //private CManagerPickUp ManagerPickUp;
   

    
        public List<GameObject> GetListWeapon()
        {
            return weapons;
        }
        public void Update()
        {
           for(int i = weapons.Count -1; i>= 0; i--)
          {
            if (weapons[i] == null)
                weapons.RemoveAt(i);
         }
            EquipWeapon();
       
        }
        
        public void AddWeapon(CWeapon nuevaWeapon)
        {
           if(weapons.Any(weapons => weapons.name == nuevaWeapon.name))
           {
                weapons.Add(nuevaWeapon.gameObject);
           }    
        }

        private void SelectedWeapon()
        {
            
        }
       
        private void EquipWeapon()
        {
           
        }

        // public GameObject Spawn(Vector3 post, GameObject _Weapon)
        // {
          
        // }
        //Probar
        }
}
