// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CryptoHives.Security.Certificates;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

#region Asset Helpers
/// <summary>
/// The interface to initialize an asset.
/// </summary>
public interface IAsset
{
    void Initialize(byte[] blob, string path);
}

/// <summary>
/// Create a collection of test assets.
/// </summary>
public class AssetCollection<T> : List<T> where T : IAsset, new()
{
    public AssetCollection() { }
    public AssetCollection(IEnumerable<T> collection) : base(collection) { }
    public AssetCollection(int capacity) : base(capacity) { }
    public static AssetCollection<T> ToAssetCollection(T[] values)
    {
        return values != null ? new AssetCollection<T>(values) : new AssetCollection<T>();
    }

    public AssetCollection(IEnumerable<string> filelist)
    {
        foreach (var file in filelist)
        {
            Add(file);
        }
    }

    public void Add(string path)
    {
        byte[] blob = File.ReadAllBytes(path);
        T asset = new T();
        asset.Initialize(blob, path);
        Add(asset);
    }
}
#endregion

#region TestUtils
/// <summary>
/// Test helpers.
/// </summary>
public static class TestUtils
{
    public static string[] EnumerateTestAssets(string searchPattern)
    {
        var assetsPath = GetAbsoluteDirectoryPath("Assets", true, false, false);
        if (assetsPath != null)
        {
            return Directory.EnumerateFiles(assetsPath, searchPattern).ToArray();
        }
        return Array.Empty<string>();
    }

    public static void ValidateSelSignedBasicConstraints(X509Certificate2 certificate)
    {
        var basicConstraintsExtension = X509Extensions.FindExtension<X509BasicConstraintsExtension>(certificate.Extensions);
        Assert.NotNull(basicConstraintsExtension);
        Assert.False(basicConstraintsExtension.CertificateAuthority);
        Assert.True(basicConstraintsExtension.Critical);
        Assert.False(basicConstraintsExtension.HasPathLengthConstraint);
    }

    /// <summary>
    /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
    /// </summary>
    public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError)
    {
        return GetAbsoluteDirectoryPath(dirPath, checkCurrentDirectory, throwOnError, false);
    }

    /// <summary>
    /// Checks if the file path is a relative path and returns an absolute path relative to the EXE location.
    /// </summary>
    public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError, bool createAlways)
    {
        string originalPath = dirPath;
        dirPath = ReplaceSpecialFolderNames(dirPath);

        if (!string.IsNullOrEmpty(dirPath))
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);

            // check for absolute path.
            bool isAbsolute = IsPathRooted(dirPath);

            if (isAbsolute)
            {
                if (directory.Exists)
                {
                    return dirPath;
                }

                if (createAlways && !directory.Exists)
                {
                    directory = Directory.CreateDirectory(dirPath);
                    return directory.FullName;
                }
            }

            if (!isAbsolute)
            {
                // look current directory.
                if (checkCurrentDirectory)
                {
                    if (!directory.Exists)
                    {
                        directory = new DirectoryInfo($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{dirPath}");
#if NETFRAMEWORK
                        if (!directory.Exists)
                        {
                            var directory2 = new DirectoryInfo($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}{dirPath}");
                            if (directory2.Exists)
                            {
                                directory = directory2;
                            }
                        }
#endif
                    }
                }

                // return full path.      
                if (directory.Exists)
                {
                    return directory.FullName;
                }

                // create the directory.
                if (createAlways)
                {
                    directory = Directory.CreateDirectory(directory.FullName);
                    return directory.FullName;
                }
            }
        }

        // file does not exist.
        if (throwOnError)
        {
            throw new Exception(
                string.Format("Directory does not exist: {0}\r\nCurrent directory is: {1}",
                originalPath,
                Directory.GetCurrentDirectory()));
        }

        return null;
    }
    /// <summary>
    /// Replaces a prefix enclosed in '%' with a special folder or environment variable path (e.g. %ProgramFiles%\MyCompany).
    /// </summary>
    public static string ReplaceSpecialFolderNames(string input)
    {
        // nothing to do for nulls.
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        // check for absolute path.
        if (IsPathRooted(input))
        {
            return input;
        }

        // check for special folder prefix.
        if (input[0] != '%')
        {
            return input;
        }

        // extract special folder name.
        string folder = null;
        string path = null;

        int index = input.IndexOf('%', 1);

        if (index == -1)
        {
            folder = input.Substring(1);
            path = string.Empty;
        }
        else
        {
            folder = input.Substring(1, index - 1);
            path = input.Substring(index + 1);
        }

        StringBuilder buffer = new StringBuilder();
#if !NETSTANDARD1_4 && !NETSTANDARD1_3
        // check for special folder.
        Environment.SpecialFolder specialFolder;
        if (!Enum.TryParse<Environment.SpecialFolder>(folder, out specialFolder))
        {
#endif
            folder = ReplaceSpecialFolderWithEnvVar(folder);
            string value = Environment.GetEnvironmentVariable(folder);
            if (value != null)
            {
                buffer.Append(value);
            }
            else
            {
                if (folder == "LocalFolder")
                {
                    buffer.Append(DefaultLocalFolder);
                }
            }
#if !NETSTANDARD1_4 && !NETSTANDARD1_3
        }
        else
        {
            buffer.Append(Environment.GetFolderPath(specialFolder));
        }
#endif
        // construct new path.
        buffer.Append(path);
        return buffer.ToString();
    }

    /// <summary>
    /// Replaces a prefix enclosed in '%' with a special folder or environment variable path (e.g. %ProgramFiles%\MyCompany).
    /// </summary>
    public static bool IsPathRooted(string path)
    {
        // allow for local file locations
        return Path.IsPathRooted(path) || (path.Length >= 2 && path[0] == '.' && path[1] != '.');
    }

    /// <summary>
    /// Maps a special folder to environment variable with folder path.
    /// </summary>
    private static string ReplaceSpecialFolderWithEnvVar(string input)
    {
        switch (input)
        {
            case "CommonApplicationData": return "ProgramData";
        }

        return input;
    }

    /// <summary>
    /// The default LocalFolder.
    /// </summary>
    public static string DefaultLocalFolder { get; set; } = Directory.GetCurrentDirectory();

}
#endregion


