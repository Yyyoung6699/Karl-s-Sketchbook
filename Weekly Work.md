![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2afb1e41-10d9-4d29-bcf0-8f6906fa363d)# Weekly work
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
#### ray detection door
```C#
void ShootRay(Ray ray, out RaycastHit hit)
    {
        hit = new RaycastHit(); // 初始化 hit 变量

        if (Physics.Raycast(ray, out hit, MaxDistance))
        {
            BookController bookController = GameObject.Find("Book_Necromancer").GetComponent<BookController>();
            textrue = bookController.CurrentTextrue;

            if (hit.collider.gameObject.name == "Door" || hit.collider.gameObject.name == "RainbowTrigger" || hit.collider.gameObject.name == "Huaban" || hit.collider.gameObject.name == "TiaoSePan" || hit.collider.gameObject.name == "InteractionFrame" || hit.collider.gameObject.name == "InteractionFrame2")
            {
                ui.Show_UI_Point();
            }
            else
            {
                ui.Hide_UI_Point();
            }
            if (Input.GetMouseButtonDown(0) && bookController.CanChange == true)
            {
                if (hit.collider.gameObject.name == "Door" && textrue == 1)
                {
                    bookController.UsePaperNoContent();
                    StartDoor = true;
                }
            }
        }
    }
```
#### Generate door handles (including rain after opening the door)
```C#
void Update()
    {
        if (interaction.StartDoor == true && CanOpen == true)
        {
            grayKnob.SetActive(true);
            if (interaction.HitInteractionDoor == true)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    playAnimation();//开门动画
                    Raining = true;//bool开始下雨且阴天
                }
            }
        }
        if (Raining == true)
        {
            ChangeVolume();
        }
    }


    public void playAnimation()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Open");
        CanOpen = false;
    }

    public void ChangeVolume()
    {
        var visualEffect = Rain.GetComponent<VisualEffect>();
        visualEffect.Play();//停止下雨

        Volume volume = globalVolume.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float transitionSpeed = 0.5f;  // 过渡速度，根据需要调整

            float targetR = 167f / 255f;
            float targetG = 167f / 255f;
            float targetB = 200f / 255f;

            float newR = Mathf.Lerp(colorAdjustments.colorFilter.value.r, targetR, Time.deltaTime * transitionSpeed);
            float newG = Mathf.Lerp(colorAdjustments.colorFilter.value.g, targetG, Time.deltaTime * transitionSpeed);
            float newB = Mathf.Lerp(colorAdjustments.colorFilter.value.b, targetB, Time.deltaTime * transitionSpeed);

            colorAdjustments.colorFilter.value = new Color(newR, newG, newB, 1);
        }
    }
```

## Week 5 Subsequent level updates 2-4
### Level 2
In the second level Karl faces the cliff in the heavy rain and thinks of a scene he once had in a dream, walking on a rainbow, and when he wakes up Karl paints this piece of artwork. Choose this painting to interact with the cliff, and walk on the rainbow when it appears. The implementation method is similar to the first level, here only show the rainbow transition code.
```C#
public void RainbowAlpha()
    {
        StartCoroutine(DelayRainbowAlpha());
    }
    IEnumerator DelayRainbowAlpha()
    {
        yield return new WaitForSeconds(2.0f);
        //GameObject Rainbow = GameObject.Find("Rainbow");
        if (rainbow != null )
        {
            Renderer renderer = rainbow.GetComponent<Renderer>();
            Material material = renderer.material;

            // 在每一帧更新透明度
            alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 0.5f); // 这将使透明度从0逐渐过渡到1
            if (renderer.material.HasProperty("_TransparentSrength"))
            {
                renderer.material.SetFloat("_TransparentSrength", alpha); // 设置Alpha属性值为0.5
            }
            ziFaGuang = Mathf.Lerp(alpha, 0.5f, Time.deltaTime * 0.5f);
            if (renderer.material.HasProperty("_EmissiveStrength"))
            {
                renderer.material.SetFloat("_EmissiveStrength", ziFaGuang); // 设置Alpha属性值为0.5
            }
        }
    }
```
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7762b390-2e11-4cb2-8fdb-f73b9452a2db)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/d6015f93-deee-4bcc-9370-972872f8e736)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2e885d8a-21d2-4abe-8503-dca474cda107)

