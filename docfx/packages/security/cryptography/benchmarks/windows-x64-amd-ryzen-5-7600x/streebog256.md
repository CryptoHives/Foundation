| Description                                  | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-256 · Managed      | 128B         |     2.398 μs |  0.0096 μs |  0.0085 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128B         |     3.487 μs |  0.0297 μs |  0.0277 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128B         |     4.725 μs |  0.0297 μs |  0.0278 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 137B         |     2.382 μs |  0.0118 μs |  0.0110 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 137B         |     3.480 μs |  0.0364 μs |  0.0304 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 137B         |     4.317 μs |  0.0342 μs |  0.0303 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 1KB          |     9.196 μs |  0.0343 μs |  0.0304 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1KB          |    12.878 μs |  0.1082 μs |  0.0904 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1KB          |    16.399 μs |  0.1496 μs |  0.1249 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 1025B        |     8.968 μs |  0.0481 μs |  0.0427 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 1025B        |    12.903 μs |  0.1376 μs |  0.1287 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 1025B        |    16.414 μs |  0.1233 μs |  0.1029 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 8KB          |    63.212 μs |  0.4358 μs |  0.4076 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 8KB          |    87.549 μs |  0.4697 μs |  0.3922 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 8KB          |   113.398 μs |  0.6550 μs |  0.6127 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-256 · Managed      | 128KB        |   979.319 μs |  3.9000 μs |  3.6480 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost     | 128KB        | 1,382.359 μs | 10.2178 μs |  9.5578 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle | 128KB        | 1,781.089 μs | 15.4783 μs | 13.7211 μs |         - |