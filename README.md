# 3DMahjong
这个项目是使用unity开发的3d麻将棋牌游戏，参考腾讯的欢乐麻将手游制作。 目前开发的是游戏前端，对游戏采取了抽象，包括 麻将机的抽象，各种打牌动作的解耦，使得在麻将机上的打牌 摸牌， 整理牌，等动作，都分离解耦，和具体的麻将规则不相关，以命令形式驱动各种动作，  之后采用了消息驱动命令，驱动麻将机发动各种动作， 在这个层次之上，再附加麻将规则层，按照一定的地方麻将逻辑，发送动作命令给麻将机，完成整个核心游戏逻辑，按这个框架，可以直接录制一场麻将的打牌录像，只要保存对应动作命令，再重放即可。 涉及到的相关技术和知识点包括了 游戏框架， 图形学方面的内容， 自写shader部分，unity模型的动作制作，ps贴图绘制，美术资源的获取，c#编程，3dmax制作模型，贴图，骨骼动画，资源管理，内存优化