### Level 3
Starting with the third level I'd like to do something innovative with the decryption mechanism. I avoid the boredom caused by a single gameplay style, the puzzle ideas need to be more varied, so as to constantly bring new surprises to the players.

The third level takes place in the location where Karl sketched during his youth, and the player is blocked by a collapsed stone door with a wooden easel standing next to it. By observing the environment of the scene, it is not difficult to find that the content of the Forest Trail painting is similar to the surrounding environment. After interacting with the easel, the painting appears on the easel, but the stone gate still blocks the way forward. According to the plot hints, the player needs to find the right angle so that the line of sight, the painting panel and the stone door are in a straight line. Through a clever visual illusion, the scenery of Forest Trail on the painting board obscures the collapsed part of the stone gate, and visually the scenery in the painting blends in with the jungle behind the stone gate, as if this stone gate has never collapsed. In this moment, all this becomes reality, the scenery in Forest Trail replaces the collapsed part of the gate, and the player can pass through it directly.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/58edff8b-7dc1-41a1-94e2-302800291ea0)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2af3c933-11d9-40f6-96a5-3d44b8908fd1)

#### trigger a plot
```C#
public void Tutorial5()
    {
        timer5 += Time.deltaTime;

        if (currentIndex5 < subtitles5.Length)
        {
            if (timer5 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText5.text = subtitles5[currentIndex5];
                currentIndex5++;
                timer5 = 0.0f;
            }
        }
        if (currentIndex5 == subtitles5.Length)
        {
            backGround.SetActive(false);
            currentIndex5 = currentIndex5 + 1;
        }
}
```
#### Position detection
```C#
public void DetectPosition()
    {
        Transform playertransform = player.transform;
        float px = playertransform.position.x;
        float pz = playertransform.position.z;
        if ((px >= 2.45f && px <= 3.6f) && (pz >= -34f && pz <= -31.5f))
        {
            if(interaction.HitDetectObj == true)
            {
                paint.SetActive(false);
                frame.SetActive(false);
                gameObject.SetActive(false);
                rockWall.SetActive(false);
            }
        }
}
```

Also some modifications to the model of the easel to make it smoother in moments of optical illusions.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7ea97320-9e93-43a5-8670-01f8a0c59d23)

### Level 4
In the fourth level, the player is blocked by a red river, and next to the river is a palette containing red paint.  It is easy to see that the puzzles in this level are colour related, and the palette echoes Karl's identity as a painter, which is seen as the key to solving the puzzles.  The painting used for solving the puzzle is called Katherine, the girl in the painting is beautiful, the whole painting is in blue colour, and "She's as clear as a river." in the Note suggests the river in front of you.  Interacting with the palette, the paint in the palette turns blue, and the river turns clear blue. 

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/842785c6-ef68-4fd5-8dd1-328009c2b426)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2678dc00-4e87-448b-99c2-59e5bc7aeb96)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7cc4bf58-842d-40b0-955d-d60e67f2f548)

#### Modify the colour of the river
```C#
public void ChangeWater(int bookTextrue)
    {
        float newRT = 0;
        float newGT = 0;
        float newBT = 0;
        float newTransT = 0;
        switch (bookTextrue)
        {
            case 1:
                newRT = 0.333f;
                newGT = 0.333f;
                newBT = 0.333f;
                newTransT = 0.2f;
                break;
            case 2:
                newRT = 0f;
                newGT = 0f;
                newBT = 0f;
                newTransT = 0.2f;
                break;
        }
        Renderer renderer = water.GetComponent<Renderer>();
        Material material = renderer.material;
        float newR = Mathf.Lerp(material.GetColor("_WaterColor").r, newRT, Time.deltaTime);
        float newG = Mathf.Lerp(material.GetColor("_WaterColor").g, newGT, Time.deltaTime);
        float newB = Mathf.Lerp(material.GetColor("_WaterColor").b, newBT, Time.deltaTime);
        float newTrans = Mathf.Lerp(material.GetFloat("_Transparency"), newTransT, Time.deltaTime);
        Color newColor = new Color(newR, newG, newB, 0); // 设置颜色
        material.SetColor("_WaterColor", newColor);
        material.SetFloat("_Transparency", newTrans);
    }
```
#### Delete air wall
```C#
public void NoWall()
    {
        waterWall.SetActive(false);
    }
```

