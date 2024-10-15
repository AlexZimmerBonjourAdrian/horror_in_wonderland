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
        
   public void EquipWeapon()
    {
        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        if (scrollDirection != 0f && weapons.Count > 0) // Only proceed if scrolling and there are weapons
        {
            // Find the index of the currently active weapon
            int currentWeaponIndex = -1;
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].activeSelf)
                {
                    currentWeaponIndex = i;
                    break;
                }
            }

            // Deactivate the current weapon
            if (currentWeaponIndex != -1)
            {
                weapons[currentWeaponIndex].SetActive(false);
            }

            // Calculate the new weapon index based on scroll direction
            if (scrollDirection > 0f)
            {
                currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count; // Cycle forward
            }
            else
            {
                currentWeaponIndex--;
                if (currentWeaponIndex < 0)
                {
                    currentWeaponIndex = weapons.Count - 1; // Cycle backward
                }
            }

            // Activate the new weapon
            weapons[currentWeaponIndex].SetActive(true);
        }
    }
}
}

