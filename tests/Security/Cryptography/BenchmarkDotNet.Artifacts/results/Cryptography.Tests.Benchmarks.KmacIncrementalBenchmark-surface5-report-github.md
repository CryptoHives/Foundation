```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
12th Gen Intel Core i7-1265U 2.70GHz, 1 CPU, 12 logical and 10 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                           | Mean      | Error     | StdDev    | Median    | Min       | Max       | Gen0   | Allocated |
|-------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| **ComputeHash | &#39;KMAC128 | CryptoHives**  |  **6.169 μs** | **0.1201 μs** | **0.1003 μs** |  **6.129 μs** |  **6.052 μs** |  **6.359 μs** | **0.4196** |   **2.62 KB** |
| **ComputeHash | &#39;KMAC128 | BouncyCastle** |  **8.064 μs** | **0.0522 μs** | **0.0489 μs** |  **8.046 μs** |  **7.979 μs** |  **8.155 μs** | **0.2136** |   **1.37 KB** |
|                                       |           |           |           |           |           |           |        |           |
| **ComputeHash | &#39;KMAC256 | CryptoHives**  | **11.468 μs** | **0.6338 μs** | **1.8388 μs** | **12.301 μs** |  **7.059 μs** | **13.015 μs** | **0.4120** |   **2.55 KB** |
| **ComputeHash | &#39;KMAC256 | BouncyCastle** | **18.356 μs** | **0.4892 μs** | **1.3309 μs** | **18.754 μs** | **11.199 μs** | **20.158 μs** | **0.2136** |    **1.4 KB** |
