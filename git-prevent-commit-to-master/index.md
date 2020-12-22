# Git prevent commit to master

Many projects and organizations have a policy of not committing to directly to master/main but only allowing committing work to feature branches and then merging the feature branch into the master/main branch.  
This is usually enforced by protected master/main branches that restricts the organization members from pushing to master/main. Protected branches for private repositories are a part of the Team plan on Github which some organizations choose not to buy to save money. This exposes the organization to the risk of accidentally committing directly to master/main.

Thankfully Git have 2 build in features we can easily use to protect us from accidentally committing to the master/main branch:

1. A pre commit hook (a script that runs every time we try to commit) that can check if we are on a master or main branch.
1. A global git configuration that allows us to use the same git hook for all the repositories on our machine.

## The script

The script: [are-you-sure-you-want-to-commit-to-main.sh](https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh) 

Checks if you are on a branch named `master` or `main`, gives you a warning if so and ask if you would like to proceed with you current commit. This stops us from accidentally committing to master/main but allows us the flexibility to wilfully commit to master/main when we choose to. 

## Installation

Paste the following into a shell terminal (OS X Terminal, Linux bash shell or git bash on Windows):

``` shell
source <(curl -s https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/install-are-you-sure-you-want-to-commit-to-main.sh)
```

This will:
1. Create a global [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks) folder
1. download the scripts [are-you-sure-you-want-to-commit-to-main.sh](https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh) into the global git hooks directory under the name `pre-commit`
1. Configure git globally to use the global hooks directory for all [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks)