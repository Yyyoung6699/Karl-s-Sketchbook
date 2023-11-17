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
Basic functionality: movement, jumping, perspective, ground detection, and camera following regarding character control.
```
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


