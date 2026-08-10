| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Kupyna-256 · Managed      | 128B         |     2.219 μs |  0.0095 μs |  0.0079 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128B         |     3.254 μs |  0.0117 μs |  0.0104 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 137B         |     2.215 μs |  0.0149 μs |  0.0132 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 137B         |     3.259 μs |  0.0130 μs |  0.0122 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1KB          |    11.039 μs |  0.0720 μs |  0.0673 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1KB          |    16.235 μs |  0.0594 μs |  0.0496 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1025B        |    11.032 μs |  0.1018 μs |  0.0953 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1025B        |    16.327 μs |  0.1228 μs |  0.1149 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 8KB          |    81.341 μs |  0.4505 μs |  0.3994 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 8KB          |   120.315 μs |  0.6395 μs |  0.5982 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 128KB        | 1,290.112 μs | 11.5268 μs | 10.7822 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128KB        | 1,894.703 μs |  2.8173 μs |  2.1996 μs |         - |