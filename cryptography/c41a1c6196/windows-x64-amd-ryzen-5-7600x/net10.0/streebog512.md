| Description                                        | TestDataSize | Mean         | Error      | StdDev     | Median       | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|----------:|
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128B         |     2.926 μs |  0.0063 μs |  0.0056 μs |     2.926 μs |   7,211 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128B         |     3.945 μs |  0.0203 μs |  0.0180 μs |     3.947 μs |  13,085 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128B         |     4.941 μs |  0.0348 μs |  0.0309 μs |     4.936 μs |  11,876 B |         - |
|                                                    |              |              |            |            |              |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 137B         |     2.727 μs |  0.0075 μs |  0.0067 μs |     2.728 μs |   7,207 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 137B         |     3.942 μs |  0.0370 μs |  0.0346 μs |     3.934 μs |  13,937 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 137B         |     4.977 μs |  0.0250 μs |  0.0209 μs |     4.975 μs |  13,652 B |         - |
|                                                    |              |              |            |            |              |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1KB          |    10.336 μs |  0.0439 μs |  0.0367 μs |    10.318 μs |   7,216 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1KB          |    14.989 μs |  0.1851 μs |  0.1445 μs |    14.965 μs |  13,174 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1KB          |    18.888 μs |  0.1004 μs |  0.0939 μs |    18.855 μs |  11,885 B |         - |
|                                                    |              |              |            |            |              |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 1025B        |    12.092 μs |  0.2766 μs |  0.8155 μs |    11.517 μs |   7,214 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 1025B        |    15.001 μs |  0.1955 μs |  0.1632 μs |    14.978 μs |  14,341 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 1025B        |    18.932 μs |  0.0532 μs |  0.0472 μs |    18.913 μs |  13,682 B |         - |
|                                                    |              |              |            |            |              |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 8KB          |    71.394 μs |  0.3301 μs |  0.2577 μs |    71.372 μs |   7,214 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 8KB          |   102.629 μs |  0.6566 μs |  0.6448 μs |   102.410 μs |  13,551 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 8KB          |   130.755 μs |  0.5306 μs |  0.4431 μs |   130.754 μs |  11,885 B |         - |
|                                                    |              |              |            |            |              |           |           |
| TryComputeHash · Streebog-512 · CryptoHives-Scalar | 128KB        | 1,119.432 μs |  1.4120 μs |  1.1791 μs | 1,119.929 μs |   7,252 B |         - |
| TryComputeHash · Streebog-512 · OpenGost           | 128KB        | 1,614.428 μs | 23.9912 μs | 24.6372 μs | 1,606.049 μs |  13,554 B |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle       | 128KB        | 2,059.132 μs |  6.7268 μs |  5.9632 μs | 2,057.424 μs |  11,900 B |         - |