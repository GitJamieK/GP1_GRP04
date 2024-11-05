using System;
using System.Linq;
using UnityEngine;

namespace jamie {
    /// <summary>
    /// Logic for collecting Acorns that then increases Player.AcornScore by 1
    /// </summary>
    public class Collectible : MonoBehaviour {
        Player p;
        public GameObject collectParticlePrefab;

        private float bounceSpeed = 2f;
        private float bounceHeight = 0.15f;
        private float rotationSpeed = 30f;
        
        private Vector3 startPos;

        private void Start() {
            startPos = transform.position;
        }

        private void Update() {
            float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
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