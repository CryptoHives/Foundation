| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     8.742 μs | 0.0431 μs | 0.0337 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |    14.196 μs | 0.0182 μs | 0.0170 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |    17.666 μs | 0.0890 μs | 0.0832 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     8.735 μs | 0.0043 μs | 0.0038 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |    14.216 μs | 0.0191 μs | 0.0170 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |    17.925 μs | 0.0302 μs | 0.0282 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    33.153 μs | 0.0097 μs | 0.0086 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    53.385 μs | 0.0326 μs | 0.0289 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    69.385 μs | 0.0339 μs | 0.0283 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    33.168 μs | 0.0268 μs | 0.0238 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    53.188 μs | 0.0931 μs | 0.0727 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    69.518 μs | 0.0701 μs | 0.0656 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    47.461 μs | 0.1549 μs | 0.1373 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    78.166 μs | 0.4707 μs | 0.4173 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |    95.480 μs | 0.0332 μs | 0.0311 μs |         - |
|                                                    |              |              |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        |   742.488 μs | 3.8461 μs | 3.5976 μs |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,214.938 μs | 1.1236 μs | 0.9961 μs |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,431.011 μs | 1.3513 μs | 1.1979 μs |         - |