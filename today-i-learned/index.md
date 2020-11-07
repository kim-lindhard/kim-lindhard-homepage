# TIL Today i learned

## Count lines of code
You can count the lines of code in a dotnet project by 
listing .cs files in the project folder except files in the obj folders and letting  word count (wc) count the lines:  
```sh
find . -path "*/obj*" -prune -o -name '*.cs' | xargs wc -l | grep -v "Is a directory"
```

use Windows Subsystem for Linux in case you are on a windows machine to run the Linux command.

## Enforce the input instead of guarding

Favor creating inputs that can't have am incorrect value over validating the input in the receiving method. This way you see the issue at build time instead of getting a surprise at runtime.

Example of a defensive method we should avoid:
```csharp
public string ServeMyKidIceCreme(int scoops){
    if(3 < scoops){
        throw new Exception("You will get a belly ache if you eat more than {} scoops");
    }

    return $"Here is a nice ice cream with {scoops} scoops";
}
```

A solution where only legal inputs exist:
```csharp
public enum ScoopsOfIceCremeMyKidsMayHave
{
    Zero = 0,
    One = 1,
    Two = 2,
    Three = 3
}

public string ServeMyKidIceCreme(ScoopsOfIceCremeMyKidsMayHave scoops){
    return $"Here is a nice ice cream with {scoops} scoops";
}
```

