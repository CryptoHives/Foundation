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
| **ComputeHash | &#39;KMAC128 | CryptoHives**  |  **5.598 μs** | **0.0282 μs** | **0.0264 μs** |  **5.559 μs** |  **5.645 μs** |  **5.597 μs** | **0.1526** |   **2.62 KB** |
| **ComputeHash | &#39;KMAC128 | BouncyCastle** |  **8.874 μs** | **0.0323 μs** | **0.0302 μs** |  **8.840 μs** |  **8.947 μs** |  **8.864 μs** | **0.0763** |   **1.37 KB** |
|                                       |           |           |           |           |           |           |        |           |
| **ComputeHash | &#39;KMAC256 | CryptoHives**  |  **6.623 μs** | **0.0268 μs** | **0.0250 μs** |  **6.591 μs** |  **6.674 μs** |  **6.620 μs** | **0.1526** |   **2.55 KB** |
| **ComputeHash | &#39;KMAC256 | BouncyCastle** | **10.350 μs** | **0.0459 μs** | **0.0429 μs** | **10.282 μs** | **10.442 μs** | **10.338 μs** | **0.0763** |    **1.4 KB** |
