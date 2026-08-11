| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.472 μs |  0.0095 μs |  0.0074 μs |   7,699 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.514 μs |  0.0104 μs |  0.0093 μs |  12,474 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.392 μs |  0.0107 μs |  0.0094 μs |  12,220 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.506 μs |  0.0046 μs |  0.0041 μs |   7,702 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.519 μs |  0.0066 μs |  0.0051 μs |  13,061 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.433 μs |  0.0069 μs |  0.0058 μs |  17,671 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     9.735 μs |  0.0239 μs |  0.0211 μs |   7,699 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    13.221 μs |  0.0370 μs |  0.0309 μs |  12,532 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.912 μs |  0.0306 μs |  0.0255 μs |  12,234 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     9.510 μs |  0.0358 μs |  0.0335 μs |   7,698 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    13.467 μs |  0.1505 μs |  0.1408 μs |  13,428 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    17.107 μs |  0.2394 μs |  0.2122 μs |  17,678 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    67.796 μs |  0.4475 μs |  0.4186 μs |   7,697 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    93.395 μs |  1.5415 μs |  1.4419 μs |  12,909 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   118.647 μs |  1.2033 μs |  0.9395 μs |  12,241 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,045.725 μs | 11.2995 μs | 10.0167 μs |   7,727 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,431.959 μs |  8.6352 μs |  7.6549 μs |  12,912 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,866.716 μs |  6.0829 μs |  5.6899 μs |  12,222 B |         - |