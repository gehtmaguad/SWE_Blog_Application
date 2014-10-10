#!/bin/bash

if [ "$#" -ne 4 ]; then
  echo "** ERROR: Invalid number of parameter"
  echo "./clone-mse-swe-tempate.sh MSE-WS??-SWE <Main repo> <Second repo> <Username>"
  echo ""
  echo "MSE-WS??-SWE - Example: MSE-WS14-SWE"
  echo "Main repo    - if-number of your groups main repository. Example: if99x9999"
  echo "Second repo  - if-number of your groups second repository. Example: if99x0000"
  echo "Username     - if-number of your user name. Example: if99x9999"
  echo ""
  echo "Example"
  echo "-------"
  echo "On your PC:"
  echo "./clone-mse-swe-tempate.sh MSE-WS14-SWE if99x9999 if99x0000 if99x9999"
  echo ""
  echo "On your colleagues PC:"
  echo "./clone-mse-swe-tempate.sh MSE-WS14-SWE if99x9999 if99x0000 if99x0000"
  exit 1;
fi

if [[ ! $1 =~ MSE-WS[0-9][0-9]-SWE$ ]]; then
  echo "** ERROR: Parameter 1 is not in a valid format! Must be MSE-WS??-SWE."
  echo "Example: MSE-WS14-SWE"
  exit 1;
fi

repoName=$1

echo "Cloning template"
echo "================"

git clone https://inf-swe-git.technikum-wien.at/r/MSE/SWE.git "$repoName"
cd "$repoName"
chmod +x *.sh
./setup-remotes.sh $@
