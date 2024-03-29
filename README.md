# NUnit.Analyzers for Unity

[![openupm](https://img.shields.io/npm/v/nunit.analyzers.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/nunit.analyzers.unity/)

> **Warning**
> This package is no longer maintained, please use [UnityNuGet](https://github.com/xoofx/UnityNuGet).

This package includes [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers) DLL. And done set up for use on Unity
Editor and IDEs.


## Required

* Unity 2020.3.6f1[^1][^2] or later
* [JetBrains Rider Editor](https://docs.unity3d.com/Packages/com.unity.ide.rider@latest) v3.0.9 or later
* [Code Editor Package for Visual Studio](https://docs.unity3d.com/Packages/com.unity.ide.visualstudio@latest) v2.0.11 or later
* [Code Editor Package for Visual Studio Code](https://docs.unity3d.com/Packages/com.unity.ide.vscode@latest) v1.2.4 or later

[^1]: Roslyn analyzer will work with Unity 2020.2 or later, but DLLs placed under Packages will not be worked until 2020.3.6+.
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
2. Add "Assembly Definition References" and select `NUnit.Analyzers.Unity` (required Unity 2021.2 or later) or `NUnit.Analyzers.V2.Unity`
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

Be grateful if you could label the PR as `enhancement`, `bug`, `chore` and `documentation`. See [PR Labeler settings](.github/pr-labeler.yml) for automatically labeling from the branch name.


## Release workflow

Run `Actions | Create release pull request | Run workflow` and merge created PR.
(Or bump version in package.json on default branch)

Then, Will do the release process automatically by [Release](.github/workflows/release.yml) workflow.
And after tagged, OpenUPM retrieves the tag and updates it.

Do **NOT** manually operation the following operations:

- Create release tag
- Publish draft releases
