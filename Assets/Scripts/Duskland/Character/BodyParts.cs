using System.Collections.Generic;
using System.Linq;
using Duskland.CharacterCreation;
using Duskland.Enums;
using UnityEngine;
using Gender = Duskland.Enums.Gender;

namespace Duskland.Character
{
    public static class BodyParts
    {
        public static readonly HashSet<BodyPart> AllBodyParts;
        
        static BodyParts()
        {
            var bodyParts = new HashSet<BodyPart>();
            
            foreach (var parentBodyPartDescriptor in Object.FindObjectsOfType<ParentBodyPartDescriptor>())
            {
                var children = parentBodyPartDescriptor.gameObject.transform
                    .Cast<Transform>()
                    .Select(x => x.gameObject)
                    .ToList();

                foreach (var child in children)
                {
                    if (child.TryGetComponent(typeof(BodyPart), out var component))
                    {
                        var bodyPart = (BodyPart) component;

                        if (bodyPart.bodyLocation == BodyLocation.NONE)
                            bodyPart.bodyLocation = parentBodyPartDescriptor.bodyLocation;

                        if (bodyPart.gender == Gender.NONE)
                            bodyPart.gender = parentBodyPartDescriptor.partGender;

                        bodyParts.Add(bodyPart);
                    }
                    else
                    {
                        var bodyPart = child.AddComponent<BodyPart>();

                        bodyPart.gender = parentBodyPartDescriptor.partGender;
                        bodyPart.bodyLocation = parentBodyPartDescriptor.bodyLocation;
                        
                        bodyParts.Add(bodyPart);
                    }
                }
            }

            AllBodyParts = bodyParts;
        }
    }
}