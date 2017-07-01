KeePassTimestampChanger
=================================

OVERVIEW
-----
KeePassTimestampChanger is a plug-in for KeePass 2.x which lets you modify the internal timestamps of an entry.
The internal timestamps are the creation time, last modification time and the last access time. You can use this
plug-in to "hide" the time you have changed an entry.

> Warning: KeePass' synchronization depends on correct timestamps. When changing timestamps using the plugin, synchronization may not work as expected anymore (e.g. entries may be overwritten by older copies). If you don't use the synchronization you don't have to worry.

INSTALLATION
-----
- Download from https://github.com/KN4CK3R/KeePassTimestampChanger/releases
- Copy the plug-in (KeePassTimestampChanger.plgx) into the KeePass plugin directory
- Start KeePass (and open a database)

HOW TO USE
-----
The KeePassTimestampChanger plugin integrates itself into the entry context menu of KeePass.
Just select one or more entries and click "Set Timestamps...". There is a new context menu on the history tab too.

![](https://abload.de/img/k15ssi5.jpg)

A new windows opens and lets you modify the timestamps.

![](https://abload.de/img/k20qsbs.jpg)

After you hit OK, the selected timestamps get set on the selected entries.
