| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.712 μs | 0.0336 μs | 0.0281 μs |   7,459 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     5.081 μs | 0.0096 μs | 0.0085 μs |  13,653 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     6.871 μs | 0.0150 μs | 0.0133 μs |  17,120 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.664 μs | 0.0043 μs | 0.0038 μs |   7,455 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     5.026 μs | 0.0080 μs | 0.0071 μs |  13,995 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     6.842 μs | 0.0080 μs | 0.0071 μs |  16,483 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.997 μs | 0.0139 μs | 0.0130 μs |   7,464 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    18.653 μs | 0.0344 μs | 0.0321 μs |  14,010 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    26.687 μs | 0.0309 μs | 0.0274 μs |  17,114 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    10.207 μs | 0.0227 μs | 0.0213 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    18.936 μs | 0.0245 μs | 0.0229 μs |  14,747 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    26.826 μs | 0.0493 μs | 0.0461 μs |  16,547 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    69.894 μs | 0.1494 μs | 0.1397 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   127.789 μs | 0.3066 μs | 0.2718 μs |  14,557 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   186.704 μs | 0.6078 μs | 0.5388 μs |  17,141 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,151.038 μs | 1.9546 μs | 1.7327 μs |   7,500 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,976.221 μs | 2.8659 μs | 2.3932 μs |  14,487 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 2,894.405 μs | 5.3463 μs | 5.0009 μs |  17,146 B |         - |