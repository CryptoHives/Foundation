| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     1.768 μs | 0.0056 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     2.972 μs | 0.0058 μs | 0.0055 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     3.740 μs | 0.0226 μs | 0.0200 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     1.777 μs | 0.0069 μs | 0.0065 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     2.978 μs | 0.0079 μs | 0.0074 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     3.674 μs | 0.0116 μs | 0.0108 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     6.757 μs | 0.0247 μs | 0.0231 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    11.149 μs | 0.0223 μs | 0.0198 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    13.879 μs | 0.0346 μs | 0.0307 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     6.762 μs | 0.0257 μs | 0.0241 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    11.152 μs | 0.0262 μs | 0.0245 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    14.116 μs | 0.0482 μs | 0.0427 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    46.527 μs | 0.1783 μs | 0.1668 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    76.448 μs | 0.2728 μs | 0.2551 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |    95.822 μs | 0.2856 μs | 0.2671 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   734.193 μs | 2.7969 μs | 2.6162 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,199.888 μs | 2.5955 μs | 2.4279 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,460.785 μs | 5.0399 μs | 4.7143 μs |         - |