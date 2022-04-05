@echo off
cd C:\Users\artem\source\repos\toptours1
:input
	set /p Message=Enter a message for the commit: 
	echo Message is %Message%
	set /p Answer=Are you sure you want to proceed? (y/n): 
	IF "%Answer%" EQU "y" (goto proceed) ELSE (goto input)


:proceed	
git add .
git commit -m "%Message%"
git push origin main
