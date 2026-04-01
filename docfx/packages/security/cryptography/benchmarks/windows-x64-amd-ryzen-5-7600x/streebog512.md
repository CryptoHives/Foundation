| Description                                  | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     2.392 μs |  0.0112 μs | 0.0105 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     3.364 μs |  0.0171 μs | 0.0152 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     4.244 μs |  0.0283 μs | 0.0251 μs |         - |
|                                              |              |              |            |           |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     2.383 μs |  0.0068 μs | 0.0057 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     3.375 μs |  0.0270 μs | 0.0253 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     4.250 μs |  0.0277 μs | 0.0259 μs |         - |
|                                              |              |              |            |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     9.155 μs |  0.0258 μs | 0.0215 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    12.638 μs |  0.0596 μs | 0.0528 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    16.219 μs |  0.1396 μs | 0.1306 μs |         - |
|                                              |              |              |            |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     9.118 μs |  0.0309 μs | 0.0289 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    12.688 μs |  0.1122 μs | 0.1049 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    16.243 μs |  0.1715 μs | 0.1604 μs |         - |
|                                              |              |              |            |           |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    63.075 μs |  0.2877 μs | 0.2691 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    87.287 μs |  0.7096 μs | 0.6638 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |   112.265 μs |  0.8141 μs | 0.7615 μs |         - |
|                                              |              |              |            |           |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        |   961.985 μs |  2.5844 μs | 2.4174 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,365.909 μs |  7.7554 μs | 6.4761 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,749.143 μs | 10.1758 μs | 9.5184 μs |         - |