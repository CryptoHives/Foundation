| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     2.277 μs | 0.0056 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     3.423 μs | 0.0157 μs | 0.0147 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     4.248 μs | 0.0194 μs | 0.0181 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     2.459 μs | 0.0068 μs | 0.0064 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     3.438 μs | 0.0174 μs | 0.0163 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     4.292 μs | 0.0239 μs | 0.0212 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     8.584 μs | 0.0181 μs | 0.0169 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    12.768 μs | 0.0523 μs | 0.0489 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    16.109 μs | 0.0867 μs | 0.0811 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     9.006 μs | 0.0275 μs | 0.0243 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    12.731 μs | 0.0444 μs | 0.0416 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    16.191 μs | 0.1067 μs | 0.0946 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    62.877 μs | 0.1655 μs | 0.1548 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    87.304 μs | 0.3928 μs | 0.3674 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |   111.589 μs | 0.3256 μs | 0.2887 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   991.216 μs | 2.3330 μs | 2.0682 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,363.034 μs | 5.4350 μs | 5.0839 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,746.268 μs | 7.3003 μs | 6.8287 μs |         - |