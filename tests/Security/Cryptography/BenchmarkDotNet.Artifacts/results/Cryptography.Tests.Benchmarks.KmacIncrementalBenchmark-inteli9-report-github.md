```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7623/24H2/2024Update/HudsonValley)
Intel Core i9-10900 CPU 2.80GHz (Max: 2.81GHz), 1 CPU, 20 logical and 10 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                           | Mean      | Error     | StdDev    | Min       | Max       | Median    | Gen0   | Allocated |
|-------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| **ComputeHash | &#39;KMAC128 | CryptoHives**  |  **8.226 μs** | **0.0491 μs** | **0.0459 μs** |  **8.146 μs** |  **8.316 μs** |  **8.222 μs** | **0.2441** |   **2.62 KB** |
| **ComputeHash | &#39;KMAC128 | BouncyCastle** | **11.711 μs** | **0.0583 μs** | **0.0487 μs** | **11.644 μs** | **11.811 μs** | **11.698 μs** | **0.1221** |   **1.37 KB** |
|                                       |           |           |           |           |           |           |        |           |
| **ComputeHash | &#39;KMAC256 | CryptoHives**  |  **9.636 μs** | **0.0821 μs** | **0.0768 μs** |  **9.542 μs** |  **9.773 μs** |  **9.608 μs** | **0.2441** |   **2.55 KB** |
| **ComputeHash | &#39;KMAC256 | BouncyCastle** | **13.531 μs** | **0.0898 μs** | **0.0701 μs** | **13.443 μs** | **13.712 μs** | **13.518 μs** | **0.1221** |    **1.4 KB** |
