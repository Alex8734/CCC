// See https://aka.ms/new-console-template for more information

using CCC_Classic.Utils;
using CCC_Praktikum;

Utils.FileSelector = (lvl,i) => $"lvl{lvl}-{i}.inp";
Utils.StartIdx = 0;
new Level2().Run();
