
using CCC_Classic.Utils;
using CCC_Classic;


ILevel[] levels = [
    new Level1(),
    new Level2(),
    new Level3()
];

foreach (var level in levels)
{
    level.Run();
}