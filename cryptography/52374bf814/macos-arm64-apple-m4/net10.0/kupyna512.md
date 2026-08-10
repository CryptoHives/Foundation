| Description                                | TestDataSize | Mean         | Error      | StdDev      | Median       | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|------------:|-------------:|----------:|
| TryComputeHash · Kupyna-512 · Managed      | 128B         |     3.306 μs |  0.0141 μs |   0.0118 μs |     3.305 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 128B         |     5.500 μs |  0.1740 μs |   0.5131 μs |     5.602 μs |         - |
|                                            |              |              |            |             |              |           |
| TryComputeHash · Kupyna-512 · Managed      | 137B         |     4.667 μs |  0.0931 μs |   0.1305 μs |     4.658 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 137B         |     5.864 μs |  0.1170 μs |   0.2664 μs |     5.861 μs |         - |
|                                            |              |              |            |             |              |           |
| TryComputeHash · Kupyna-512 · Managed      | 1KB          |    14.598 μs |  0.5495 μs |   1.6201 μs |    14.913 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 1KB          |    17.369 μs |  0.0117 μs |   0.0104 μs |    17.366 μs |         - |
|                                            |              |              |            |             |              |           |
| TryComputeHash · Kupyna-512 · Managed      | 1025B        |    12.481 μs |  0.2107 μs |   0.1759 μs |    12.400 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 1025B        |    21.093 μs |  0.7174 μs |   2.1154 μs |    21.539 μs |         - |
|                                            |              |              |            |             |              |           |
| TryComputeHash · Kupyna-512 · Managed      | 8KB          |   119.648 μs |  2.2806 μs |   2.4402 μs |   119.800 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 8KB          |   164.373 μs |  3.2517 μs |   5.8636 μs |   165.875 μs |         - |
|                                            |              |              |            |             |              |           |
| TryComputeHash · Kupyna-512 · Managed      | 128KB        | 1,966.664 μs | 38.4295 μs |  51.3023 μs | 1,953.189 μs |         - |
| TryComputeHash · Kupyna-512 · BouncyCastle | 128KB        | 2,040.164 μs | 84.1084 μs | 247.9954 μs | 1,924.539 μs |         - |