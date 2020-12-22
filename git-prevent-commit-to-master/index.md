# Git prevent commit to master


## What we set out to do

## The script

## installation

Paste the following into a shell terminal (OS X Terminal, Linux bash shell or git bash on windows):

``` shell
source <(curl -s https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/install-are-you-sure-you-want-to-commit-to-main.sh)
```

This will:
1. Create a global [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks) folder
1. download the scripts [are-you-sure-you-want-to-commit-to-main.sh](https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh) into the global git hooks directory
1. Configure git globally to use the global hooks directory for [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks)