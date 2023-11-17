# Weekly work
## Week 1 Project proposal
### Inspiration
Inspired by a new puzzle game called Viewfinder, it transforms 2D photos into part of a 3D game scene through the in-game camera, a clever perspective-based puzzle mechanic. I found this mechanic very interesting, so I decided to try to make a 3D puzzle game using this mechanic. Puzzle games are usually accompanied by a story narrative, after referring to some puzzle narrative games, I decided to try a fragmented narrative to tell a story. Image recognition technology has been used with success in previous projects, so I was curious about what the effect of introducing new image recognition technology into a puzzle game would be. As a result, a 3D puzzle narrative game incorporating image recognition technology was born.

### Other working in this area
#### Viewfinder
Viewfinder is an experiment started around November 2019 by indie game developer Matt Stark. This game was my inspiration, and I experienced that instant sense of surprise from the incredible puzzle mechanics in this game. This game was my inspiration, and I experienced that instant sense of surprise from the incredible puzzle mechanics in this game, an emotional value that I think is a key factor in puzzle games engaging players.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/f3cfdcd3-0eab-44d9-90b3-53165a3bf140)

#### What Remains of Edith Finch
What Remains of Edith Finch, developed by Giant Sparrow, The game is presented as an interconnected anthology, and, utilising unique mediums from varying The game is presented as an interconnected anthology, and, utilising unique mediums from varying perspectives, the story is told through a series of vignettes. This storyline is constructed in a patchwork fashion, assembling itself through a sequence of unearthed manuscripts -a characteristic element often found in Gothic fiction. Each manuscript triggers an interactive micronarrative that portrays the demise of members from the Finch family (Ewan Kirkland, 2020).

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/79cda20f-71ca-4a8d-97c2-4be3cf700409)

#### Mencage
Moncage is a puzzle game created by Dong Zhou and Yijia Chen of New York University, which uses a large number of optical illusions, requiring the player to use their brain and imagination to find the connection between those ordinary scenes and objects, resulting in unexpected and wonderful interactions. interaction, splicing, and then witnessing the birth of a miracle. Like Viewfinder, they bring players an emotional value of surprise and amazement when they succeed in solving the puzzles.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/120c780e-8f26-452c-b2ee-6fbdbc6800b1)

### Research target
The aim of this project is to investigate narrative and puzzle design in puzzle games by designing and producing a puzzle narrative game.

Explore the use of fragmented narratives in a puzzle narrative game. Explore how referencing image recognition technology has an impact on puzzle games and fragmented narratives. In addition, to explore what kind of puzzle design can bring unexpected emotional value to the player in the context of other successful puzzle games (WOW! MOMENT).

The research plan will be both theoretical and practical, and eventually invite players to play and record their social process to evaluate the project.  These research results will provide useful theoretical and practical guidance for game production and promote the development and innovation of the game industry. These research results will provide useful theoretical and practical guidance for game production and promote the development and innovation of the game industry.

### Research plans and methods
Game design and development: Design and develop a game based on Unity engine.

User Testing and evaluation：
Location: Console store. I currently work part-time in a console store with XBOX, PS5, and switch consoles. 

Testing users: The guests in the consoles store range from children to students, middle-aged, elderly, both men and women, and must be people who like to Testing users: The guests in the consoles store range from children to students, middle aged, elderly, both men and women, and must be people who like to play games, which is a good test occasion. 
Testing methods: Invite players to try the game, and research questions in the form of user interviews at the end of the trial.
Through the game, how much do you know about the plot of this game? (Through the tester's description, the developer will give a percentage value for the tester's understanding of the plot.)
What elements of the game did you learn about the plot through? (2023.10.5 additional scenes, puzzles, paintings, NOTES)
How do you think the fragmented narrative affects the narrative of the game's plot? Any ideas for improvement?
Which of the game's puzzles impressed you the most? Which level's puzzle idea or mechanic did you think was unexpected (and surprised you)?
What did you find most appealing about the game (the puzzle design or the narrative)?
In addition, you can video record the player's reaction during the demo to observe which puzzle design brings richer emotional value to the player. Which puzzles surprised the player at the moment of decoding. Which puzzles were relatively mediocre.
Based on the test results and the design process, study the key factors affecting the plot narrative, and what kind of puzzle mechanism design is more capable of touching the player and bringing unexpected emotional value, and how such emotional value affects the player's adhesion. The final conclusion is drawn.

