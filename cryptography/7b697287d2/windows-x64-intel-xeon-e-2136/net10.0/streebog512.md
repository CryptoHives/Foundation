| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     3.646 μs | 0.0027 μs | 0.0024 μs |   7,459 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     6.651 μs | 0.0053 μs | 0.0047 μs |  13,160 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     9.610 μs | 0.0093 μs | 0.0087 μs |  11,970 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     3.620 μs | 0.0026 μs | 0.0025 μs |   7,455 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     6.565 μs | 0.0034 μs | 0.0030 μs |  14,036 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     9.725 μs | 0.0066 μs | 0.0059 μs |  13,763 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    13.833 μs | 0.0190 μs | 0.0169 μs |   7,464 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    24.732 μs | 0.0176 μs | 0.0156 μs |  13,230 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    36.256 μs | 0.0146 μs | 0.0130 μs |  11,984 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    13.578 μs | 0.0261 μs | 0.0245 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    25.254 μs | 0.0782 μs | 0.0731 μs |  14,434 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    36.979 μs | 0.0347 μs | 0.0325 μs |  13,785 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    93.657 μs | 0.2652 μs | 0.2214 μs |   7,462 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   170.695 μs | 0.1451 μs | 0.1357 μs |  13,606 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   253.855 μs | 0.1105 μs | 0.0979 μs |  11,993 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,519.452 μs | 0.8041 μs | 0.7521 μs |   7,500 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 2,673.168 μs | 3.7900 μs | 3.5452 μs |  13,609 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 3,898.780 μs | 2.6302 μs | 2.4603 μs |  12,008 B |         - |