| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.483 μs |  0.0134 μs |  0.0119 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.540 μs |  0.0269 μs |  0.0239 μs |  13,478 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.410 μs |  0.0336 μs |  0.0314 μs |  20,302 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.408 μs |  0.0071 μs |  0.0060 μs |   7,702 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.543 μs |  0.0225 μs |  0.0199 μs |  13,424 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.778 μs |  0.0227 μs |  0.0201 μs |  20,038 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.118 μs |  0.0414 μs |  0.0346 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    13.127 μs |  0.0898 μs |  0.0750 μs |  13,433 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.601 μs |  0.1234 μs |  0.1094 μs |  20,302 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.445 μs |  0.0243 μs |  0.0227 μs |   7,701 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    13.143 μs |  0.1079 μs |  0.1009 μs |  14,119 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    16.955 μs |  0.1406 μs |  0.1315 μs |  20,079 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    63.051 μs |  0.3067 μs |  0.2561 μs |   7,697 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    89.485 μs |  0.6887 μs |  0.6105 μs |  13,827 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   117.178 μs |  0.5736 μs |  0.5366 μs |  20,279 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,007.720 μs |  7.9564 μs |  7.0532 μs |   7,727 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,409.815 μs | 14.0762 μs | 13.1669 μs |  13,837 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,828.472 μs |  8.9587 μs |  8.3800 μs |  20,295 B |         - |