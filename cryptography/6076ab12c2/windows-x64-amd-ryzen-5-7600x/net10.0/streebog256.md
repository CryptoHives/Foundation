| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.716 μs | 0.0024 μs | 0.0021 μs |   7,248 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.982 μs | 0.0072 μs | 0.0064 μs |  13,907 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     5.012 μs | 0.0078 μs | 0.0073 μs |  16,922 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.701 μs | 0.0022 μs | 0.0019 μs |   7,244 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     4.601 μs | 0.0067 μs | 0.0063 μs |  13,937 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.899 μs | 0.0077 μs | 0.0072 μs |  16,326 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    10.238 μs | 0.0101 μs | 0.0095 μs |   7,253 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    14.704 μs | 0.0105 μs | 0.0093 μs |  13,937 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    19.506 μs | 0.0156 μs | 0.0146 μs |  16,948 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    10.238 μs | 0.0104 μs | 0.0093 μs |   7,251 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    14.773 μs | 0.0090 μs | 0.0075 μs |  14,674 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    18.857 μs | 0.0125 μs | 0.0111 μs |  16,369 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    70.605 μs | 0.0680 μs | 0.0636 μs |   7,251 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   100.726 μs | 0.0923 μs | 0.0818 μs |  14,464 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   130.024 μs | 0.1700 μs | 0.1591 μs |  16,948 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,107.341 μs | 3.1563 μs | 2.7980 μs |   7,289 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,579.306 μs | 0.8578 μs | 0.7163 μs |  14,409 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 2,036.035 μs | 3.0752 μs | 2.7261 μs |  16,952 B |         - |