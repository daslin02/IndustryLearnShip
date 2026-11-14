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

# Task 46:

`git stash list` **после сокрытия через **  `git stash`

stash@{0}: WIP on Level-3: 678ed44 complete task 45


`git stash list` **после раскрытия через **  `git stash pop`

` ` - пустой
# Task 47


`git log --oneline` до squash 

e8ca4bf create small commit number 3

6a40370 create small commit number 2

fcf92e3 Added Headers of Task 47

0d4a0ab (origin/Level-3, Level-3) complete task 46

678ed44 complete task 45

3edb24e complete task 44

b2c64ef complete task 43

15141ee complete task 42


`git log --oneline` после squash 
c335d31 (HEAD -> squash-deemo) Added Headers of Task 47

0d4a0ab (origin/Level-3, Level-3) complete task 46

678ed44 complete task 45

3edb24e complete task 44

b2c64ef complete task 43

15141ee complete task 42

c62b0dd complete task 41

86f520b complete task 40

e0a9cc0 complete task 39

f1eaccd complete task 38

528cbd1 complete task 37

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
=======