## Week 6 UI & Tutorials & Subtitles
### UI
Improve all UI

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/11298e0b-6cbb-4bcf-8e26-172df59be58d)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/9b33d0f6-c810-40d0-8149-c0168a972437)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/40b589ff-2f80-4db3-a914-829abf234764)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/4fe549f5-e32f-4262-a74a-c2e6b0f9a8f4)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/aa1dbb24-7dcb-4b0b-b917-cb3d7a215157)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/2de6f8d4-3d3b-45a5-9195-7b5670d6f018)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/0fa2f79e-0e19-408c-865e-589a47f7b2c9)

#### Show and hide UI
```C#
public void Show_UI_Movement()
    {
        UI_Movement.SetActive(true);
    }
    public void Hide_UI_Movement()
    {
        UI_Movement.SetActive(false);
    }
    public void Show_UI_Point()
    {
        alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 5);
        Color startColor = UI_Point.GetComponent<Image>().color; 
        UI_Point.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    }
    public void Hide_UI_Point()
    {
        alpha = Mathf.Lerp(alpha, 0.0f, Time.deltaTime * 5);
        Color startColor = UI_Point.GetComponent<Image>().color;
        UI_Point.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    }
```

### Tutorials
The tutorial focuses on the core operations of the game, including image scanning.

The protagonist wakes up in unfamiliar surroundings and doesn't remember how he got here, but he finds his sketchbook by his side. Opening the sketchbook, the protagonist discovers that something is missing from it, hinting at the protagonist's missing memories. The sketchbook instructs to scan the paintings through image recognition. At this point, only scanning the Tutorial piece will trigger the subsequent plot, and by clicking on the confirmation through the guide, the window will change from a painting to reality. The protagonist is also shocked and looks around and realises that he is in his childhood room, at which point the protagonist says I think I can move. and hints at the UI that guides the movement.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/9073165a-02e2-44bb-a4c9-02a5de6b9236)

#### Can't move until you finish the tutorial
```C#
private void Update()
    {
        if (afterTutorial)
        {
            StartControl();
        }
    }
```
#### Tutorial
```C#
void Tutorial()
    {
        StartCoroutine(TutorialDelay());
    }
    public IEnumerator TutorialDelay()
    {
        //yield return new WaitForSeconds(4.0f);
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        transform.LookAt(playerCameraTransform);
        //transform.localEulerAngles -= new Vector3(0, 0, 0);
        transform.SetParent(playerCameraTransform);
        transform.position = playerCameraTransform.position + playerCameraTransform.forward * 2.0f;
        BookHelper.Open();
        yield return new WaitForSeconds(6.0f);
        ChangeContent(11, 11); 
        for (int i = 0; i < 2; i++)
        {
            BookHelper.NextPage();
            yield return new WaitForSeconds(1.0f); // 等待1秒钟
        }
        BookHelper.NextPage();
        StartCoroutine(DelayedChangeContent(10, 10));
 }
```
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/4a850633-814f-4474-bf17-f5436642af53)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/d2f4ca37-92e2-4659-b600-8b7554b4bfb8)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/5e8a7dc6-065d-4ab8-8616-93a81067045c)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/b1c5e633-46d3-4131-a816-323172394ea4)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/9a7d46d2-447a-4654-81a3-62310666753f)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/10e277d8-f9ff-4782-8a4c-177f267a79c5)

