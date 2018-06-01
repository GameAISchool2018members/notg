# NotG

## Who we are?

![Team - Something Epic](https://github.com/GameAISchool2018members/notg/blob/master/Img/Team%20(SomethingEpic).JPG)
We are a bunch of students of the **1-st International School on AI and Games** that took place in Chania, Greece.
We come from Italy, Cyprus, Ukraine, Finland and Serbia with different background and without any practical knowledge how to train ML-Agents.

We've implemented simple machine learning agent in a chase to teach him how to play ruuner games.

To speed up the process we took a simple runner game from Unity Asset Store - [Endless Runner - Sample Game](https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901):
![Team - Something Epic](https://github.com/GameAISchool2018members/notg/blob/master/Img/InGame.png)

We stripped the game from moving obstacles like rats and dogs, as well as 3 line obstacles to simplify amount of action character could take. This way we have eliminated jump and slide actions, leaving agent only with:
* Move Right
* Move Left
* and Do Nothing

Training was done with 500.000 iterations.
Agent took into account only rewards for distance, the further it goes - the bigger reward. And a negative rewards for hitting the obstacles.

## [Video of the training process](https://youtu.be/JshzT8S9AKk)
## [Video of the AI play after training](https://youtu.be/4bEwlHhhq8k)

## Sample learning output on early learning phase
```
INFO:unityagents: CharacterBrain: Step: 2000. Mean Reward: 2.422. Std of Reward: 1.675.
INFO:unityagents: CharacterBrain: Step: 4000. Mean Reward: 2.012. Std of Reward: 1.696.
INFO:unityagents: CharacterBrain: Step: 6000. Mean Reward: 1.750. Std of Reward: 1.219.
INFO:unityagents: CharacterBrain: Step: 8000. Mean Reward: 1.829. Std of Reward: 2.069.
INFO:unityagents: CharacterBrain: Step: 10000. Mean Reward: 3.326. Std of Reward: 2.997.
INFO:unityagents: CharacterBrain: Step: 12000. Mean Reward: 3.955. Std of Reward: 3.138.
INFO:unityagents: CharacterBrain: Step: 14000. Mean Reward: 2.504. Std of Reward: 1.636.
INFO:unityagents: CharacterBrain: Step: 16000. Mean Reward: 4.357. Std of Reward: 3.448.
INFO:unityagents: CharacterBrain: Step: 18000. Mean Reward: 1.851. Std of Reward: 2.845.
INFO:unityagents: CharacterBrain: Step: 20000. Mean Reward: 2.900. Std of Reward: 2.642.
INFO:unityagents: CharacterBrain: Step: 22000. Mean Reward: 3.627. Std of Reward: 2.809.
INFO:unityagents: CharacterBrain: Step: 24000. Mean Reward: 4.446. Std of Reward: 2.255.
INFO:unityagents: CharacterBrain: Step: 26000. Mean Reward: 3.097. Std of Reward: 1.674.
INFO:unityagents: CharacterBrain: Step: 28000. Mean Reward: 2.242. Std of Reward: 1.590.
INFO:unityagents: CharacterBrain: Step: 30000. Mean Reward: 2.950. Std of Reward: 2.385.
INFO:unityagents: CharacterBrain: Step: 32000. Mean Reward: 4.199. Std of Reward: 2.444.
INFO:unityagents: CharacterBrain: Step: 34000. Mean Reward: 5.285. Std of Reward: 4.332.
INFO:unityagents: CharacterBrain: Step: 36000. Mean Reward: 4.005. Std of Reward: 2.820.
INFO:unityagents: CharacterBrain: Step: 38000. Mean Reward: 4.403. Std of Reward: 4.486.
INFO:unityagents: CharacterBrain: Step: 40000. Mean Reward: 3.208. Std of Reward: 2.308.
INFO:unityagents: CharacterBrain: Step: 42000. Mean Reward: 4.825. Std of Reward: 4.043.
INFO:unityagents: CharacterBrain: Step: 44000. Mean Reward: 3.336. Std of Reward: 2.643.
INFO:unityagents: CharacterBrain: Step: 46000. Mean Reward: 5.557. Std of Reward: 6.635.
INFO:unityagents: CharacterBrain: Step: 48000. Mean Reward: 5.457. Std of Reward: 3.026.
...
INFO:unityagents: CharacterBrain: Step: 150000. Mean Reward: 11.025. Std of Reward: 9.662.
INFO:unityagents: CharacterBrain: Step: 152000. Mean Reward: 4.550. Std of Reward: 2.341.
INFO:unityagents: CharacterBrain: Step: 154000. Mean Reward: 8.516. Std of Reward: 11.359.
INFO:unityagents: CharacterBrain: Step: 156000. Mean Reward: 7.023. Std of Reward: 8.817.
INFO:unityagents: CharacterBrain: Step: 158000. Mean Reward: 9.070. Std of Reward: 5.136.
INFO:unityagents: CharacterBrain: Step: 160000. Mean Reward: 6.232. Std of Reward: 4.770.
INFO:unityagents: CharacterBrain: Step: 162000. Mean Reward: 5.333. Std of Reward: 4.377.
INFO:unityagents: CharacterBrain: Step: 164000. Mean Reward: 14.142. Std of Reward: 8.961.
INFO:unityagents: CharacterBrain: Step: 166000. Mean Reward: 3.953. Std of Reward: 3.626.
INFO:unityagents: CharacterBrain: Step: 168000. Mean Reward: 5.153. Std of Reward: 2.697.
INFO:unityagents: CharacterBrain: Step: 170000. Mean Reward: 14.412. Std of Reward: 7.882.
INFO:unityagents: CharacterBrain: Step: 172000. Mean Reward: 4.682. Std of Reward: 4.136.
INFO:unityagents: CharacterBrain: Step: 174000. Mean Reward: 8.257. Std of Reward: 5.172.
INFO:unityagents: CharacterBrain: Step: 176000. Mean Reward: 4.220. Std of Reward: 1.788.
INFO:unityagents: CharacterBrain: Step: 178000. Mean Reward: 9.001. Std of Reward: 8.366.
INFO:unityagents: CharacterBrain: Step: 180000. Mean Reward: 4.568. Std of Reward: 2.384.
INFO:unityagents: CharacterBrain: Step: 182000. Mean Reward: 9.536. Std of Reward: 6.016.
INFO:unityagents: CharacterBrain: Step: 184000. Mean Reward: 6.125. Std of Reward: 4.739.
INFO:unityagents: CharacterBrain: Step: 186000. Mean Reward: 4.211. Std of Reward: 4.644.
INFO:unityagents: CharacterBrain: Step: 188000. Mean Reward: 30.350. Std of Reward: 8.580.
INFO:unityagents: CharacterBrain: Step: 190000. Mean Reward: 11.216. Std of Reward: 13.051.
INFO:unityagents: CharacterBrain: Step: 192000. Mean Reward: 40.100. Std of Reward: 15.990.
INFO:unityagents: CharacterBrain: Step: 194000. Mean Reward: 3.140. Std of Reward: 2.531.
INFO:unityagents: CharacterBrain: Step: 196000. Mean Reward: 10.850. Std of Reward: 4.859.
INFO:unityagents: CharacterBrain: Step: 198000. Mean Reward: 4.805. Std of Reward: 5.226.
```

![Tensorflow board](https://github.com/GameAISchool2018members/notg/blob/master/Img/TensorFlow%20board.png)

## What have we achieved?
Due to the fact that we were not able to run any CUDA based learning, all the training took place on CPU with limited amount of iterations. 
During the training we've observed agent to score as high as 11.000 points and around 2.500 points on after learning was completed.

Agent is still feels dumb at times, but sometimes he is surprisingly clever in avoiding obstacles. In general we are really amazed on what Unity ML-Agent learning framework can do, and we are really happy that our agent is able to avoid any obstacles in such a short time.