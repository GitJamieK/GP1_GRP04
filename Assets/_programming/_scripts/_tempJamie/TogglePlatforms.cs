using UnityEngine;
using System.Collections.Generic;

namespace jamie {
    /// <summary>
    /// Toggle with A button to make platforms setActive True or False
    /// <summary>
    public class TogglePlatforms : MonoBehaviour {
        public List<GameObject> platforms = new List<GameObject>();
        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                Toggle();
            }
        }

        public void Toggle() {
            if (platforms != null && platforms.Count > 0) {
                foreach (GameObject platform in platforms) {
                    if (platform != null) { 
                        platform.SetActive(!platform.activeSelf);
                        Debug.Log("Platform is now " + (platform.activeSelf ? "Active" : "Inactive"));
                    }
                }
            }
            else {
                Debug.Log("Platform GameObject is not assigned in the inspector.");
            }
        }
    }
}