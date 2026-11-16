| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     3.583 μs | 0.0049 μs | 0.0043 μs |   7,459 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     6.834 μs | 0.0087 μs | 0.0082 μs |  13,978 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     9.495 μs | 0.0095 μs | 0.0089 μs |  17,100 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     3.667 μs | 0.0030 μs | 0.0028 μs |   7,455 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     7.305 μs | 0.0047 μs | 0.0039 μs |  14,020 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     9.423 μs | 0.0282 μs | 0.0264 μs |  16,483 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    13.887 μs | 0.0746 μs | 0.0698 μs |   7,464 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    25.421 μs | 0.0491 μs | 0.0435 μs |  14,010 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    36.357 μs | 0.1104 μs | 0.0979 μs |  17,113 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    13.675 μs | 0.1183 μs | 0.1107 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    25.195 μs | 0.0553 μs | 0.0491 μs |  14,736 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    42.462 μs | 0.2034 μs | 0.1902 μs |  16,546 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    97.274 μs | 1.4446 μs | 1.3513 μs |   7,462 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   172.584 μs | 0.2199 μs | 0.1949 μs |  14,557 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   251.189 μs | 0.3082 μs | 0.2883 μs |  17,147 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,544.492 μs | 0.7478 μs | 0.6995 μs |   7,500 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 2,687.560 μs | 5.9082 μs | 5.5266 μs |  14,487 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 3,855.657 μs | 2.3534 μs | 2.0862 μs |  17,146 B |         - |