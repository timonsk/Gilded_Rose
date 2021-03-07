# Gilded_Rose solution
Basic refactored solution for Gilded Rose problem. 
Requirements could be found here: [GildedRoseRequirements.txt](https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/master/GildedRoseRequirements.txt)
- Solution consist of 2 projects: 
  - Gilded_Rose (implementation)
  - Gilded_Rose_Tests (unit tests)

## Technical requirements
* .net 5 SDK pre-installed (link to official web-site  [.net 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0))
* VS code or VS studio pre-installed (VS code [official web-site](https://code.visualstudio.com/Download),  VS studio [official web-site](https://visualstudio.microsoft.com/))

## Usage
1) You can open a solution in one of the editors and perform all action from it OR
2) Open PowerShell in the project root folder
2) Restore Nuget pageges 
```PowerShell
dotnet restore
```
3) Build the solution
```PowerShell
dotnet build
```

4) Run unit tests for the solution
```PowerShell
dotnet test Gilded_Rose_Tests\Gilded_Rose_Tests.csproj
```

5) Run the solution
```PowerShell
dotnet run --project Gilded_Rose\Gilded_Rose.csproj
```

## License
[MIT](https://choosealicense.com/licenses/mit/)