# NUnit.Analyzers for Unity

[![openupm](https://img.shields.io/npm/v/nunit.analyzers.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/nunit.analyzers.unity/)

This package includes [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers) DLL. And done set up for use on Unity
Editor and IDEs.


## Required

Unity 2021.2.0f1[^1][^2][^3] or later

[^1]: Roslyn analyzer will work with Unity 2020.2 or later, but DLLs placed under Packages will not be worked until
2020.3.4+.
[^2]: Roslyn analyzer will work with Unity 2020.2 or later, but diagnostic to test assembly will not be worked until 2021.2+.
[^3]: Can be used before Unity 2019 if you are using it on IDEs.


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

Refer to the NUnit Analyzers [documentation](https://github.com/nunit/nunit.analyzers/blob/master/documentation/index.md) for diagnostics.


## Analyzer import script for IDEs

Plug-in packages for IDEs (JetBrains Rider, Visual Studio Code, Visual Studio) create .csproj files.
But, there are problems with handling analyzer settings, correctly handling DLLs under Packages, and incorrectly handling assembly dependencies[^4].

[^4]: See details, "Analyzer scope" section in https://docs.unity3d.com/2020.2/Documentation/Manual/roslyn-analyzers.html

The [AnalyzerImporter](https://gist.github.com/nowsprinting/d303785b006f6c1ebd5dd12ecbe1a4ec) script is included in this package.
This will set up the analyzers in the .csproj file according to the dependencies of the assembly.
However, It does not work the chain of dependence. Only dependencies written directly to asmdef will work.


## License

MIT License


## How to contribute

Open an issue or create a pull request.


## Release workflow

Bump version in package.json && push (or merge) to default branch.

Or run [Create release pull request](https://github.com/nowsprinting/nunit.analyzers.unity/actions/workflows/create_release_pr.yml) workflow and merge PR.