### Technical realization
Image recognition technology: Vuforia Engine is essentially an augmented reality (AR) plug-in for Unity. By uploading each page of the sketchbook to the library, the camera detects the corresponding content and makes a determination.
Unity Engine

## Week 2 Game Mechanics Design & Functional feasibility verification & minimum runnable files
### Game Mechanics Design
The player can use image recognition technology to send a scan of the image to the mobile phone in the game. The character takes out his mobile phone and opens the gallery to see the received image. Select the image to switch to camera mode, you can see the mobile phone camera view on the screen of the phone, and select the appropriate position in that view to generate the image into a 3D model to be placed in the scene. The objects placed down will produce some effects to solve the puzzle.
Example: There is a door with no doorknob on it, the player uploads a picture of a doorknob to his mobile phone and then generates the doorknob on the door through the mobile phone, at which point the door can be opened.

### Functional feasibility verification
Create a new test project in Unity to verify the feasibility of the game's core features.
#### Basic functionality: movement, jumping, perspective, ground detection, and camera following regarding character control.
```C#
public void StartControl()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = jumpSpeed;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;//重力
        cc.Move(velocity * Time.deltaTime);
    }
```
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/a9892770-9613-49f3-ad0f-77e6fd2ed2e0)

#### Core function: the protagonist can take out, put away the mobile phone, open the screen of the phone to select a picture, and generate the object in the picture in a 3D scene after a left mouse click. (Added 2023.9.20 to change the mobile phone into a sketchbook)
```C#
void TakePhone()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        if (playerCamera != null)
        {
            transform.LookAt(playerCameraTransform);
            //transform.localEulerAngles -= new Vector3(0, 0, 0);
            transform.SetParent(playerCameraTransform);

            transform.position = playerCameraTransform.position + playerCameraTransform.forward * 2.0f;
            hadBook = true;
        }
        BookHelper.Open();
    }
void BackPhone()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        transform.position = playerCameraTransform.position - playerCameraTransform.forward * 1.0f;
        hadBook = false;
    }
```
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/a92e257c-e95b-4041-9077-88ab4d040577)

The image below shows a door handle being generated on a door via a mobile phone

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/61255d4c-f4fe-4c17-bae5-b907a36f4601)

One of the functions and code for generating 3D objects using a mobile phone was removed in a subsequent update, here is a screenshot of the old code.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/f158bdf2-1455-483c-9f5b-5dc02a6557cd)

## Week 3 Interactive Format & Art Style Reference & Scene Setting
### Interactive Format
The form of interaction throughout the game I intend to refer to Viewfinder, with a first person view, without hands and other parts of the character model, so that more time can be devoted to other tasks. The keyboard WASD keys control character movement, the mouse controls the viewpoint, and the left and right as well as F keys interact with elements in the scene.

### Art Style Reference
In terms of art style, firstly I gave up on the realistic style, which was too much work and would make the whole project look very low poly if not rendered properly. I looked at Viewfinder and Moncage, which uses a low poly style. Moncage uses a low poly style, which has a lot of art materials online, but the quality of the models and materials varies, making it difficult to unify the overall art style. In the end, I chose Viewfinder's stylised art. All model materials are from the internet.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/25ef1467-04d0-45dd-8f10-310e0e2ab4be)

The initial art style of the scenes was not satisfactory, and the tone of the style was slowly determined through constant iteration. The image below shows the initial scene and the scene after the style was finalised. The left image is the initial style and the right image is the updated style.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/3f06dfd6-2947-4b72-bae2-6c04aad24bf9)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/5cdee00f-eb31-45a7-ba8d-bde82df4b621)

Currently, I've created three parts of the scene, including the stone door, the river and the main character's room. The work mainly involves finding suitable model materials and placing them appropriately in the scene. In addition to this, we are also working on materials, lighting, shadow rendering, filters, etc. This process requires constant modifications and adjustments. This process requires constant modification and adjustment, which is quite time-consuming. The following pictures show some scenes.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7f6f38d9-b401-4a1a-8607-d8cd160b67e2)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/f7664fe3-f59d-45f7-bf4f-d4803a1fa044)

It can be seen that the current outdoor scene and indoor scene style is not unified, which will be solved in the subsequent update relying on filters and other technologies.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/82289722-a2ad-48ca-8279-af1c94f8464b)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2ead205e-2100-4003-ae6d-f6ad80bf5c64)

