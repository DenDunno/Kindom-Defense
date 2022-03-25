using UnityEngine;
using System.Collections;
using DungeonArchitect;
using DungeonArchitect.Utils;

namespace EternalCrypt
{
    [System.Serializable]
    public class MaterialReplaceInfo
    {
        public Material sourceMat;
        public Material targetMat;
    }

    public class MaterialReplacer : DungeonEventListener
    {
        public MaterialReplaceInfo[] replacements;
        /// <summary>
        /// Called after the dungeon is completely built
        /// </summary>
        /// <param name="model">The dungeon model</param>
        public override void OnPostDungeonBuild(Dungeon dungeon, DungeonModel model)
        {
            var dataList = GameObject.FindObjectsOfType<DungeonSceneProviderData>();
            foreach (var data in dataList)
            {
                if (data == null) continue;
                var item = data.gameObject;
                if (item == null) continue;
                var renderers = item.GetComponentsInChildren<Renderer>();
                foreach (var renderer in renderers)
                {
                    var sourceMaterials = renderer.sharedMaterials;
                    var targetMaterials = new Material[sourceMaterials.Length];
                    for (int i = 0; i < sourceMaterials.Length; i++)
                    {
                        Material targetMat = null;
                        foreach (var replacement in replacements)
                        {
                            if (sourceMaterials[i] == replacement.sourceMat)
                            {
                                targetMat = replacement.targetMat;
                                break;
                            }
                        }

                        if (targetMat != null)
                        {
                            targetMaterials[i] = targetMat;
                        }
                        else
                        {
                            targetMaterials[i] = sourceMaterials[i];
                        }
                    }
                    renderer.materials = targetMaterials;
                }
            }
        }
    }
}
