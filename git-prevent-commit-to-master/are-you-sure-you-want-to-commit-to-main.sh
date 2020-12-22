#!/bin/bash

currentBranch="$(git rev-parse --abbrev-ref HEAD)"

if [[ "$currentBranch" != "master" && "$currentBranch" != "main" ]]; then
  [[ "$0" = "$BASH_SOURCE" ]] && exit 1 || return 1;
fi

echo "You are about to commit to $currentBranch. Are you sure? [yes/No]"

exec < /dev/tty

while read -n 1 -r yn; do
  if [ "$yn" = "" ]; then
      yn='N'
  fi
  case $yn in
      [Yy] ) break;;
      [Nn] ) echo;[[ "$0" = "$BASH_SOURCE" ]] && exit 1 || return 1;;
      * ) echo "Please answer y (yes) or n (no):" && continue;
  esac
done

exec <&-