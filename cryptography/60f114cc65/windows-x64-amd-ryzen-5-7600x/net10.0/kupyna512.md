| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Kupyna-512 · Managed      | 128B         |     4.375 μs |  0.0383 μs |  0.0358 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 128B         |     6.754 μs |  0.0452 μs |  0.0423 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-512 · Managed      | 137B         |     4.392 μs |  0.0482 μs |  0.0451 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 137B         |     6.753 μs |  0.0276 μs |  0.0245 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-512 · Managed      | 1KB          |    16.577 μs |  0.1723 μs |  0.1611 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 1KB          |    25.619 μs |  0.1194 μs |  0.1059 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-512 · Managed      | 1025B        |    16.623 μs |  0.2153 μs |  0.1908 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 1025B        |    25.828 μs |  0.1543 μs |  0.1443 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-512 · Managed      | 8KB          |   114.294 μs |  0.7835 μs |  0.7329 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 8KB          |   176.091 μs |  1.1032 μs |  0.9212 μs |         - |
|                                            |              |              |            |            |           |
| TryComputeHash · Kupyna-512 · Managed      | 128KB        | 1,783.785 μs |  9.3795 μs |  8.7736 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 128KB        | 2,757.611 μs | 24.2945 μs | 22.7251 μs |         - |