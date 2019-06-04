<div align="center">
  
<img src="https://i.loli.net/2019/06/03/5cf518fcd23cb88530.png" alt="icon" width="60" />

<h1>Sokoban Game</h1>


![](https://flat.badgen.net/badge/汇编语言/课程设计/yellow)
![](https://flat.badgen.net/badge/platform/Windows/blue?icon=windows)
![](https://flat.badgen.net/badge/license/MIT/red)

</div>

A Sokoban Game, implemented by WPF. Core logics implemented by x86 assembly at repo: [felinae98/SokobanASM](https://github.com/felinae98/SokobanASM).

> 俗称，推箱子。

## 界面

|                 Welcome Page (Normal Mode)                |                  Welcome Page (Dark Mode)                 |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/04/5cf686c3b0e6066673.png) | ![](https://i.loli.net/2019/06/04/5cf6863a4e5c477783.png) |

|                     Level Normal Mode                     |                      Level Dark Mode                      |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/04/5cf68740cabea28634.png) | ![](https://i.loli.net/2019/06/04/5cf6863a516ce60047.png) |

|                   Select Level (Played)                   |                  Select Level (Unplayed)                  |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/04/5cf6863a4e01f18224.png) | ![](https://i.loli.net/2019/06/04/5cf6881d6385769316.png) |

|                      Level Completed                      |                        Level Failed                       |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/04/5cf68639dcc7e93014.png) | ![](https://i.loli.net/2019/06/04/5cf687749d0f628419.png) |

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
