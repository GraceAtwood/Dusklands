using System.Collections.Generic;
using System.Linq;
using Duskland.Enums;
using Duskland.Utilities;
using UnityEngine;

namespace Duskland.Character
{
    public class BodyPart : MonoBehaviour
    {
        public static HashSet<BodyPart> AllBodyParts { get; }

        static BodyPart()
        {
            AllBodyParts = new HashSet<BodyPart>();
            
            var bodyPartScanHooks = FindObjectsOfType<BodyPartScanHook>();
            
            foreach (var bodyPartScanHook in bodyPartScanHooks)
            {
                var bodyParts = bodyPartScanHook.transform
                    .Cast<Transform>()
                    .Select(x => x.gameObject.GetComponent<BodyPart>())
                    .Where(x => x != null)
                    .ToList();

                foreach (var bodyPart in bodyParts)
                {
                    if (bodyPart.gender == default)
                        bodyPart.gender = bodyPartScanHook.gender;

                    if (bodyPart.bodyLocation == default)
                        bodyPart.bodyLocation = bodyPartScanHook.bodyLocation;

                    if (bodyPart.bodyPartName == default)
                        bodyPart.bodyPartName = bodyPartScanHook.bodyPartName;
                }
                
                bodyParts.ForEach(x => AllBodyParts.Add(x));
            }
        }

        public BodyLocation bodyLocation = BodyLocation.NONE;
        public string bodyPartName;
        public Gender gender = Gender.NONE;
    }
}