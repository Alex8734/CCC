
using CCC_Classic.Utils;
using Hyperloop_School;

Utils.FileSelector = (lvl,i) => $"level{lvl}-{i}.txt";
Utils.ExampleSelector = lvl => $"level{lvl}-eg.txt";

new Level1().RunExample();