## Week 4 Game Plot Design & Game Mechanics Updates
### Game Plot Design
The protagonist, Karl, loses his father at a young age and his mother remarries. But the stepfather and mother were bad to Karl, keeping him confined to his room most of the time.  Unable to play outside, Karl turns to drawing, and his prolonged isolation leads to him becoming increasingly introverted.  At the age of 18, Karl chooses to leave his family and the city to immerse himself in the forest, where he discovers his lifelong love, Catherine.  Their shared interests bring warmth back into Karl's life. The two quickly fall deeply in love, embarking on artistic journeys together.

However, a tragic accident claims Catherine's life, shattering Karl.  Grief-stricken, he reverts to his eccentric ways, and as he enters middle age, his artistic style morphs into the strange and abstract.  Surprisingly, his eccentric works garner significant attention, propelling Karl to fame.  A businessman contacts Karl, hoping to organize an exhibition for him.  Karl agrees, and at the exhibition, many vie to purchase his works, hoping to flaunt their taste.  In conversations between the businessmen, Karl realizes they don't truly understand the creations;  to them, it's merely a tool for showcasing their sophistication.  When they express interest in exploiting the connection between his works and his departed girlfriend for publicity, Karl, incensed, destroys the exhibition.  This act, however, Karl lose everything again.

Lost in a fog of existence, Karl's mental state deteriorates visibly, and his body rapidly ages.  In his twilight years, Karl lies in a hospital bed, his consciousness and memories affected by his mental disorder.  At his bedside rests the sketchbook that accompanied him throughout his life.  In his final moments, Karl, with a foggy consciousness, flips through his sketchbook.  Many of the contents have faded away, much like his memories.  Ultimately, with the player's help, Karl pieces together the artworks, recalling his entire life.  His journey was marked by sorrow, yet it also held moments of happiness, all immortalized by Karl's skilled hand, forever preserved.

### Game Mechanics Updates
Because of the design of the plot, the mechanics have done some updated iterations.
The player holds a physical sketchbook. When these artworks appear in front of the camera (image recognition technology), they appear in the sketchbook in the game. These paintings contain clues. The player must guide the protagonist to the location where each piece was originally created. By observing the puzzles, the paintings and the notes under them, and combining the clues in them to choose the right painting to interact with the puzzle, the player is helped to rebuild his memory and break through the levels.

The overall interactive gameplay is not too far from the previous one, but enriches the background and logic, making the whole game more really and sensible.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2458bcda-bb70-498c-9f76-08ca8d7d3097)

## Week 5 Core Function & First Level Production
### First Level Production
The player is in Karl's childhood room, where the locked door is a metaphor for the protagonist's restricted childhood experiences. Design a drawing of a doorknob. When the player selects the drawing and interacts with the door, the drawing disappears and a doorknob is created on the door. Press F to open the door.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/f12a1891-6a42-4f47-85f7-81cdb06b9c08)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/36d44dcf-441d-4dfb-970e-ee2986d24dfc)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/05afcfd6-3a8f-44c9-8209-a47ae3fb536b)

Because of the large amount of code, some key code is shown here
#### Some interactions of the book
```C#
void Preview()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        renderer.material.renderQueue = 3000; // 设置Render Queue值为3000

        if (renderer.material.HasProperty("_Alpha"))
        {
            renderer.material.SetFloat("_Alpha", 0.4f); // 设置Alpha属性值为0.5
        }
        UseMoveObject();
    }

void NoPreview()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        renderer.material.renderQueue = 2000; // 设置Render Queue值为3000

        if (renderer.material.HasProperty("_Alpha"))
        {
            renderer.material.SetFloat("_Alpha", 1.0f); // 设置Alpha属性值为0.5
        }
    }
```
#### Changes the image displayed in the book based on the value returned by the Vuforia Engine's image recognition, and also determines the right picture to interact with the level based on this value.
```C#
public void ArChange()
    {
        if (arImage != previousArImage) // 只有在 ArImage 发生变化时才执行
        {
            previousArImage = arImage; // 更新上一帧的 ArImage
            if (arImage == "ARContent1")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(1, 2));
                CurrentTextrue = 1;
                PaperHaveContent();
            }
        }
    }
public void ChangeContent(int y, int n)//修改书的画
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        Material material = renderer.material;

        if (material.HasProperty("_PaperContent"))
        {
            material.SetTexture("_PaperContent", textureArray[y]);
        }
        if (material.HasProperty("_PaperNoContent"))
        {
            material.SetTexture("_PaperNoContent", textureArray[n]);
        }
    }
```











