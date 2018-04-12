# Window Update Blocker
This is a service that blocks windows updates.

## Installation
1. Download the [latest release](https://github.com/tasadar2/WindowUpdateBlocker/releases/latest)
2. Unzip the release to a directory of your choosing
    ```powershell
    Expand-Archive -Path WindowsUpdateBlocker.zip -DestinationPath "C:\Program Files\Windows Update Blocker"
    ```
3. Install the service
    ```
    WindowsUpdateBlocker.exe install
    ```

## What it does
* Stops windows update service
* Disables windows update service

### Future features
* Disable windows update scheduled tasks
* Taskbar UI to allow easy enable/disable of windows updates
* Better logging

## Problem (*beware, there be rants ahead*)
The windows update mechanisms have become too opinionated. So much so, while long running processes are running on the computer, and taking 98% of the processing power, windows will deem it's updates more important than the task I took the time to start on the computer.

This results in failed long running tasks, closing of applications I intentionally left open, loss of context, and generally an increase of personal time to get back to the desired state.

Windows used to offer a fantastic option, "Download updates but let me choose whether to install them". This offered the world the ability to be notified that there were updates, but at the same time, not shutdown in the middle of playing a game to install the ever important updates.

Since no reasonable option is to end users without installing Windows Server, this program means to bridge that gap until Microsoft comes to their senses(like the other os's Android, IOS, OSX, <=Windows7, all? distros of linux, etc).