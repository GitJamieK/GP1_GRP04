using System.Linq;
using UnityEngine;

namespace jamie {
    /// <summary>
    /// Logic for collecting Acorns that then increases Player.AcornScore by 1
    /// </summary>
    public class Collectible : MonoBehaviour {
        Player p;
        public GameObject collectParticlePrefab;
        /// <summary>
        /// Handle collision from acorn collectible to player
        /// </summary>
        /// <param name="other"></param>
        void OnTriggerEnter(Collider other) {
            //Debug.Log("collision with Acorn from player");
            p = other.gameObject.GetComponent<Player>();

            if (p != null) {
                p.AcornScore++;
                Debug.Log("Player has collected an Acorn. Acorn score: " + p.AcornScore);

                Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);

                //add UI logic (3/20 acorns)
            }
        }
    }
}