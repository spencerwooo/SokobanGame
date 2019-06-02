# Sokoban Game

A Sokoban Game implemented with WPF, and Assembly in its core.

> 俗称，推箱子。

|                        Welcome Page                       |                   Level Select (Played)                   |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/02/5cf336210110959332.png) | ![](https://i.loli.net/2019/06/02/5cf33621a490a47104.png) |

|                  Level Select (Unplayed)                  |                         Main Game                         |
|:---------------------------------------------------------:|:---------------------------------------------------------:|
| ![](https://i.loli.net/2019/06/02/5cf33621a49ff59156.png) | ![](https://i.loli.net/2019/06/02/5cf33621b287e12879.png) |

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
