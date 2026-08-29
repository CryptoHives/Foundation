| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.464 μs |  0.0053 μs |  0.0049 μs |   7,541 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.479 μs |  0.0089 μs |  0.0079 μs |  12,474 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.412 μs |  0.0093 μs |  0.0083 μs |  12,229 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.342 μs |  0.0216 μs |  0.0202 μs |   7,544 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.994 μs |  0.0143 μs |  0.0119 μs |  13,055 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.464 μs |  0.0110 μs |  0.0086 μs |  17,671 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |     8.982 μs |  0.0364 μs |  0.0304 μs |   7,541 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    13.167 μs |  0.0577 μs |  0.0511 μs |  12,532 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    16.864 μs |  0.0531 μs |  0.0444 μs |  12,237 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |     8.997 μs |  0.0182 μs |  0.0170 μs |   7,543 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    13.180 μs |  0.0545 μs |  0.0455 μs |  13,428 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    16.864 μs |  0.3315 μs |  0.3101 μs |  17,673 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    60.895 μs |  0.1558 μs |  0.1301 μs |   7,539 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |    90.748 μs |  0.1990 μs |  0.1862 μs |  12,909 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   115.206 μs |  0.1793 μs |  0.1497 μs |  12,229 B |         - |
|                                                    |              |              |            |            |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        |   976.817 μs | 18.6551 μs | 15.5779 μs |   7,569 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,423.857 μs | 11.5394 μs | 10.7939 μs |  12,912 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 1,819.849 μs |  5.9602 μs |  5.2836 μs |  12,222 B |         - |