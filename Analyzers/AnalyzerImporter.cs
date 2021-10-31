// Copyright (c) 2021 Koji Hasegawa
// This software is released under the MIT License.

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;

namespace NUnit.Analyzers.Unity
{
    /// <summary>
    /// This script applies the Roslyn analyzers under the assembly definition file (.asmdef) to each project .csproj file.
    /// Analyzer maintains the dependencies described in the <see href="https://docs.unity3d.com/2020.2/Documentation/Manual/roslyn-analyzers.html">Analyzer scope</see> of Unity 2020.2 or later.
    /// You can distribute the analyzer for your library along with the UPM package.
    ///
    /// Usage:
    /// 1. Place the analyzer DLL files in the directory same or under the .asmdef file
    /// 2. Place this script in the directory same or under the .asmdef file
    /// 3. Check if the assembly definition file (.asmdef) name is the same as the assembly name
    ///
    /// How it works:
    /// 1. Remove `Analyzer` node added by IDE that does not consider dependencies or package cache paths
    /// 2. Apply the analyzer under this asmdef to the .csproj file that contains this assembly as a dependency
    ///
    /// Cautions:
    /// - Required same as the assembly definition file (.asmdef) name and assembly name.
    /// - It does not work the chain of dependence. Only dependencies written directly to asmdef will work.
    /// </summary>
    public class AnalyzerImporter : AssetPostprocessor
    {
        private static readonly XNamespace s_xNamespace = "http://schemas.microsoft.com/developer/msbuild/2003";

        private static string MyAssemblyName => typeof(AnalyzerImporter).Assembly.GetName().Name;

        private static string MyAssemblyRoot => AssetDatabase
            .FindAssets(MyAssemblyName, new string[] { })
            .Select(AssetDatabase.GUIDToAssetPath)
            .First()
            .Replace($"/{MyAssemblyName}.asmdef", "");
        // NOTE: required same as the assembly definition file (.asmdef) name and assembly name.

        private static IEnumerable<XElement> MyAnalyzers => AssetDatabase
            .FindAssets("l:RoslynAnalyzer", new string[] { MyAssemblyRoot })
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(Path.GetFullPath)
            .Select(x => new XElement(s_xNamespace + "Analyzer", new XAttribute("Include", x)));

        private static IEnumerable<string> MyRelativePathAnalyzers => AssetDatabase
            .FindAssets("l:RoslynAnalyzer", new string[] { MyAssemblyRoot })
            .Select(AssetDatabase.GUIDToAssetPath);

        private static string RemoveRelativePathAnalyzers(string content)
        {
            foreach (var relativePathAnalyzer in MyRelativePathAnalyzers)
            {
                content = content.Replace($"<Analyzer Include=\"{relativePathAnalyzer}\" />", "");
            }

            return content;
        }

        private static bool ExistProjectReferenceInCsproj(string content)
        {
            return
                content.Contains($"<AssemblyName>{MyAssemblyName}</AssemblyName>") ||
                content.Contains($"<ProjectReference Include=\"{MyAssemblyName}.csproj\">") ||
                content.Contains($"<Reference Include=\"{MyAssemblyName}\">");
        }

        private static string OnGeneratedCSProject(string path, string content)
        {
            content = RemoveRelativePathAnalyzers(content);

            if (!ExistProjectReferenceInCsproj(content))
            {
                return content;
            }

            var xDocument = XDocument.Parse(content);
            xDocument.Root?.Add(new XElement(s_xNamespace + "ItemGroup", MyAnalyzers.ToArray() as object[]));
            return $"{xDocument.Declaration}{Environment.NewLine}{xDocument.Root}";
        }
    }
}
#endif
