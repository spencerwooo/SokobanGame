# 🎮 Sokoban Game

![](https://flat.badgen.net/badge/汇编语言/课程设计/yellow)
![](https://flat.badgen.net/badge/platform/Windows/blue?icon=windows)
![](https://flat.badgen.net/badge/license/MIT/red)

> A Sokoban Game, implemented by WPF. Core logics implemented by x86 assembly. 
> 
> 俗称，推箱子。

## 界面

|                        Welcome Page                       |                   Level Select (Played)                   |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/02/5cf3d1e92bb7f49218.png) | ![](https://i.loli.net/2019/06/02/5cf3d1e9b854378941.png) |

|                  Level Select (Unplayed)                  |                         Main Game                         |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/02/5cf3be08237fc88178.png) | ![](https://i.loli.net/2019/06/02/5cf3be02e0d8666261.png) |


|                       Level Completed                     |                      Level Failed                         |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/02/5cf3d1e9edc1929006.png) | ![](https://i.loli.net/2019/06/02/5cf3d1eaab0a713963.png) |

## 编译与运行

1. 在 Visual Studio Installer 中选择「.NET 桌面开发」安装 C# 和 WPF 开发组件包

![](https://i.loli.net/2019/06/02/5cf3383d697f782151.png)

2. 使用 Visual Studio 2019 打开项目（`sln` 文件）
3. 选择「Debug - x86」环境
4. 点击开始运行（不调试）

## 技术栈

### 界面

在 .NET 环境下，使用 WPF 构建的桌面应用程序。

### 核心业务逻辑

使用 Windows 平台下，`.386` 模式下编写的 x86 汇编。


---

🎮 **Sokoban Game** ©2019 Team Offline Flower. Released under the MIT License.

Authored by Spencer Woo. Maintained by [@Felinae Tang](https://github.com/felinae98), [@Garvey Lau](https://github.com/garvey98) and [@Liz Li](https://github.com/LiZ-Samsara). Team Offline Flower, all rights reserved.

[@Blog](https://spencerwoo.com/) · [ⒿJike](https://web.okjike.com/user/4DDA0425-FB41-4188-89E4-952CA15E3C5E/post) · [@GitHub](https://github.com/spencerwooo)
