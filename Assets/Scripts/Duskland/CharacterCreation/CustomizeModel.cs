using System;
using System.Collections.Generic;
using System.Linq;
using Duskland.Character;
using Duskland.Enums;
using Duskland.Exceptions;
using UnityEngine;

namespace Duskland.CharacterCreation
{
    public class CustomizeModel : MonoBehaviour
    {
        public Gender currentGender = Gender.Male;

        private readonly Dictionary<Gender, Dictionary<AppearanceDetail, BodyPartData>> _bodyPartData =
            new Dictionary<Gender, Dictionary<AppearanceDetail, BodyPartData>>
            {
                {Gender.Female, new Dictionary<AppearanceDetail, BodyPartData>()},
                {Gender.Male, new Dictionary<AppearanceDetail, BodyPartData>()}
            };

        private void Start()
        {
            ScanForBodyParts();
        }

        private void ScanForBodyParts()
        {
            foreach (var dataDescriptor in FindObjectsOfType<ParentBodyPartDataDescriptor>())
            {
                var children = dataDescriptor.gameObject.transform.Cast<Transform>().Select(x => x.gameObject).ToList();

                switch (dataDescriptor.bodyPartGender)
                {
                    case BodyPartGender.MALE:
                    {
                        if (_bodyPartData[Gender.Male].TryGetValue(dataDescriptor.appearanceDetail, out var bodyPartData))
                        {
                            bodyPartData.Meshes.AddRange(children);
                        }
                        else
                        {
                            _bodyPartData[Gender.Male][dataDescriptor.appearanceDetail] = new BodyPartData(children);
                        }

                        break;
                    }
                    case BodyPartGender.FEMALE:
                    {
                        if (_bodyPartData[Gender.Female].TryGetValue(dataDescriptor.appearanceDetail, out var bodyPartData))
                        {
                            bodyPartData.Meshes.AddRange(children);
                        }
                        else
                        {
                            _bodyPartData[Gender.Female][dataDescriptor.appearanceDetail] = new BodyPartData(children);
                        }

                        break;
                    }
                    case BodyPartGender.BOTH:
                    {
                        if (_bodyPartData[Gender.Female].TryGetValue(dataDescriptor.appearanceDetail, out var bodyPartDataFemale))
                        {
                            bodyPartDataFemale.Meshes.AddRange(children);
                        }
                        else
                        {
                            _bodyPartData[Gender.Female][dataDescriptor.appearanceDetail] = new BodyPartData(children);
                        }

                        if (_bodyPartData[Gender.Male].TryGetValue(dataDescriptor.appearanceDetail, out var bodyPartDataMale))
                        {
                            bodyPartDataMale.Meshes.AddRange(children);
                        }
                        else
                        {
                            _bodyPartData[Gender.Male][dataDescriptor.appearanceDetail] = new BodyPartData(children);
                        }

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(dataDescriptor.bodyPartGender), dataDescriptor.bodyPartGender, $"Unhandled body part gender '{dataDescriptor.bodyPartGender}'");
                }
            }
        }

        public void ChangeModel(bool left, AppearanceDetail detail)
        {
            if (!_bodyPartData[currentGender].TryGetValue(detail, out var bodyPartData))
            {
                throw new UnknownBodyPartException(nameof(detail), detail,
                    $"Failed to access {currentGender} body part data for the detail '{detail}'.  " +
                    $"Did you tag the parent object with a {nameof(ParentBodyPartDataDescriptor)}?");
            }

            if (left)
                bodyPartData.ApplyLeft();
            else
                bodyPartData.ApplyRight();
        }

        public void ChangeGender(Gender selectedGender)
        {
            // Hide everything from the current gender
            foreach (var bodyPartData in _bodyPartData[currentGender].Select(x => x.Value))
            {
                bodyPartData.Hide();
            }
            
            // Show everything from the new gender
            foreach (var bodyPartData in _bodyPartData[selectedGender].Select(x => x.Value))
            {
                bodyPartData.Show();
            }

            currentGender = selectedGender;
        }

        public void ChangeRandom()
        {
            ChangeGender(UnityEngine.Random.Range(0, 1) == 0 ? Gender.Female : Gender.Male);
            foreach (var bodyPartData in _bodyPartData[currentGender].Select(x => x.Value))
            {
                bodyPartData.ApplyRandom();
            }
        }

        
    }
}