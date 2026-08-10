| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.862 μs | 0.0010 μs | 0.0009 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.044 μs | 0.0025 μs | 0.0023 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.798 μs | 0.0082 μs | 0.0077 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.864 μs | 0.0040 μs | 0.0036 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.047 μs | 0.0034 μs | 0.0032 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.865 μs | 0.0100 μs | 0.0094 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.088 μs | 0.0044 μs | 0.0039 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.415 μs | 0.0108 μs | 0.0101 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.002 μs | 0.0319 μs | 0.0298 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.082 μs | 0.0039 μs | 0.0035 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.380 μs | 0.0471 μs | 0.0440 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    13.922 μs | 0.0117 μs | 0.0109 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.696 μs | 0.1142 μs | 0.1068 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    78.379 μs | 0.1458 μs | 0.1364 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    91.425 μs | 0.1492 μs | 0.1323 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   768.786 μs | 1.0296 μs | 0.9631 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,227.278 μs | 2.9190 μs | 2.5877 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,446.118 μs | 2.2232 μs | 2.0796 μs |         - |