### Subtitles
Subtitles for Levels 3 and 4
How come nothing's changed?
The door is still blocked.
This portrait is the scene behind the door.
Maybe I should get the right perspective.
If I look at the door through the painting?

The water is a strange colour.
It doesn't look deep.
If it wasn't this color, I could get through it.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/fda39690-dd94-43ef-b178-86b4a86e57dd)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/9d43dde8-3fb5-4735-89cd-dd914453d04c)

## Week 7 New Sence
### Cave
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/c91ba62a-042f-4479-b730-5dff855a828d)

### Gallery
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7ac4c42b-9a6c-4a80-b940-b7a38f442582)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/b51e09f4-8411-47a1-a5aa-d1d5d5707b7d)

### Hospital room
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/40003b04-a364-4ed4-9d0f-cf6a1aca3822)

## Week 8 Level 5-7
### Level 5 cave(delay)

### Level 6
Through the cave the player arrives at a vandalised art gallery. it is clear from Karl's voice-over that Karl has forgotten who vandalised this place. the few remaining spotlights in the darkened gallery point to the sixth level's puzzle. a rotating picture frame hangs on the glass wall. it is implied in Ring that She once illuminated me. after interacting with the frame this work of art appears on the picture frame. After interacting the artwork with the frame, the Ring appears on the frame. Interestingly, on the other side of the glass wall, there is also a rotating painting of a man holding up a ring in a very scribbled and simple style. From this side we can see how the two paintings overlap, at which point the player needs to rotate the two paintings to the correct angle to piece together a scene where a man is holding up a ring, and the diamonds in the ring are the stars in Ring. The exhibition hall is lit up.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/c8f524fa-c861-45a5-8e50-1d0f5583ea5f)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/b1cd5abc-6e19-42d6-8770-20a8e76ec4e2)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/d976aaa4-4b97-4165-832d-8da88a5f9710)

#### Rotating paintings and light-ups
```C#
void Update()
    {
        if (interaction.HitInteractionFrame == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                targetAngle += rotationAmount;
                StartCoroutine(RotateObject(targetAngle)); // 启动旋转协程
            }
        }
        if (interaction.StartStar == true)
        {
            StarMask.SetActive(false);
            currentAngle = transform.rotation.eulerAngles.z;
            if (Mathf.Approximately(currentAngle, 270f) && paintFrame4.rightAngle)
            {
                Star.SetActive(true);
                Light.SetActive(true);
            }
            else
            {
                Star.SetActive(false);
                Light.SetActive(false);
            }
        }
    }

    IEnumerator RotateObject(float targetAngle)
    {
        float startAngle = transform.rotation.eulerAngles.z;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed;
            float angle = Mathf.LerpAngle(startAngle, targetAngle, t);
            transform.rotation = Quaternion.Euler(0, -60, angle);
            yield return null;
        }

        // 确保最终角度准确
        transform.rotation = Quaternion.Euler(0, -60, targetAngle);
    }
```

### Level 7
The seventh level is a picture frame without a picture placed on the wall of the pavilion, select the picture Puzzle to interact with the board and the puzzle will appear on the frame. By interacting the Puzzle with the frame and returning the Puzzle's puzzle pieces, we enter a hospital room, which is the end of the game and the end of Karl's life.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/b28685f1-56c7-49d0-9d59-ae390fd8e7a6)
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/0a9e5387-a0ec-4888-bcde-bd09073b31d9)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/b24f3d7c-6f16-413e-a240-4d72d6996bf5)

