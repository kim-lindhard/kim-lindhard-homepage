# Git prevent commit to master
Many projects and organizations have a policy of not committing directly to the master/main branch but only allowing to commit work to feature branches and then merge the feature branch into the master/main branch.  
This is usually enforced by protected master/main branches that restrict the organization's members from pushing to master/main. Protected branches for private repositories are part of the Team plan on Github which some organizations choose not to buy in order to save money. This exposes the organization to the risk of accidentally committing directly to master/main.

Thankfully, Git has 2 build-in features that we can easily use to protect us from accidentally committing to the master/main branch:

1. A pre-commit hook (a script that runs every time we try to commit) that can check if we are on a master or main branch.
1. A global Git configuration that allows us to use the same Git hook for all the repositories on our machine.

## The pre-commit hook script

The script: [are-you-sure-you-want-to-commit-to-main.sh](https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh) 

checks if you are on a branch named `master` or `main`, gives you a warning if you are, and asks if you would like to proceed with your current commit. This stops us from accidentally committing to master/main but allows us the flexibility to willfully commit to master/main when we choose to. 

## Installation

Paste the following into a shell terminal (OS X Terminal, Linux bash shell or git bash on Windows):

``` shell
source <(curl -s https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/install-are-you-sure-you-want-to-commit-to-main.sh)
```

This will:
1. Create a global [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks) folder
1. Download the script [are-you-sure-you-want-to-commit-to-main.sh](https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh) into the global Git hooks directory under the name `pre-commit`
1. Configure Git globally to use the global hooks directory for all [git hooks](https://git-scm.com/book/en/v2/Customizing-Git-Git-Hooks)

## Limitations

- The script only stops you if you are committing from a shell. If you are using an integrated development environment (IDE),  you will be given no warning when you commit to master.
- No Git hooks in your repositories will be triggered when the global Git setting `core.hooksPath` has been set and a global Git hook exists. This could be fixed by letting the global hook call the hook of the same name in the repository you are operating in.