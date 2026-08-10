| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     1.817 μs | 0.0044 μs | 0.0042 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     3.027 μs | 0.0014 μs | 0.0013 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     3.791 μs | 0.0031 μs | 0.0027 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     1.825 μs | 0.0039 μs | 0.0037 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     3.026 μs | 0.0021 μs | 0.0018 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     3.880 μs | 0.0146 μs | 0.0136 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     6.941 μs | 0.0229 μs | 0.0215 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    11.454 μs | 0.0077 μs | 0.0072 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    14.395 μs | 0.0091 μs | 0.0085 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     6.940 μs | 0.0159 μs | 0.0149 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    11.325 μs | 0.0055 μs | 0.0052 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    14.324 μs | 0.0436 μs | 0.0408 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    47.841 μs | 0.1340 μs | 0.1254 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    77.742 μs | 0.0943 μs | 0.0883 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |    98.934 μs | 0.0761 μs | 0.0595 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   752.891 μs | 2.1261 μs | 1.8848 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,222.370 μs | 1.1398 μs | 1.0662 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,510.857 μs | 1.9135 μs | 1.7899 μs |         - |