# LoL-item-sets

<hr/>

**This branch is currently a work in progress of the new version 1.0. It will be written using [Electron](https://electron.atom.io).
Please refer to the [TODO section](#TODO) for more details of the upcoming changes.**

<hr/>

[![Downloads](https://img.shields.io/github/downloads/Ilshidur/LoL-item-sets/total.svg)](https://github.com/Ilshidur/LoL-item-sets/releases) [![Slack Status](https://slack.lol-item-sets-generator.org/badge.svg)](https://slack.lol-item-sets-generator.org/)

Download the best -generated- League of Legends recommended items from the website https://lol-item-sets-generator.org.

[CHANGE LOG](https://github.com/Ilshidur/LoL-item-sets/blob/master/CHANGELOG.md)

## Reporting a bug

* Bug on the **application** : [submit here](https://github.com/Ilshidur/LoL-item-sets/issues/new)
* Bug on the **item sets** : [submit here](https://github.com/Ilshidur/feeder.lol-item-sets-generator.org/issues/new)

## How to use

***TODO***

## Requirements

***TODO***

## TODO

> [Work in progress](https://github.com/orgs/league-of-legends-devs/projects/1)

* Rewrite the app using [Electron](https://electron.atom.io), [React](https://facebook.github.io/react) and [Redux](http://redux.js.org)
* Download the default item sets on user action. If the user is authenticated, also download his custom/favorite sets (no deletion of the current item sets)
* Show the current website patch
* Show the news section of the website
* Show the current user's downloads/uploads count
* User option : change the item sets directory
* User option : authenticate to the website database
* Use WebSockets for the synchronisation with the website :
  * Event from the website makes the application automaticaly download a selected custom item set (if the user is authenticated)
* User option : upload the current item sets and save them to the website database (if the user is authenticated)
* User option : run the application on system start
* User option : minimize the application in system tray if the user closes it
* User option : automatically update the local item sets regularly, with a timer defined by the user (min.: 60s)
* Links :
  * Website : home, user account
  * GitHub repository
  * Change log
  * Issue tracker (GitHub)
  * Donations
* Multiple languages
* Pop-up notifying the user when :
  * a new version comes out
  * a new patch comes out

## Contact

Contact me at [ilshidur@lol-item-sets-generator.org](mailto:ilshidur@lol-item-sets-generator.org) or [ilshidur@gmail.com](mailto:ilshidur@gmail.com).

## Contributors

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
| [<img src="https://avatars2.githubusercontent.com/u/6564012?v=3" width="100px;"/><br /><sub>Nicolas COUTIN</sub>](https://www.nicolas-coutin.fr)<br />[💬](#question-Ilshidur "Answering Questions") [💻](https://github.com/Ilshidur/LoL-item-sets/commits?author=Ilshidur "Code") [🎨](#design-Ilshidur "Design") [📖](https://github.com/Ilshidur/LoL-item-sets/commits?author=Ilshidur "Documentation") [👀](#review-Ilshidur "Reviewed Pull Requests") [🔧](#tool-Ilshidur "Tools") [🚇](#infra-Ilshidur "Infrastructure (Hosting, Build-Tools, etc)") | [<img src="https://avatars2.githubusercontent.com/u/1056963?v=3" width="100px;"/><br /><sub>Melchor Garau Madrigal</sub>](http://melchor9000.me)<br />[💬](#question-melchor629 "Answering Questions") [🐛](https://github.com/Ilshidur/LoL-item-sets/issues?q=author%3Amelchor629 "Bug reports") [💻](https://github.com/Ilshidur/LoL-item-sets/commits?author=melchor629 "Code") [🎨](#design-melchor629 "Design") [📖](https://github.com/Ilshidur/LoL-item-sets/commits?author=melchor629 "Documentation") | [<img src="https://avatars0.githubusercontent.com/u/510057?v=3" width="100px;"/><br /><sub>corylulu</sub>](https://github.com/corylulu)<br />[🐛](https://github.com/Ilshidur/LoL-item-sets/issues?q=author%3Acorylulu "Bug reports") [💻](https://github.com/Ilshidur/LoL-item-sets/commits?author=corylulu "Code") |
| :---: | :---: | :---: |
<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

The MIT License (MIT)

Copyright (c) 2017 **Nicolas COUTIN**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
