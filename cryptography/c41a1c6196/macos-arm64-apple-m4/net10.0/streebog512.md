| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     1.860 μs |  0.0043 μs |  0.0038 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     2.993 μs |  0.0068 μs |  0.0061 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     3.843 μs |  0.0188 μs |  0.0176 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     1.860 μs |  0.0053 μs |  0.0050 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     2.996 μs |  0.0086 μs |  0.0081 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     3.814 μs |  0.0148 μs |  0.0139 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     7.074 μs |  0.0203 μs |  0.0190 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    11.331 μs |  0.0376 μs |  0.0352 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    14.801 μs |  0.0309 μs |  0.0289 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     7.084 μs |  0.0240 μs |  0.0213 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    11.352 μs |  0.0458 μs |  0.0428 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    14.741 μs |  0.0652 μs |  0.0578 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    49.032 μs |  0.1337 μs |  0.1044 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    78.163 μs |  0.1399 μs |  0.1309 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |    97.369 μs |  0.2644 μs |  0.2473 μs |         - |
|                                                    |              |              |            |            |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   770.728 μs |  1.9753 μs |  1.7510 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,241.688 μs | 24.5172 μs | 21.7339 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,493.420 μs |  6.6382 μs |  5.5432 μs |         - |