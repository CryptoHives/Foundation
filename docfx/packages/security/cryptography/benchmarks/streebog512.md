| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     2.406 μs | 0.0044 μs | 0.0039 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     3.350 μs | 0.0152 μs | 0.0142 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     4.235 μs | 0.0246 μs | 0.0230 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     2.327 μs | 0.0055 μs | 0.0049 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     3.366 μs | 0.0221 μs | 0.0207 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     4.238 μs | 0.0157 μs | 0.0139 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     9.178 μs | 0.0288 μs | 0.0269 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    12.619 μs | 0.0569 μs | 0.0532 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    16.111 μs | 0.0704 μs | 0.0588 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     8.700 μs | 0.0166 μs | 0.0155 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    12.626 μs | 0.0443 μs | 0.0414 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    16.106 μs | 0.0688 μs | 0.0574 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    59.625 μs | 0.1634 μs | 0.1528 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    87.050 μs | 0.8585 μs | 0.8030 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |   112.060 μs | 0.7953 μs | 0.7439 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        | 1,015.577 μs | 2.8507 μs | 2.5270 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,360.808 μs | 6.2221 μs | 5.8202 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,736.226 μs | 6.2932 μs | 5.2551 μs |         - |