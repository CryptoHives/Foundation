| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Kupyna-256 · Managed      | 128B         |     2.251 μs |  0.0141 μs |  0.0125 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128B         |     3.285 μs |  0.0222 μs |  0.0208 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 137B         |     2.250 μs |  0.0217 μs |  0.0192 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 137B         |     3.298 μs |  0.0223 μs |  0.0198 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1KB          |    11.162 μs |  0.1024 μs |  0.0958 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1KB          |    16.495 μs |  0.1794 μs |  0.1678 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 1025B        |    11.163 μs |  0.1083 μs |  0.0960 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 1025B        |    16.471 μs |  0.2205 μs |  0.2063 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 8KB          |    82.489 μs |  0.6107 μs |  0.5413 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 8KB          |   121.252 μs |  0.6471 μs |  0.6053 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-256 · Managed      | 128KB        | 1,306.078 μs | 13.4454 μs | 11.2275 μs |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle | 128KB        | 1,915.927 μs | 11.9961 μs | 10.6342 μs |         - |