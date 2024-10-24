

using CCC_Praktikum2;
using CCC_Classic.Utils;
using Microsoft.VisualBasic.CompilerServices;
using Utils = CCC_Classic.Utils.Utils;

Utils.FileSelector = (lvl,i)=>$"level{lvl}-{i}.txt";
Utils.ExampleSelector = lvl => $"level{lvl}-eg.txt";
new Level4().RunExample();


