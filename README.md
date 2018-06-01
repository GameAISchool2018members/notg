# NotG

## Who we are?

![Team - Something Epic](https://github.com/GameAISchool2018members/notg/blob/master/Img/Team%20(SomethingEpic).JPG)
We are a bunch of 1st Internation school on AI that took place in Chania, Greece.
We are from Italy, Cyprus, Ukraine, Finland and Serbia.

Simple machine learning agent

To speed up the process we took a simple runner game from Unity Asset Store - [Endless Runner - Sample Game](https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901).
We stripped the game from moving obstacles like rats and dogs, as well as 3 line obstacles to simplify amount of action character could take. This way we have eliminated jump and slide actions, leaving agent only with:
* Move Right
* Move Left
* Do Nothing

Training was done with 500.000 iterations.

## [Video of the training process](https://youtu.be/JshzT8S9AKk)
## [Video of the AI play after training](https://youtu.be/9g5YMTVhbQw)

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
INFO:unityagents:Saved Model
INFO:unityagents: CharacterBrain: Step: 50000. Mean Reward: 3.822. Std of Reward: 3.516.
INFO:unityagents: CharacterBrain: Step: 52000. Mean Reward: 5.106. Std of Reward: 5.269.
INFO:unityagents: CharacterBrain: Step: 54000. Mean Reward: 5.384. Std of Reward: 4.281.
INFO:unityagents: CharacterBrain: Step: 56000. Mean Reward: 4.640. Std of Reward: 3.875.
INFO:unityagents: CharacterBrain: Step: 58000. Mean Reward: 4.337. Std of Reward: 2.449.
INFO:unityagents: CharacterBrain: Step: 60000. Mean Reward: 5.226. Std of Reward: 4.125.
INFO:unityagents: CharacterBrain: Step: 62000. Mean Reward: 5.290. Std of Reward: 3.312.
INFO:unityagents: CharacterBrain: Step: 64000. Mean Reward: 4.084. Std of Reward: 5.213.
INFO:unityagents: CharacterBrain: Step: 66000. Mean Reward: 6.030. Std of Reward: 4.444.
INFO:unityagents: CharacterBrain: Step: 68000. Mean Reward: 7.019. Std of Reward: 4.444.
INFO:unityagents: CharacterBrain: Step: 70000. Mean Reward: 6.013. Std of Reward: 4.235.
INFO:unityagents: CharacterBrain: Step: 72000. Mean Reward: 4.774. Std of Reward: 4.404.
INFO:unityagents: CharacterBrain: Step: 74000. Mean Reward: 9.015. Std of Reward: 7.550.
INFO:unityagents: CharacterBrain: Step: 76000. Mean Reward: 6.122. Std of Reward: 4.918.
INFO:unityagents: CharacterBrain: Step: 78000. Mean Reward: 8.420. Std of Reward: 7.804.
INFO:unityagents: CharacterBrain: Step: 80000. Mean Reward: 7.060. Std of Reward: 4.621.
INFO:unityagents: CharacterBrain: Step: 82000. Mean Reward: 8.337. Std of Reward: 6.968.
INFO:unityagents: CharacterBrain: Step: 84000. Mean Reward: 6.440. Std of Reward: 5.619.
INFO:unityagents: CharacterBrain: Step: 86000. Mean Reward: 5.663. Std of Reward: 4.642.
INFO:unityagents: CharacterBrain: Step: 88000. Mean Reward: 3.820. Std of Reward: 1.117.
INFO:unityagents: CharacterBrain: Step: 90000. Mean Reward: 5.429. Std of Reward: 2.566.
INFO:unityagents: CharacterBrain: Step: 92000. Mean Reward: 8.399. Std of Reward: 4.406.
INFO:unityagents: CharacterBrain: Step: 94000. Mean Reward: 7.563. Std of Reward: 4.999.
INFO:unityagents: CharacterBrain: Step: 96000. Mean Reward: 6.890. Std of Reward: 4.091.
INFO:unityagents: CharacterBrain: Step: 98000. Mean Reward: 9.121. Std of Reward: 10.715.
INFO:unityagents:Saved Model
INFO:unityagents: CharacterBrain: Step: 100000. Mean Reward: 3.925. Std of Reward: 3.513.
INFO:unityagents: CharacterBrain: Step: 102000. Mean Reward: 4.949. Std of Reward: 3.771.
INFO:unityagents: CharacterBrain: Step: 104000. Mean Reward: 8.780. Std of Reward: 8.255.
INFO:unityagents: CharacterBrain: Step: 106000. Mean Reward: 6.701. Std of Reward: 4.130.
INFO:unityagents: CharacterBrain: Step: 108000. Mean Reward: 6.773. Std of Reward: 5.564.
INFO:unityagents: CharacterBrain: Step: 110000. Mean Reward: 6.157. Std of Reward: 4.728.
INFO:unityagents: CharacterBrain: Step: 112000. Mean Reward: 9.065. Std of Reward: 3.720.
INFO:unityagents: CharacterBrain: Step: 114000. Mean Reward: 5.530. Std of Reward: 3.836.
INFO:unityagents: CharacterBrain: Step: 116000. Mean Reward: 4.953. Std of Reward: 2.082.
INFO:unityagents: CharacterBrain: Step: 118000. Mean Reward: 14.168. Std of Reward: 11.792.
INFO:unityagents: CharacterBrain: Step: 120000. Mean Reward: 8.159. Std of Reward: 7.540.
INFO:unityagents: CharacterBrain: Step: 122000. Mean Reward: 5.499. Std of Reward: 6.070.
INFO:unityagents: CharacterBrain: Step: 124000. Mean Reward: 6.553. Std of Reward: 4.134.
INFO:unityagents: CharacterBrain: Step: 126000. Mean Reward: 5.507. Std of Reward: 3.337.
INFO:unityagents: CharacterBrain: Step: 128000. Mean Reward: 6.729. Std of Reward: 4.991.
INFO:unityagents: CharacterBrain: Step: 130000. Mean Reward: 5.150. Std of Reward: 6.224.
INFO:unityagents: CharacterBrain: Step: 132000. Mean Reward: 4.946. Std of Reward: 2.949.
INFO:unityagents: CharacterBrain: Step: 134000. Mean Reward: 5.493. Std of Reward: 3.963.
INFO:unityagents: CharacterBrain: Step: 136000. Mean Reward: 5.587. Std of Reward: 3.898.
INFO:unityagents: CharacterBrain: Step: 138000. Mean Reward: 2.990. Std of Reward: 0.000.
INFO:unityagents: CharacterBrain: Step: 140000. Mean Reward: 13.782. Std of Reward: 22.780.
INFO:unityagents: CharacterBrain: Step: 142000. Mean Reward: 8.540. Std of Reward: 5.683.
INFO:unityagents: CharacterBrain: Step: 144000. Mean Reward: 6.860. Std of Reward: 5.391.
INFO:unityagents: CharacterBrain: Step: 146000. Mean Reward: 6.737. Std of Reward: 5.902.
INFO:unityagents: CharacterBrain: Step: 148000. Mean Reward: 5.112. Std of Reward: 3.703.
INFO:unityagents:Saved Model
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