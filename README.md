# NUnit.Analyzers for Unity

This package includes [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers) DLL. And done set up for use on Unity
Editor and IDEs.


## Required

Unity 2020.3.4f1[^1][^2] or later

[^1]: Roslyn analyzer will work with Unity 2020.2 or later, but DLLs placed under Packages/ will not be worked until
2020.3.4+.
[^2]: Can be used before Unity 2019 if you are using it on IDEs.


## Installation

If you installed [openupm-cli](https://github.com/openupm/openupm-cli), run the command below

```bash
openupm add nunit.analyzers.unity
```

Or open Package Manager window (Window | Package Manager) and add package from git URL

```
https://github.com/nowsprinting/nunit.analyzers.unity.git
```


## How to use

1. Open your test assembly definition file (.asmdef) in Inspector Window
2. Add "Assembly Definition References" and select `NUnit.Analyzers.Unity`.
3. Click "Apply"

Refer to the NUnit
Analyzers [documentation](https://github.com/nunit/nunit.analyzers/blob/master/documentation/index.md) for diagnostics.


## License

MIT License


## How to contribute

Open an issue or create a pull request.
