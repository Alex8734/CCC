
### Overview

The `CCC_Classic.Utils` library provides a set of utilities to help you implement the CCC Levels in C#.


### How to Use

1. **Include the Namespace**: Make sure to include the `CCC_Classic.Utils` namespace in your file.
   ###### _Program.cs:_
   ```csharp
    using CCC_Classic.Utils;
    ```
   
2. **Create new Level Class**:
    - Create a new class that inherits from the `Level` class.
    - Implement the `Start()` method to execute the logic for the specific level.
   ###### _AlexLevel1.cs:_ 
   ```csharp
    public class AlexLevel1 : Level
    {
       public override string[] Start(string[] lines)
       {
       // Your implementation here
       return lines;
       }
    }
    ```
   > **_Important⚠️:_**  
   > The **Last Number** of your **ClassName** should be the **Level Number**. 
   > * `public class <ClassName><LevelNumber>{}`
   > * For Example: `public class AlexLevel1{}`, `public class AlexLevel2{}`, `public class AlexLevel3{}`, etc.
      
3. **Test Your Level Implementation**:
    -  **`.RunExample()`**: You can run your Level with the Example Data by calling **this** method. 
   ###### _Program.cs:_ 
   ```csharp
    AlexLevel1 level1 = new AlexLevel1();
    level1.RunExample();
    ```
   .... or  directly:
   ###### _Program.cs:_
   ```csharp
    new AlexLevel1().RunExample();
    ```
   <img src=".github/Example.png" alt="Properties" >

4. **Execute Your Level Implementation & Create the Output Files**:
   - **`.Run()`**: You can run your Level by calling the `.Run()` method.
   ###### _Program.cs:_
   ```csharp
   AlexLevel1 level1 = new AlexLevel1();
   level1.Run();
   ```
   .... or  directly:
   ###### _Program.cs:_
   ```csharp
   new AlexLevel1().Run();
   ```
> **_Tip⚠️:_**  
> If your Output is just a Line.
> * You can use the hidden Parameter in the `Start(bool WriteToConsole)` Method.
> * For Example: `AlexLevel1.Run(WriteToConsole:true)`


### Data Files
1. **Save Data Files**:
    - Save the data files for each level in the `Data` folder of your project.
    - Every Level should have a Directory with the exact the Name `Level<LevelNumber`.
      <img src=".github/Data.png" alt="Data" height="300" >

2. **Set File Properties**:
    - Right-click on the file in the Solution Explorer.
    - Select `Properties`.
    - Set `Copy to Output Directory` to `Copy always`.
      <img src=".github/Propaties.png" alt="Properties" height="300" >
3. **File Selector**:
    - If the File Naming Syntax is different to the Other CCC's you need to overwrite the `FileSelector`.
   - Default File Naming Syntax: `level{levelNumber}-{exampleNumber}.txt`

   ###### _Program.cs:_
   ```csharp 
    Utils.FileSelector = (lvl,i)=>$"level{lvl}-{i}.txt";
    Utils.ExampleSelector = lvl => $"level{lvl}-eg.txt";
    ```
> **_Tip⚠️:_**  
> If your Input has different count of InputFiles.
> * You can use the hidden Parameter in the `Start(int inputs)` Method.
> * For Example: `AlexLevel1.Run(inputs:4)`.

This should help you get started with using the `Utils` library in your projects.