```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7623/24H2/2024Update/HudsonValley)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                           | Mean      | Error     | StdDev    | Min       | Max       | Median    | Gen0   | Allocated |
|-------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| **ComputeHash | &#39;KMAC128 | CryptoHives**  |  **5.539 μs** | **0.0240 μs** | **0.0224 μs** |  **5.494 μs** |  **5.582 μs** |  **5.543 μs** | **0.1526** |   **2.62 KB** |
| **ComputeHash | &#39;KMAC128 | BouncyCastle** |  **8.866 μs** | **0.0184 μs** | **0.0163 μs** |  **8.837 μs** |  **8.889 μs** |  **8.864 μs** | **0.0763** |   **1.37 KB** |
|                                       |           |           |           |           |           |           |        |           |
| **ComputeHash | &#39;KMAC256 | CryptoHives**  |  **6.514 μs** | **0.0173 μs** | **0.0162 μs** |  **6.490 μs** |  **6.546 μs** |  **6.509 μs** | **0.1526** |   **2.55 KB** |
| **ComputeHash | &#39;KMAC256 | BouncyCastle** | **10.309 μs** | **0.0342 μs** | **0.0320 μs** | **10.248 μs** | **10.359 μs** | **10.306 μs** | **0.0763** |    **1.4 KB** |
