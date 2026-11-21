| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128B         |     2.632 μs | 0.0018 μs | 0.0015 μs |  16,207 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128B         |     4.114 μs | 0.0084 μs | 0.0070 μs |  17,431 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128B         |     4.638 μs | 0.0298 μs | 0.0232 μs |  20,300 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 137B         |     2.640 μs | 0.0054 μs | 0.0045 μs |   9,877 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 137B         |     4.048 μs | 0.0369 μs | 0.0288 μs |  25,231 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 137B         |     4.621 μs | 0.0126 μs | 0.0111 μs |  22,086 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1KB          |    10.374 μs | 0.0187 μs | 0.0175 μs |   9,877 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1KB          |    14.870 μs | 0.0408 μs | 0.0382 μs |  17,376 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1KB          |    17.593 μs | 0.0265 μs | 0.0235 μs |  20,302 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 1025B        |    10.149 μs | 0.0175 μs | 0.0164 μs |  16,407 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 1025B        |    14.894 μs | 0.0307 μs | 0.0272 μs |  24,983 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 1025B        |    18.797 μs | 0.0360 μs | 0.0337 μs |  28,623 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 8KB          |    70.627 μs | 0.1727 μs | 0.1531 μs |  16,212 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 8KB          |   105.268 μs | 0.3378 μs | 0.2637 μs |  18,569 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 8KB          |   122.396 μs | 0.2145 μs | 0.1901 μs |  26,592 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Streebog-256 · CryptoHives-Scalar | 128KB        | 1,120.021 μs | 3.7678 μs | 3.3401 μs |  16,242 B |         - |
| TryComputeHash · Streebog-256 · OpenGost           | 128KB        | 1,603.842 μs | 8.1380 μs | 6.7956 μs |  17,868 B |     408 B |
| TryComputeHash · Streebog-256 · BouncyCastle       | 128KB        | 1,949.881 μs | 2.5698 μs | 2.1459 μs |  20,271 B |         - |