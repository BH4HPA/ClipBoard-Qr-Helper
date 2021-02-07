# ClipBoard Qr Helper 剪贴板二维码助手

It will scan the image which on the clipboard automatically.

它将自动识别剪贴板上刚复制的二维码图片。

## Environment 环境

Windows 10, .NET Framework 4.7. - test passed. 测试通过。

## Usage 使用方法

[简体中文（中国）](https://github.com/ENDsoft233/ClipBoard-Qr-Helper/blob/main/readme.md#zh_cn) | [English(US)](https://github.com/ENDsoft233/ClipBoard-Qr-Helper/blob/main/readme.md#en_us)

### zh_cn

下载 Release 中的 Setup.exe 或 Portable.zip。分别双击打开或解压缩并打开 `ClipBoard Qr Helper.exe` 。

如果环境适合，软件将推送第一条 Toast Notification ，你可以通过添加启动项 `--silence` 禁用该通知。

将图片或者图片文件复制到剪贴板，软件将自动识别二维码，如果识别出结果，将自动推送通知，反之则无操作。

建议搭配截图软件使用，先截出需要识别的二维码放置在剪贴板，再使用本软件识别。

识别可以暂停，右击托盘中的软件图标即可暂停识别。

托盘菜单中的开机自启动勾选后将在开始菜单的启动目录新建一个本软件的快捷方式用于自启动。该快捷方式指向 `ClipBoard Qr Helper.exe` ，所以不会检查更新。

双击托盘图标可以快速退出。

### en_us

Download the setup.exe or Portable.zip in release, and double click to open or unzip the zip then open `ClipBoard Qr Helper.exe` .

If your Environment is ok, the program will push a toast notification. You can use the `--silence` arg to disable the notification.

Copy the image or image file, the program will automatically scan the image, and push the notification if result is not empty.

Double click the icon in taskbar will exit the program.

## Thanks Lists 鸣谢
 
 - https://github.com/20154530/ToastHelper providing the implementation of the Toast Notification. 提供原生通知支持。
 
 - https://github.com/zxing/zxing providing the implementation of scaning the qr code. 提供本地二维码识别支持。
