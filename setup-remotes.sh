#!/bin/bash

if [ "$#" -ne 4 ]; then
  echo "** ERROR: Invalid number of parameter"
  echo "./setup-remotes.sh MSE-WS$(date +%y)-SWE <Main repo> <Second repo> <Username>"
  echo ""
  echo "MSE-WS$(date +%y)-SWE - Name of the repo. Must include the current year."
  echo "Main repo    - if-number of your groups main repository. Example: if99x9999"
  echo "Second repo  - if-number of your groups second repository. Example: if99x0000"
  echo "Username     - if-number of your user name. Example: if99x9999"
  echo ""
  echo "Example"
  echo "-------"
  echo "On your PC:"
  echo "./setup-remotes.sh MSE-WS$(date +%y)-SWE if99x9999 if99x0000 if99x9999"
  echo ""
  echo "On your colleagues PC:"
  echo "./setup-remotes.sh MSE-WS$(date +%y)-SWE if99x9999 if99x0000 if99x0000"
  exit 1;
fi

if [[ ! $1 =~ MSE-WS[0-9][0-9]-SWE$ ]]; then
  echo "** ERROR: Parameter 1 is not in a valid format! Must be MSE-WS??-SWE."
  echo "Example: MSE-WS$(date +%y)-SWE"
  exit 1;
fi

repoName=$1
mainRepoUserName=$2
secondaryRepoUserName=$3
myUserName=$4

echo "Setting up remotes"
echo "=================="

echo "Repo Name: $repoName"
echo "Main:      $mainRepoUserName"
echo "Secondary: $secondaryRepoUserName"
echo "Username:  $myUserName"

git remote set-url origin "https://$myUserName@inf-swe-git.technikum-wien.at/r/~$mainRepoUserName/$repoName.git"

git remote remove $secondaryRepoUserName
git remote remove all

git remote add $secondaryRepoUserName https://$myUserName@inf-swe-git.technikum-wien.at/r/~$secondaryRepoUserName/$repoName.git
git remote add all "https://$myUserName@inf-swe-git.technikum-wien.at/r/~$mainRepoUserName/$repoName.git"
git remote set-url --add all "https://$myUserName@inf-swe-git.technikum-wien.at/r/~$secondaryRepoUserName/$repoName.git"

echo "Result:"
git remote -v
