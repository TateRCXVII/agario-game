```
Author:     Tate Reynolds
Partner:    Thatcher Geary
Date:       14-Apr-2022
Course:     CS 3500, University of Utah, School of Computing
GitHub ID:  TateRCXVII & ThatcherG
Repo:       https://github.com/Utah-School-of-Computing-de-St-Germain/assignment-eight---agario-team
Commit #:   5589e8eec3cf5619116944e29050cb371c091c14
Solution:   Agario
Copyright:  CS 3500 and Tate Reynolds and Thatcher Geary - This work may not be copied for use in Academic Coursework.
```
* __Trello (Our Sprint Board): https://trello.com/invite/b/iKPyIGNE/6a14375be53aa15c2473cc75eb74d840/冰淇淋：agario-sprint-board__

# Time Tracking
|               | Expected | Actual | Notes                                                                                                               |
|---------------|----------|--------|---------------------------------------------------------------------------------------------------------------------|
| Pre-Exercises | 2        | 2      | This really helped us get everything started.                                                                       |
| AgarioModels  | 3        | 3      | Implementing the game objects wasn't too bad. We needed <br>to figure out all the right data structures/etc.        |
| ClientGUI     | 10       | 13     | This was definitely the meat. Trying to figure out the commands,<br>moving, eating, etc. took a good chunk of time. |
| FileLogger    | 1        | 2      | Pretty much just copied and pasted with minor changes.                                                              |
| Total:        | 16       | 20     | This was a bigger assignment than we had anticipated, but we got everything done!                                   |

# UI and Design Choices
We decied to follow the example pretty closely to get as much functionality out of the program as possible. We made the buttons bigger and the font/text more "gamey" to simulate more of a game environment instead of a stock windows app, but other than that the UI/UX is pretty much like the example.

# Branching
We had one branch when Tate's schedule got busy and conflicted with Thatcher's. Thatcher put a lot of work in on the project overnight, so he branched and did all his work on that, then merged everything back to master. 
##### Branch: ThatcherAttemptsZoom
##### Commits:8c968b81d7bb4b1a1a3ac92a3d0fe1c17ab631ab -> 1cc88d7e9419dfb99e29d87f736a65f51c0fa243

# Testing
We tested things as we implemented new features. For example, when we wanted to test if we could connect to the server and receive food, we made the client auto-connect and saw if a bunch of colorful dots populated the screen. We followed this piece-by-piece process for the rest of the development phase and just tested as we went. We also had a series of tests we would run when we got our game running:
1. Create a crazy string name and connect
2. Eat enough food to be able to split
3. Split and have some splits get eaten.
4. Keep eating.
5. Get killed.
6. Reconnect with a different name.
7. Disconnect.

# Bottlenecks of our code
Drawing is definitely more of a bottleneck. Eventhough the network sends 3000 food bits at the start, redrawing the screen 30 times per second is quite strenuous and is hard to streamline, even with double-buffering. The networking code only works in sending bits and bytes across a TCP network, redrawing takes much more CPU and memory than that.
