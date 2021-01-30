using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace minimap
{
    public class MapManager : MonoBehaviour
    {
        // PUBLIC/SERIALIZED MEMBERS **************************************************************
        [Header("Map dimensions")]
        [SerializeField] public float mapWidth;
        [SerializeField] public float mapHeight;
        public Vector3 playerIconPos;

        [Header("Map Public References")]
        public Transform playerTransform;
        public RectTransform mapTransform;
        public RectTransform playerIconTransform;

        // PRIVATE MEMBERS ************************************************************************
        SpriteRenderer spriteRenderer;

        void Awake()
        {
            setMapSize();
        }

        void setMapSize()
        {
            if (spriteRenderer == null)
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            mapWidth = spriteRenderer.bounds.size.x;
            mapHeight = spriteRenderer.bounds.size.y;
        }

        void Update()
        {
            setMapSize();
            playerIconPos = TranslateWorldToMapPosition(playerTransform.position);

            playerIconTransform.anchoredPosition = new Vector2(playerIconPos.x, playerIconPos.y);
            
        }

        Vector3 TranslateWorldToMapPosition(Vector3 position)
        {
            // STEP1: normalize world coords
            Vector3 max_w_pos = new Vector3(mapWidth / 2.0f, mapHeight / 2.0f, 0);
            Vector3 min_w_pos = new Vector3(-(mapWidth / 2.0f), -(mapHeight / 2.0f), 0);
            Vector3 n_pos = new Vector3();

            n_pos.x = Mathf.InverseLerp((float)min_w_pos.x, (float)max_w_pos.x, (float)position.x);
            n_pos.y = Mathf.InverseLerp((float)min_w_pos.y, (float)max_w_pos.y, (float)position.y);

            // STEP2: convert normalized coords to local map space
            Vector3 max_lm_pos = new Vector3( mapTransform.rect.width / 2, mapTransform.rect.width / 2, 0);
            Vector3 min_lm_pos = new Vector3(-(mapTransform.rect.width / 2), -(mapTransform.rect.width / 2), 0);
            Vector3 lm_pos = new Vector3();

            lm_pos.x = Mathf.Lerp(min_lm_pos.x, max_lm_pos.x, n_pos.x);
            lm_pos.y = Mathf.Lerp(min_lm_pos.y, max_lm_pos.y, n_pos.y);

            return lm_pos;
        }



    }
}


