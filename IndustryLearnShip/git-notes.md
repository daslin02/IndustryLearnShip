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



# Task 49

---
`git reflog` до начала работы 
---


f5a93a4 (HEAD -> Level-3) HEAD@{0}: commit: Exucute task #49 Create commit for 

cf92006 (origin/Level-3) HEAD@{1}: checkout: moving from master to Level-3

7b69014 (origin/master, origin/HEAD, master) HEAD@{2}: pull --progress --no-edi

460294b HEAD@{3}: checkout: moving from Level-3 to master

cf92006 (origin/Level-3) HEAD@{4}: pull --progress --no-edit --no-stat --recurs

45d871d HEAD@{5}: checkout: moving from master to Level-3

460294b HEAD@{6}: checkout: moving from Level-3 to master

45d871d HEAD@{7}: checkout: moving from master to Level-3

460294b HEAD@{8}: commit: complete task 48

0f859f5 (tag: v1.0.0) HEAD@{9}: checkout: moving from Level-3 to master

45d871d HEAD@{10}: commit: Complete task 47

---

`git reflog` после удаения
---


cf92006 (HEAD -> Level-3, origin/Level-3) HEAD@{0}: reset: moving to HEAD~1

f5a93a4 HEAD@{1}: commit: Exucute task #49 Create commit for delete

cf92006 (HEAD -> Level-3, origin/Level-3) HEAD@{2}: checkout: moving from maste

7b69014 (origin/master, origin/HEAD, master) HEAD@{3}: pull --progress --no-edi

460294b HEAD@{4}: checkout: moving from Level-3 to master

cf92006 (HEAD -> Level-3, origin/Level-3) HEAD@{5}: pull --progress --no-edit -

45d871d HEAD@{6}: checkout: moving from master to Level-3

460294b HEAD@{7}: checkout: moving from Level-3 to master

45d871d HEAD@{8}: checkout: moving from master to Level-3

460294b HEAD@{9}: commit: complete task 48

0f859f5 (tag: v1.0.0) HEAD@{10}: checkout: moving from Level-3 to master



---
`git reflog` после восстановления
--

f5a93a4 (HEAD -> Level-3) HEAD@{0}: reset: moving to f5a93a4

cf92006 (origin/Level-3) HEAD@{1}: reset: moving to HEAD~1

f5a93a4 (HEAD -> Level-3) HEAD@{2}: commit: Exucute task #49 Create commit for 

cf92006 (origin/Level-3) HEAD@{3}: checkout: moving from master to Level-3

7b69014 (origin/master, origin/HEAD, master) HEAD@{4}: pull --progress --no-edi

460294b HEAD@{5}: checkout: moving from Level-3 to master

cf92006 (origin/Level-3) HEAD@{6}: pull --progress --no-edit --no-stat --recurs

45d871d HEAD@{7}: checkout: moving from master to Level-3

460294b HEAD@{8}: checkout: moving from Level-3 to master

45d871d HEAD@{9}: checkout: moving from master to Level-3

460294b HEAD@{10}: commit: complete task 48

0f859f5 (tag: v1.0.0) HEAD@{11}: checkout: moving from Level-3 to master

45d871d HEAD@{12}: commit: Complete task 47

79e5a4b HEAD@{13}: pull --progress --no-edit --no-stat --recurse-submodules=no 

0d4a0ab HEAD@{14}: checkout: moving from squash-deemo to Level-3

006ef30 (origin/squash-deemo, squash-deemo) HEAD@{15}: commit: Complete task 46

---
`git log --oneline`
---
f5a93a4 (HEAD -> Level-3) HEAD@{0}: reset: moving to f5a93a4

cf92006 (origin/Level-3) HEAD@{1}: reset: moving to HEAD~1

f5a93a4 (HEAD -> Level-3) HEAD@{2}: commit: Exucute task #49

cf92006 (origin/Level-3) HEAD@{3}: checkout: moving from mas

7b69014 (origin/master, origin/HEAD, master) HEAD@{4}: pull 

460294b HEAD@{5}: checkout: moving from Level-3 to master

cf92006 (origin/Level-3) HEAD@{6}: pull --progress --no-edit

45d871d HEAD@{7}: checkout: moving from master to Level-3

460294b HEAD@{8}: checkout: moving from Level-3 to master

45d871d HEAD@{9}: checkout: moving from master to Level-3

460294b HEAD@{10}: commit: complete task 48

0f859f5 (tag: v1.0.0) HEAD@{11}: checkout: moving from Level

45d871d HEAD@{12}: commit: Complete task 47

79e5a4b HEAD@{13}: pull --progress --no-edit --no-stat --rec

0d4a0ab HEAD@{14}: checkout: moving from squash-deemo to Lev

006ef30 (origin/squash-deemo, squash-deemo) HEAD@{15}: commi

