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
