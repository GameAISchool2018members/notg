# NotG

Simple machine learning agent

To speed up the process we took a simple runner game from Unity Asset Store - [Endless Runner - Sample Game](https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901).
We stripped the game from moving obstacles like rats and dogs, as well as 3 line obstacles to simplify amount of action character could take. This way we have eliminated jump and slide actions, leaving agent only with:
* Move Right
* Move Left
* Do Nothing

## [Video of the training process](https://youtu.be/JshzT8S9AKk)

## Sample learning output on early learning phase
```
INFO:unityagents: CharacterBrain: Step: 2000. Mean Reward: 1.910. Std of Reward: 1.261.
INFO:unityagents: CharacterBrain: Step: 4000. Mean Reward: 1.680. Std of Reward: 1.501.
INFO:unityagents: CharacterBrain: Step: 6000. Mean Reward: 2.056. Std of Reward: 2.087.
INFO:unityagents: CharacterBrain: Step: 8000. Mean Reward: 2.191. Std of Reward: 1.534.
INFO:unityagents: CharacterBrain: Step: 10000. Mean Reward: 2.249. Std of Reward: 1.847.
INFO:unityagents: CharacterBrain: Step: 12000. Mean Reward: 1.705. Std of Reward: 1.098.
INFO:unityagents: CharacterBrain: Step: 14000. Mean Reward: 2.959. Std of Reward: 2.673.
INFO:unityagents: CharacterBrain: Step: 16000. Mean Reward: 1.802. Std of Reward: 1.558.
INFO:unityagents: CharacterBrain: Step: 18000. Mean Reward: 3.374. Std of Reward: 2.961.
INFO:unityagents: CharacterBrain: Step: 20000. Mean Reward: 1.528. Std of Reward: 1.264.
INFO:unityagents: CharacterBrain: Step: 22000. Mean Reward: 1.940. Std of Reward: 1.232.
INFO:unityagents: CharacterBrain: Step: 24000. Mean Reward: 3.546. Std of Reward: 3.336.
INFO:unityagents: CharacterBrain: Step: 26000. Mean Reward: 2.658. Std of Reward: 1.996.
INFO:unityagents: CharacterBrain: Step: 28000. Mean Reward: 4.814. Std of Reward: 3.826.
INFO:unityagents: CharacterBrain: Step: 30000. Mean Reward: 3.313. Std of Reward: 2.212.
INFO:unityagents: CharacterBrain: Step: 32000. Mean Reward: 3.780. Std of Reward: 4.359.
INFO:unityagents: CharacterBrain: Step: 34000. Mean Reward: 3.966. Std of Reward: 3.007.
INFO:unityagents: CharacterBrain: Step: 36000. Mean Reward: 5.567. Std of Reward: 3.355.
INFO:unityagents: CharacterBrain: Step: 38000. Mean Reward: 3.762. Std of Reward: 2.396.
INFO:unityagents: CharacterBrain: Step: 40000. Mean Reward: 6.684. Std of Reward: 5.699.
INFO:unityagents: CharacterBrain: Step: 42000. Mean Reward: 4.272. Std of Reward: 2.991.
INFO:unityagents: CharacterBrain: Step: 44000. Mean Reward: 3.843. Std of Reward: 2.076.
INFO:unityagents: CharacterBrain: Step: 46000. Mean Reward: 5.650. Std of Reward: 3.612.
INFO:unityagents: CharacterBrain: Step: 48000. Mean Reward: 3.583. Std of Reward: 2.787.
INFO:unityagents:Saved Model
INFO:unityagents: CharacterBrain: Step: 50000. Mean Reward: 4.099. Std of Reward: 3.353.
INFO:unityagents: CharacterBrain: Step: 52000. Mean Reward: 4.274. Std of Reward: 2.839.
INFO:unityagents: CharacterBrain: Step: 54000. Mean Reward: 4.517. Std of Reward: 3.259.
INFO:unityagents: CharacterBrain: Step: 56000. Mean Reward: 3.712. Std of Reward: 4.000.
INFO:unityagents: CharacterBrain: Step: 58000. Mean Reward: 5.570. Std of Reward: 5.320.
INFO:unityagents: CharacterBrain: Step: 60000. Mean Reward: 5.687. Std of Reward: 4.208.
INFO:unityagents: CharacterBrain: Step: 62000. Mean Reward: 7.440. Std of Reward: 3.474.
INFO:unityagents: CharacterBrain: Step: 64000. Mean Reward: 7.141. Std of Reward: 5.005.
INFO:unityagents: CharacterBrain: Step: 66000. Mean Reward: 4.252. Std of Reward: 3.809.
INFO:unityagents: CharacterBrain: Step: 68000. Mean Reward: 4.504. Std of Reward: 2.472.
INFO:unityagents: CharacterBrain: Step: 70000. Mean Reward: 4.946. Std of Reward: 3.024.
INFO:unityagents: CharacterBrain: Step: 72000. Mean Reward: 4.446. Std of Reward: 3.601.
INFO:unityagents: CharacterBrain: Step: 74000. Mean Reward: 4.025. Std of Reward: 4.049.
INFO:unityagents: CharacterBrain: Step: 76000. Mean Reward: 4.843. Std of Reward: 4.013.
INFO:unityagents: CharacterBrain: Step: 78000. Mean Reward: 6.530. Std of Reward: 5.904.
INFO:unityagents: CharacterBrain: Step: 80000. Mean Reward: 5.820. Std of Reward: 4.959.
INFO:unityagents: CharacterBrain: Step: 82000. Mean Reward: 7.511. Std of Reward: 6.007.
INFO:unityagents: CharacterBrain: Step: 84000. Mean Reward: 4.670. Std of Reward: 3.068.
INFO:unityagents: CharacterBrain: Step: 86000. Mean Reward: 6.871. Std of Reward: 6.261.
INFO:unityagents: CharacterBrain: Step: 88000. Mean Reward: 4.507. Std of Reward: 3.844.
INFO:unityagents: CharacterBrain: Step: 90000. Mean Reward: 7.507. Std of Reward: 5.192.
INFO:unityagents: CharacterBrain: Step: 92000. Mean Reward: 4.381. Std of Reward: 2.097.
INFO:unityagents: CharacterBrain: Step: 94000. Mean Reward: 6.582. Std of Reward: 5.792.
INFO:unityagents: CharacterBrain: Step: 96000. Mean Reward: 4.220. Std of Reward: 2.720.
INFO:unityagents: CharacterBrain: Step: 98000. Mean Reward: 4.769. Std of Reward: 4.079.
INFO:unityagents:Saved Model
INFO:unityagents: CharacterBrain: Step: 100000. Mean Reward: 6.170. Std of Reward: 6.647.
INFO:unityagents: CharacterBrain: Step: 102000. Mean Reward: 6.157. Std of Reward: 5.352.
INFO:unityagents: CharacterBrain: Step: 104000. Mean Reward: 4.993. Std of Reward: 2.691.
INFO:unityagents: CharacterBrain: Step: 106000. Mean Reward: 4.744. Std of Reward: 5.756.
INFO:unityagents: CharacterBrain: Step: 108000. Mean Reward: 3.627. Std of Reward: 3.914.
INFO:unityagents: CharacterBrain: Step: 110000. Mean Reward: 5.560. Std of Reward: 4.181.
INFO:unityagents: CharacterBrain: Step: 112000. Mean Reward: 6.635. Std of Reward: 4.407.
INFO:unityagents: CharacterBrain: Step: 114000. Mean Reward: 4.301. Std of Reward: 2.676.
INFO:unityagents: CharacterBrain: Step: 116000. Mean Reward: 8.137. Std of Reward: 4.636.
INFO:unityagents: CharacterBrain: Step: 118000. Mean Reward: 5.687. Std of Reward: 2.665.
INFO:unityagents: CharacterBrain: Step: 120000. Mean Reward: 6.526. Std of Reward: 2.863.
INFO:unityagents: CharacterBrain: Step: 122000. Mean Reward: 6.331. Std of Reward: 4.035.
```