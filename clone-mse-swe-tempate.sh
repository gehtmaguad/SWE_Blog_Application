#!/bin/bash

if [ "$#" -ne 4 ]; then
  echo "** ERROR: Invalid number of parameter"
  echo "./clone-mse-swe-tempate.sh MSE-WS$(date +%y)-SWE <Main repo> <Second repo> <Username>"
  echo ""
  echo "MSE-WS$(date +%y)-SWE - Name of the repo. Must include the current year."
  echo "Main repo    - se-number of your groups main repository. Example: if99x9999"
  echo "Second repo  - se-number of your groups second repository. Example: if99x0000"
  echo "Username     - se-number of your user name. Example: if99x9999"
  echo ""
  echo "Example"
  echo "-------"
  echo "On your PC:"
  echo "./clone-mse-swe-tempate.sh MSE-WS$(date +%y)-SWE se99m9999 se99m0000 se99m9999"
  echo ""
  echo "On your colleagues PC:"
  echo "./clone-mse-swe-tempate.sh MSE-WS$(date +%y)-SWE se99m9999 se99m0000 se99m0000"
  exit 1;
fi

if [[ ! $1 =~ MSE-WS[0-9][0-9]-SWE$ ]]; then
  echo "** ERROR: Parameter 1 is not in a valid format! Must be MSE-WS??-SWE."
  echo "Example: MSE-WS$(date +%y)-SWE"
  exit 1;
fi

repoName=$1

echo "Cloning template"
echo "================"

git clone https://inf-swe-git.technikum-wien.at/r/MSE/SWE.git "$repoName"
cd "$repoName"
chmod +x *.sh
./setup-remotes.sh $@
