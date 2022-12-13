#!/bin/bash
#Mention the Folder/Project Name
if [ -d "/home/coder/project/workspace/application/project-name" ]
then
	cp -r /home/coder/project/workspace/nunit/test/applicationTest /home/coder/project/workspace/application/;
	cd /home/coder/project/workspace/application;
	dotnet test
else
    echo "test_case1 FAILED"
    echo "test_case2 FAILED"
fi