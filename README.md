# NUnit.Analyzers for Unity

[![openupm](https://img.shields.io/npm/v/nunit.analyzers.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/nunit.analyzers.unity/)

This package includes [NUnit.Analyzers](https://github.com/nunit/nunit.analyzers) DLL and is set up for use in the Unity Editor and any IDEs.

There is also **no need to add** a reference to the test assembly definition file (asmdef).


## Required

* Unity 2022.2 or later


## Installation

If you installed [openupm-cli](https://github.com/openupm/openupm-cli), run the command below

```bash
openupm add nunit.analyzers.unity
```

Or open Package Manager window (Window | Package Manager) and add package from git URL

```
https://github.com/nowsprinting/nunit.analyzers.unity.git
```


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
