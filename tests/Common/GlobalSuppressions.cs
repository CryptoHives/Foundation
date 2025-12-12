// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to test projects.
// These suppressions are appropriate for test code but may not be
// appropriate for production code.

using System.Diagnostics.CodeAnalysis;

// CA1062: Validate arguments of public methods
// Test methods receive parameters from test frameworks (e.g., TestCaseSource)
// which are guaranteed to be non-null by the framework.
[assembly: SuppressMessage(
    "Design",
    "CA1062:Validate arguments of public methods",
    Justification = "Test method parameters are provided by test framework and guaranteed non-null.")]

// CA1707: Identifiers should not contain underscores
// Test class names often mirror the class under test (e.g., SHA3_224Tests for SHA3_224).
// Test method names may use underscores for readability in some patterns.
[assembly: SuppressMessage(
    "Naming",
    "CA1707:Identifiers should not contain underscores",
    Justification = "Test class/method names may contain underscores to match the class under test or for readability.")]

// CA1515: Consider making public types internal
// Test classes need to be public for the test framework to discover them.
[assembly: SuppressMessage(
    "Maintainability",
    "CA1515:Consider making public types internal",
    Justification = "Test classes must be public for test framework discovery.")]

// CA5394: Do not use insecure randomness
// Test code may use Random for generating test data where cryptographic security is not required.
[assembly: SuppressMessage(
    "Security",
    "CA5394:Do not use insecure randomness",
    Justification = "Test code may use non-cryptographic random for test data generation.")]

// CA1034: Nested types should not be visible
// Test helper classes may be nested within test fixtures for organization.
[assembly: SuppressMessage(
    "Design",
    "CA1034:Nested types should not be visible",
    Justification = "Nested types in tests are acceptable for test organization.")]

// CA1822: Mark members as static
// Test setup/teardown methods and helper methods may not use instance state
// but are kept as instance methods for test framework compatibility.
[assembly: SuppressMessage(
    "Performance",
    "CA1822:Mark members as static",
    Justification = "Test methods may be instance methods for framework compatibility.")]
