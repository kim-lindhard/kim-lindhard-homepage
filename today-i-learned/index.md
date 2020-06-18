# TIL Today i learned

## Count lines of code
You can count the lines of code in a dotnet project by 
listing .cs files in the project folder except files in the obj folders and letting  word count (wc) count the lines:  
```sh
find . -path "*/obj*" -prune -o -name '*.cs' | xargs wc -l | grep -v "Is a directory"
```

use Windows Subsystem for Linux in case you are on a windows machine to run the Linux command.