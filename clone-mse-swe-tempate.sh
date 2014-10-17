#!/bin/bash

cfgCourseName="MSE/SWE"
cfgRepoName="MSE-WS$(date +%y)-SWE"
cfgRepoTestPattern="MSE-WS[0-9][0-9]-SWE$"
cfgTempateUrl="https://inf-swe-git.technikum-wien.at/r/MSE/SWE.git"

repoName=$1

echo "============================================"
echo "Cloning $cfgCourseName template"
echo "============================================"

while [  -z $repoName ]; do
	echo ""
    echo "Name of the git-repository. Name must include the current year."
	echo "Example: $cfgRepoName"
    echo -n "RepoName (ENTER for $cfgRepoName): "
    read repoName
	
	if [ -z $repoName ]; then 
		repoName=$cfgRepoName
	fi

	if [[ ! $repoName =~ $cfgRepoTestPattern ]]; then
		echo "** ERROR: Parameter is not in a valid format!"
		repoName=""
	fi
done

echo ""

git clone $cfgTempateUrl "$repoName"
cd "$repoName"
chmod +x *.sh

echo ""
./setup-remotes.sh "$repoName"
