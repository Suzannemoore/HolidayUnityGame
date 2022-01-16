# HolidayUnityGame
Game created in Unity of Santa picking up presents and bring the presents back to the sleigh 

C# Unity Game Santa Driver

Tools: Unity Hub 2021, Visual Studio, and C# for programing.

Technical requirement:
Unity Hub, C#, Visual Studio and Windows 11

Main goal: 
The main goal of this project is to create a 2D driving game to see Santa picking up presents and dropping of the presents to correct houses after a mistake. We will be able to decrease when the sleigh bumps into an obstacle or speed up when crossing ice. Santa will be able to pick up present and dropping them back on the sleigh. We will also increase our skills in C# while learning more about methods, triggers, references, colliders, and working in Unity 2021.

Visualization of the program: 
Here we have Santa’s sleigh and presents (which will be picked up and dropped off at the correct houses. These shapes will be made by selecting the Hierarchy tab, left click and select 2D object, Sprites, and then selecting the shape of choice. Each Sprite will need to be renamed. Picture of PNG will need to be uploaded in the project file to build the layout and create Sprites. 

![Picture2](https://user-images.githubusercontent.com/62191363/147822030-e8ff689b-8fa0-4498-b043-b7ab8b92ba7b.png)

    void OnCollisionEnter2D(Collision2D collision)
    {
        // the will appear when Santa sleigh has hit an object
        Debug.Log("Santa has crashed, keep moving!");
    }
    
This is a built-in method used in Unity. We will make the method public and when we have a collision with a trash can or house, we will get the information. In this project we will create another C# script named Collide to print out "Santa has crashed, keep moving!". To add this script to the Santa sleigh we will add the Collide C# script by adding Component and selecting Collide.

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Present")
        {
            Debug.Log("Present has been picked up! Hurry!");
        }
    }
    
This method will allow Santa to pick up the packages and let the user know. By giving the user that present selected. This was allowed by allowing the package to be a trigger. 
We will be using a Bool to make sure the presents have been picked up and dropped off. We will make sure the present status is set to false when the games start and is set to true when the player picks up the package. When delivered back to the sleigh, the present status will be set back to false. 
if(collision.tag == "Present")
        {
            Debug.Log("Present has been picked up! Hurry!");
            // when package is picked up
            presentStatus = true;
        }

        if(collision.tag == "Recipient" && presentStatus)
        {
            Debug.Log("Hooray, present has been dropped off!");            
     // when package is dropped off
            presentStatus = false;

        }
Due to user allowing Santa to pick up the presents we will create a variable that will be automatically set to false. When the user glides over a present the present will disappear due to the Destroy method. To allow Santa to only pick up one package, we will make sure the user can only pick up one present at a time. We will initialize a SerializeField to allow a timer in which the presents will disappear when Santa picks them up. 

    // present status is false when games starts
    bool presentStatus;
    // package pick up timer
     [SerializeField] float pickUpTimer = 0.3f;

        // if use gets the package and doesn't already have one 
        if(collision.tag == "Present" && presentStatus == false)
        {
            Debug.Log("Present selected");
            // when package is picked up
            presentStatus = true;
            // after Santa drops off the package we will use Destory() to get rid of the present
            Destroy(collision.gameObject, pickUpTimer);
            
        }
        
Since the user will be able to slip on ice and crash into Sprites we will use fastSpeed to speed up the user when Santa has slipped on ice and back to slowSpeed when the user has crashed into another Sprite. 

    // main moving speed 
    [SerializeField] float movingSpeed = 20f;

    // fast speed for when user slip on ice
    [SerializeField] float fastSpeed = 30f;

    // slow speed for when user bump into an obstacle 
    [SerializeField] float slowSpeed = 12f;
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            // set movingSpeed to slowSpeed when the user bumps into somthing
            movingSpeed = slowSpeed;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            // if tag is slipSpeed
            if(collision.tag == "slipSpeed")
            {
                Debug.Log("SLIPPERY ICE");
                // set movingSpeed to fastSpeed
                movingSpeed = fastSpeed;
            }
        }

Result of game in Pictures: 

![Picture3](https://user-images.githubusercontent.com/62191363/147822102-7155611f-745b-4399-8c23-44adf30f5f0e.png)
![Picture4](https://user-images.githubusercontent.com/62191363/147822104-f0df6477-5222-40ba-bc3e-e481981d38d8.png)

Result of game in Video: 

https://user-images.githubusercontent.com/62191363/147822235-1b3a933c-92ef-4945-a4f5-38da7f9aa36a.mp4

