| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.368 μs |  0.0068 μs |  0.0053 μs |   7,544 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.572 μs |  0.0166 μs |  0.0147 μs |  13,088 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.522 μs |  0.0158 μs |  0.0148 μs |  20,302 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.329 μs |  0.0068 μs |  0.0057 μs |   7,544 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.574 μs |  0.0214 μs |  0.0179 μs |  13,817 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.496 μs |  0.0581 μs |  0.0485 μs |  20,022 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     8.961 μs |  0.0171 μs |  0.0143 μs |   7,541 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    13.214 μs |  0.0645 μs |  0.0539 μs |  13,433 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.982 μs |  0.1094 μs |  0.1074 μs |  20,264 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     8.821 μs |  0.0194 μs |  0.0172 μs |   7,543 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    13.355 μs |  0.1900 μs |  0.1586 μs |  14,110 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    17.035 μs |  0.3305 μs |  0.4297 μs |  20,079 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    61.332 μs |  0.1362 μs |  0.1063 μs |   7,539 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    90.294 μs |  0.2009 μs |  0.1568 μs |  13,827 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   117.150 μs |  0.9958 μs |  0.8316 μs |  20,255 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   955.108 μs |  2.2491 μs |  1.7559 μs |   7,569 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,417.905 μs | 12.4677 μs | 10.4111 μs |  13,837 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,827.374 μs |  7.2467 μs |  6.4240 μs |  20,268 B |         - |