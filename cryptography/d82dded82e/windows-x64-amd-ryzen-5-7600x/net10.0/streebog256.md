| Description                                  | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     2.384 μs |  0.0084 μs |  0.0078 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     3.437 μs |  0.0135 μs |  0.0126 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     4.267 μs |  0.0443 μs |  0.0414 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     2.406 μs |  0.0106 μs |  0.0099 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     3.448 μs |  0.0258 μs |  0.0228 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     4.279 μs |  0.0229 μs |  0.0203 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     9.023 μs |  0.0397 μs |  0.0371 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    12.749 μs |  0.1175 μs |  0.1099 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    16.247 μs |  0.1146 μs |  0.1072 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     9.069 μs |  0.0466 μs |  0.0436 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    12.721 μs |  0.0680 μs |  0.0603 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    16.323 μs |  0.1521 μs |  0.1423 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    63.100 μs |  0.2803 μs |  0.2622 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    87.146 μs |  0.7910 μs |  0.7399 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |   111.290 μs |  0.5364 μs |  0.4479 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   975.244 μs |  3.2397 μs |  3.0304 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,369.374 μs | 14.4580 μs | 12.8166 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,750.307 μs |  9.4760 μs |  8.8638 μs |         - |