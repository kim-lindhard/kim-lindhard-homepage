#!/bin/bash

# Global installation instructions: (requires git 2.9 or later)
# NOTE: if you configure core.hooksPath, then git only runs the hooks from that directory (and ignores repo-specific hooks in .git/hooks/), but these pre-commit hooks contain a block at the end which executes a repo-specific pre-commit hook if it's present. It's a small hax that I think is pretty nice.
mkdir $HOME/.githooks

curl -fL -o $HOME/.githooks/pre-commit https://raw.githubusercontent.com/kim-lindhard/kim-lindhard-homepage/master/git-prevent-commit-to-master/are-you-sure-you-want-to-commit-to-main.sh
chmod +x $HOME/.githooks/pre-commit

git config --global core.hooksPath $HOME/.githooks