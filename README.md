# NUnit.Analyzers for Unity

[![openupm](https://img.shields.io/npm/v/nunit.analyzers.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/nunit.analyzers.unity/)

This package includes [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers) v3.9.0 DLL and is set up to be enabled in the Unity Editor and any IDEs.

> [!NOTE]\
> NUnit.Analyzers v3.9.0 is the final version compatible with Unity Test Framework.


## Required

* Unity 2022.2 or later


## Installation

1. Open the Project Settings window (**Editor > Project Settings**) and select **Package Manager** tab
2. Click **+** button under the **Scoped Registries** and enter the following settings:
    1. **Name:** `package.openupm.com`
    2. **URL:** `https://package.openupm.com`
    3. **Scope(s):** `nunit.analyzers.unity`
3. Open the Package Manager window (**Window > Package Manager**) and select **My Registries** tab
4. Select **NUnit.Analyzers for Unity** and click the **Install** button

> [!NOTE]\
> You do not need to add a reference to the test assembly definition file (asmdef).
> Because it's configured via an assembly definition reference file (asmref) to apply across all test assemblies.


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
