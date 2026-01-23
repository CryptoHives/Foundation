```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                           | Mean      | Error     | StdDev    | Min       | Max       | Median    | Gen0   | Allocated |
|-------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| **ComputeHash | &#39;KMAC128 | CryptoHives**  |  **5.619 μs** | **0.0400 μs** | **0.0374 μs** |  **5.560 μs** |  **5.694 μs** |  **5.620 μs** | **0.1526** |   **2.62 KB** |
| **ComputeHash | &#39;KMAC128 | BouncyCastle** |  **8.898 μs** | **0.0290 μs** | **0.0227 μs** |  **8.859 μs** |  **8.930 μs** |  **8.904 μs** | **0.0763** |   **1.37 KB** |
|                                       |           |           |           |           |           |           |        |           |
| **ComputeHash | &#39;KMAC256 | CryptoHives**  |  **6.591 μs** | **0.0325 μs** | **0.0304 μs** |  **6.553 μs** |  **6.645 μs** |  **6.581 μs** | **0.1526** |   **2.55 KB** |
| **ComputeHash | &#39;KMAC256 | BouncyCastle** | **10.365 μs** | **0.0564 μs** | **0.0528 μs** | **10.270 μs** | **10.451 μs** | **10.362 μs** | **0.0763** |    **1.4 KB** |
