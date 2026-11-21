| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     1.904 μs | 0.0048 μs | 0.0042 μs |         - |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     2.949 μs | 0.0055 μs | 0.0046 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.016 μs | 0.0036 μs | 0.0030 μs |     408 B |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     1.944 μs | 0.0135 μs | 0.0126 μs |         - |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     2.956 μs | 0.0060 μs | 0.0056 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.027 μs | 0.0048 μs | 0.0040 μs |     408 B |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     7.281 μs | 0.0229 μs | 0.0214 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    11.322 μs | 0.0335 μs | 0.0313 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    11.387 μs | 0.0590 μs | 0.0461 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     7.291 μs | 0.0247 μs | 0.0231 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    11.334 μs | 0.0312 μs | 0.0292 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    11.390 μs | 0.0345 μs | 0.0269 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    50.291 μs | 0.1323 μs | 0.1238 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    77.485 μs | 0.2952 μs | 0.2761 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    79.581 μs | 0.2622 μs | 0.2452 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   790.530 μs | 2.3695 μs | 2.2164 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,206.559 μs | 1.0186 μs | 0.9528 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,235.140 μs | 2.3624 μs | 2.2098 μs |         - |