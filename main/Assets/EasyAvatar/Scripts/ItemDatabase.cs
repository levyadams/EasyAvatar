using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An example script written for the EasyAvatar asset on the Unity Store and probably elsewhere. 
/// A simple script for adding skinned mesh renderers to an "Avatar" or rigged character of some kind.
/// Utilizes the AvatarManager.cs script for the actual Skinned Mesh Renderer function!
/// 
/// Written by Levy Adams
/// levyadams@aol.com for feedback/support
/// </summary>
public class ItemDatabase : MonoBehaviour
{

    //The Avatar we want to attach objects to.
    GameObject avatar;

    /// <summary>
    /// A list for each category of clothing/misc items we want to add to the avatar along with their mask.
    /// </summary>
    public List<GameObject> hairObjects;
    public GameObject hairObjectMaskMesh;
    public List<GameObject> ClothingObjects;
    public GameObject clothingObjectMaskMesh;
    public List<GameObject> ShoesObjects;
    public GameObject shoesObjectMaskMesh;

    //An integer we will increase/reset depending on item equipped and the amount of items present in the list
    int hairObjectCounter = 0;
    int clothingObjectCounter = 0;
    int shoeObjectCounter = 0;

    //An object we can reference for list removal and destruction when it is time to change the clothing/item/whatever
    GameObject hairObject;
    GameObject clothingObject;
    GameObject shoesObject;

    void Start()
    {
        avatar = GameObject.FindGameObjectWithTag("Player");//hard-code the avatar/base mesh. Items will be equipped to this.
    }

    /// <summary>
    /// A function for cycling the hair object list and changing what is currently there.
    /// </summary>
    public void ChangeHair()
    {
        //if the number of objects in the list is zero, return and send warning to user.
        if (hairObjects.Count == 0)
        {
            Debug.LogWarning("No skinned mesh renderer objects inside of the respective list inside of the game controller game object in the ItemDatabase.cs script!");
        }

        //If there is no object, return!
        if (hairObjects[hairObjectCounter] == null)
        {
            return;
        }

        //Instantiate the new object to be used from the list of objects provided at the number the current object counter is on.
        GameObject newObject = Instantiate(hairObjects[hairObjectCounter], avatar.transform);

        //Destroy the current object on the base mesh.
        Destroy(hairObject);

        //Set the new hair object as the reference object
        hairObject = newObject;

        //Send the information to the Avatar Manager script to be executed!
        AvatarManager.instance.AddObjectToMesh(newObject, hairObjectMaskMesh, avatar);

        //if the object counter is equal to the amount of items in the list, we are at the end of the list, and should go back to 0, which is 1 in computer talk
        if (hairObjectCounter == hairObjects.Count - 1)
        {

            hairObjectCounter = 0;

        }

        //else we add one to the object counter and exit the function.
        else
        {

            hairObjectCounter++;

        }
    }

    /// <summary>
    /// A function for cycling the clothing object list and changing what is currently there.
    /// </summary>
    public void ChangeClothing()
    {
        if (ClothingObjects.Count == 0)
        {
            Debug.LogWarning("No skinned mesh renderer objects inside of the respective list inside of the game controller game object in the ItemDatabase.cs script!");
        }

        //If there is no object, return!
        if (ClothingObjects[clothingObjectCounter] == null)
        {

            return;

        }

        GameObject newObject = Instantiate(ClothingObjects[clothingObjectCounter], avatar.transform);
        Destroy(clothingObject);
        clothingObject = newObject;
        AvatarManager.instance.AddObjectToMesh(newObject, clothingObjectMaskMesh, avatar);

        if (clothingObjectCounter == ClothingObjects.Count - 1)
        {
            clothingObjectCounter = 0;
        }
        else
        {

            clothingObjectCounter++;
        }
    }

    /// <summary>
    /// A function for cycling the shoes object list and changing what is currently there.
    /// </summary>
    public void ChangeShoes()
    {
        if (ShoesObjects.Count == 0)
        {
            Debug.LogWarning("No skinned mesh renderer objects inside of the respective list inside of the game controller game object in the ItemDatabase.cs script!");
        }
        //If there is no object, return!
        if (ShoesObjects[shoeObjectCounter] == null)
        {

            return;

        }
        GameObject newObject = Instantiate(ShoesObjects[shoeObjectCounter], avatar.transform);
        Destroy(shoesObject);
        shoesObject = newObject;
        AvatarManager.instance.AddObjectToMesh(newObject,shoesObjectMaskMesh, avatar);

        if (shoeObjectCounter == ShoesObjects.Count - 1)
        {
            shoeObjectCounter = 0;
        }
        else
        {

            shoeObjectCounter++;
        }
    }

}








