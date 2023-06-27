using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace CustomRuleTiles
{
    [CreateAssetMenu]
    public class FortySevenRuleTile : CustomRuleTile
    {
        [SerializeField]
        private Texture2D tileSet = null;

        private List<Sprite> sprites = new List<Sprite>();
        [ContextMenu("Create Rules")]
        public void CreateRules()
        {
            sprites = new List<Sprite>();
            if (tileSet == null)
            {
                Debug.LogWarning("No tileSet has been selected. Generating default rules without sprites.");

                m_TilingRules = CreateFortySevenRules();
            }
            {
                //Get sprites from tileset
                List<Object> spriteObjects = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(tileSet)).ToList().Where(obj => obj.GetType() == typeof(Sprite)).ToList();

                if (spriteObjects.Count < 47)
                {
                    Debug.LogWarning($"Tileset only has {spriteObjects.Count} sprites. Check that it's using the TilesetImportSettings.");

                    return;
                }
                else
                {
                    foreach (Object obj in spriteObjects)
                    {
                        sprites.Add(obj as Sprite);
                    }
                    sprites = sprites.OrderBy(sprite => int.Parse(Regex.Match(sprite.name, @"\d+$").Value)).ToList();
                    m_TilingRules = CreateFortySevenRules();
                }
            }


        }

        private List<TilingRule> CreateFortySevenRules()
        {
            List<TilingRule> rules = new List<TilingRule>
            {
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[0] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[1] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[2] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[3] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[4] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[5] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[6] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[7] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[8] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 2, 2, 2, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[9] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[10] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[11] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[12] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[13] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[14] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[15] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[16] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[17] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[18] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[19] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[20] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[21] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(-1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[22] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[23] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 1, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[24] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 2, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[25] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 2, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[26] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 2, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[27] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 2, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[28] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[29] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[30] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[31] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[32] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 1, 1, 1, 1, 2, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[33] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[34] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[35] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1, 1, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[36] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[37] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 2, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[38] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[39] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[40] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[41] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 2, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[42] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[43] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(0, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[44] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 1, 2, 1, 1, 1, 2, 1, 1 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[45] }
                },
                new TilingRule
                {
                    m_Neighbors = new List<int> { 2, 1, 1, 1, 1, 1, 1, 2 },
                    m_NeighborPositions = new List<Vector3Int> {
                        new Vector3Int(1, 1, 0),
                        new Vector3Int(0, 1, 0),
                        new Vector3Int(-1, 1, 0),
                        new Vector3Int(-1, 0, 0),
                        new Vector3Int(1, 0, 0),
                        new Vector3Int(1, -1, 0),
                        new Vector3Int(0, -1, 0),
                        new Vector3Int(-1, -1, 0)
                    },
                    m_Sprites = new Sprite[] { sprites[46] }
                },

            };
            return rules;
        }
    }
}