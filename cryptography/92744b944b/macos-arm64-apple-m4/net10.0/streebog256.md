| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.842 μs | 0.0035 μs | 0.0029 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.035 μs | 0.0019 μs | 0.0016 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     3.779 μs | 0.0041 μs | 0.0032 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.846 μs | 0.0029 μs | 0.0025 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.042 μs | 0.0023 μs | 0.0019 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     3.834 μs | 0.0058 μs | 0.0051 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.025 μs | 0.0112 μs | 0.0087 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.423 μs | 0.1244 μs | 0.1039 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    14.549 μs | 0.0315 μs | 0.0246 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.018 μs | 0.0120 μs | 0.0100 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.358 μs | 0.0110 μs | 0.0102 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    14.654 μs | 0.0187 μs | 0.0156 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    48.141 μs | 0.0508 μs | 0.0450 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.716 μs | 0.0909 μs | 0.0850 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    97.195 μs | 0.1256 μs | 0.1113 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   756.351 μs | 0.9169 μs | 0.8128 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,220.114 μs | 1.5032 μs | 1.3325 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,472.391 μs | 1.4388 μs | 1.2014 μs |         - |