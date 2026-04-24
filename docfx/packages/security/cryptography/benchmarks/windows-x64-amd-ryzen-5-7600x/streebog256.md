| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.377 μs | 0.0042 μs | 0.0037 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.467 μs | 0.0319 μs | 0.0283 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.329 μs | 0.0325 μs | 0.0288 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.410 μs | 0.0062 μs | 0.0055 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.474 μs | 0.0428 μs | 0.0400 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.289 μs | 0.0175 μs | 0.0164 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.155 μs | 0.0312 μs | 0.0292 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    12.800 μs | 0.0952 μs | 0.0890 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.386 μs | 0.0905 μs | 0.0847 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.154 μs | 0.0201 μs | 0.0167 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    12.823 μs | 0.0670 μs | 0.0594 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    16.240 μs | 0.0796 μs | 0.0706 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    62.222 μs | 0.2465 μs | 0.2058 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    87.600 μs | 0.6162 μs | 0.5764 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   114.729 μs | 0.6431 μs | 0.5701 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   997.488 μs | 3.9279 μs | 3.4820 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,371.904 μs | 6.9799 μs | 5.8285 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,754.677 μs | 9.3372 μs | 8.2771 μs |         - |