| Description                                  | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     2.413 μs |  0.0072 μs |  0.0064 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     3.397 μs |  0.0281 μs |  0.0235 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     4.263 μs |  0.0404 μs |  0.0358 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     2.425 μs |  0.0118 μs |  0.0110 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     3.404 μs |  0.0174 μs |  0.0155 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     5.126 μs |  0.0361 μs |  0.0320 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     8.968 μs |  0.0289 μs |  0.0256 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    12.809 μs |  0.1202 μs |  0.1004 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    16.401 μs |  0.1110 μs |  0.0984 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     9.185 μs |  0.0369 μs |  0.0345 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    12.796 μs |  0.0884 μs |  0.0739 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    16.370 μs |  0.1494 μs |  0.1398 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    65.082 μs |  0.3317 μs |  0.2770 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    87.807 μs |  0.4309 μs |  0.4031 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |   113.237 μs |  0.7758 μs |  0.6877 μs |         - |
|                                              |              |              |            |            |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        |   982.214 μs |  3.7511 μs |  3.5088 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,379.940 μs | 13.8898 μs | 12.9925 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,762.677 μs | 13.3714 μs | 12.5077 μs |         - |