using CCC_Classic.Utils;
using CCC_School_39;


foreach(var level in (ILevel[]) [
                new Level1(),
                new Elija_Level2(),
                new Level3(),
                new Level4()]){
    level.Run();
}
