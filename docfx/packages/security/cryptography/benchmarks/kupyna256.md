| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Kupyna-256 · Managed      | 128B         |     2.313 μs |  0.0450 μs |  0.0518 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128B         |     3.294 μs |  0.0250 μs |  0.0234 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 137B         |     2.268 μs |  0.0316 μs |  0.0264 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 137B         |     3.286 μs |  0.0152 μs |  0.0135 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1KB          |    11.598 μs |  0.0403 μs |  0.0377 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1KB          |    16.369 μs |  0.1402 μs |  0.1312 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1025B        |    11.244 μs |  0.0717 μs |  0.0670 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1025B        |    16.421 μs |  0.1096 μs |  0.0915 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 8KB          |    83.036 μs |  0.7287 μs |  0.6460 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 8KB          |   120.937 μs |  0.6058 μs |  0.5370 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 128KB        | 1,312.142 μs | 12.9352 μs | 12.0996 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128KB        | 1,915.741 μs | 15.9717 μs | 14.1585 μs |         - |