# Команды Git применёные в ходе работы 
- 'git add .'
- 'git commit -m <название коммита>'
- git push origin
- git pull 
- git push origin <название ветки >
- git branch <имя_ветки> 
- git checkout <имя_ветки>
- git merge <имя_ветки>

15
git log --graph --oneline --all : 
                                                
*   dc92e56 (HEAD -> master, origin/master, origin/HEAD) Merge pull request #2 from daslin02/Level-1
|\
| *   76a37b5 (origin/Level-1, Level-1) Merge branch 'master' into Level-1
| |\
| |/
|/|
* | 4eef2d4 Make ConfliactVariable
:
*   dc92e56 (HEAD -> master, origin/master, origin/HEAD) Merge pull request #2 from daslin02/Level-1
|\
| *   76a37b5 (origin/Level-1, Level-1) Merge branch 'master' into Level-1
| |\
| |/
|/|
* | 4eef2d4 Make ConfliactVariable
:


# task 35:

2679e8d (HEAD -> rebase-demo) Mark complete 20 from 20 task
da1cddd (origin/master, origin/HEAD, master) Complete level 2
0be812c mark complete Level-1
7d7832c complete level-1
dc92e56 Merge pull request #2 from daslin02/Level-1
76a37b5 (Level-1) Merge branch 'master' into Level-1
e9cae36 Make Conflicr Variable
4eef2d4 Make ConfliactVariable
e4141a3 Merge pull request #1 from daslin02/Level-1
7fee7c9 complete Task 14
e495a9c complete  Task 13
27a4320 Complete Task 12
d905660 Complete task 11
0c9bdf5 complete task 10
a378c1e Complete Task 9
a76a9fd Complete task 8
21460eb complete task 7
03b4c54 Complete Task 6
0be0993 complete task 4
ff53dcc Complete task 3
0157643 Make task 2
69f1e87 Create Radme
badb6a3 Translate to Rus


# Task 48


`git tag` v1.0.0

`git show v1.0.0` 
tag v1.0.0
Tagger: daslin <Artemserbakov26@gmail.com>
Date:   Sat Nov 14 15:30:57 2026 +0300

Release v1.0.0

commit 0f859f5d8b93917e648aec11c0e4176463ddee0b (HEAD -> master, tag: v1.0.0, origin/master, origin/HEAD)
Merge: da1cddd 76834b3
Author: daslin <111223333+daslin02@users.noreply.github.com>
Date:   Sat Nov 14 13:24:43 2026 +0300
