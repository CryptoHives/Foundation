| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.493 μs | 0.0019 μs | 0.0017 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     3.534 μs | 0.0075 μs | 0.0059 μs |  13,088 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.390 μs | 0.0128 μs | 0.0107 μs |  20,302 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.674 μs | 0.0024 μs | 0.0022 μs |   7,702 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     3.546 μs | 0.0071 μs | 0.0059 μs |  13,807 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.384 μs | 0.0119 μs | 0.0093 μs |  19,997 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |     9.483 μs | 0.0101 μs | 0.0094 μs |   7,699 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    13.143 μs | 0.0982 μs | 0.0871 μs |  13,426 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    16.800 μs | 0.0430 μs | 0.0359 μs |  20,263 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |     9.460 μs | 0.0136 μs | 0.0113 μs |   7,701 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    13.167 μs | 0.1423 μs | 0.1111 μs |  14,110 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    16.769 μs | 0.0396 μs | 0.0331 μs |  20,049 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    65.576 μs | 0.0941 μs | 0.0735 μs |   7,697 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |    89.433 μs | 0.2005 μs | 0.1777 μs |  13,827 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   114.597 μs | 0.1599 μs | 0.1418 μs |  20,264 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,009.456 μs | 4.8662 μs | 4.0635 μs |   7,727 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,403.887 μs | 3.6114 μs | 3.0157 μs |  13,837 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,804.439 μs | 2.6336 μs | 2.3346 μs |  20,295 B |         - |