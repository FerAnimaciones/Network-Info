@echo off
cd /d %~d0
cd %~dp0
cd ..
git reflog expire --all --expire=now
git gc --prune=now --aggressive

pause