#### Show Puzzle
```C#
if (interaction.StartPinTu == true)
        {
            Image1.SetActive(true);
            Image2.SetActive(true);
            Image3.SetActive(true);
            Image4.SetActive(true);
            Image5.SetActive(true);
            Image6.SetActive(true);
        }
```
#### Press F to interact
```C#
if (interaction.HitInteractionFrame2 == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PinTuZhuangTai = PinTuZhuangTai + 1;
            }
        }

        if (PinTuZhuangTai == 1) 
        {
            StartCoroutine(MoveImages(Image3.transform, new Vector3(0.26f, Image3.transform.localPosition.y, Image3.transform.localPosition.z)));
            StartCoroutine(MoveImages(Image5.transform, new Vector3(-0.13f, Image5.transform.localPosition.y, Image5.transform.localPosition.z)));
        }
        if (PinTuZhuangTai == 2)
        {
            StartCoroutine(MoveImages(Image4.transform, new Vector3(-0.26f, Image4.transform.localPosition.y, Image4.transform.localPosition.z)));
            StartCoroutine(MoveImages(Image6.transform, new Vector3(-0.13f, Image6.transform.localPosition.y, Image6.transform.localPosition.z)));
        }
        if (PinTuZhuangTai == 3)
        {
            StartCoroutine(RotateLocalYTo90Degrees(Image5.transform));
            StartCoroutine(RotateLocalYTo90Degrees(Image6.transform));
            Image7.SetActive(false);
        }
```
#### Jigsaw movement
```C#
IEnumerator MoveImages(Transform imageTransform, Vector3 targetLocalPosition)
    {
        float elapsedTime = 0;

        Vector3 startingLocalPosition = imageTransform.localPosition;

        while (elapsedTime < transitionDuration)
        {
            imageTransform.localPosition = Vector3.Lerp(startingLocalPosition, targetLocalPosition, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageTransform.localPosition = targetLocalPosition;
}
```
#### jigsaw puzzle rotating door opener
```C#
IEnumerator RotateLocalYTo90Degrees(Transform targetTransform)
    {
        Quaternion startRotation = targetTransform.localRotation;
        Quaternion targetRotation = Quaternion.Euler(targetTransform.localRotation.eulerAngles.x, 170, targetTransform.localRotation.eulerAngles.z);
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            targetTransform.localRotation = Quaternion.Lerp(startRotation, targetRotation, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetTransform.localRotation = targetRotation;
   }
```

## Week 9 End & Sound
### End
![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/7ef00dd3-3d16-4884-8be5-83eca9d2de86)

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/35240392-2aa3-4052-9dc8-e9741476f437)

#### End animation
```#
public IEnumerator GameOver()
    { 
        ChangeContent(18, 18);
        Renderer renderer = BookObject.GetComponent<Renderer>();
        if (renderer.material.HasProperty("_Columns"))
        {
            renderer.material.SetFloat("_Columns", 2.0f); // 设置Alpha属性值为0.5
        }
        if (renderer.material.HasProperty("_Rows"))
        {
            renderer.material.SetFloat("_Rows", 5.0f); // 设置Alpha属性值为0.5
        }
        if (renderer.material.HasProperty("_Progress"))
        {
            renderer.material.SetFloat("_Progress", 0.0f); // 设置Alpha属性值为0.5
        }
        BookHelper.GameOver();

        TakeBook();

        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < 7; i++)
        {
            BookHelper.NextPage();
            yield return new WaitForSeconds(0.5f); // 等待1秒钟
        }
        BookHelper.NextPage();
        yield return new WaitForSeconds(8.0f);
        BookHelper.Close();
        StartCoroutine(DelayedBackBook());
}
```

### Sound
Background music, sound effects for walking on land, sound effects for walking in water.

![image](https://github.com/Yyyoung6699/Karl-s-Sketchbook/assets/116611898/99c3057d-6832-42d5-935c-189ace4a3374)

#### Detection of touching the ground or water triggers a sound effect
```C#
if (touch.TouchWaterBool == true)
        {
            audioPlayer.clip = waterRunning;
        }
        if (touch.TouchWaterBool == false)
        {
            audioPlayer.clip = running;
        }

        if (Mathf.Abs(horizontalMove) > 0.1f || Mathf.Abs(verticalMove) > 0.1f)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.Play();                
            }
        }
        else
        {
            audioPlayer.Stop();
        }
```











































