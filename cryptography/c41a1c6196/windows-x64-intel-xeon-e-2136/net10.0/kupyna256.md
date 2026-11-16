| Description                                      | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128B         |     4.429 μs |  0.0038 μs |  0.0034 μs |   5,421 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128B         |     6.666 μs |  0.0450 μs |  0.0398 μs |   3,947 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 137B         |     4.385 μs |  0.0030 μs |  0.0026 μs |   5,413 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 137B         |     6.668 μs |  0.0624 μs |  0.0584 μs |   4,719 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1KB          |    21.419 μs |  0.0181 μs |  0.0151 μs |   5,419 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1KB          |    32.437 μs |  0.6115 μs |  0.5720 μs |   3,923 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 1025B        |    21.446 μs |  0.0090 μs |  0.0084 μs |   5,424 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 1025B        |    33.067 μs |  0.4950 μs |  0.4630 μs |   4,706 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 8KB          |   157.412 μs |  0.0685 μs |  0.0641 μs |   5,421 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 8KB          |   238.312 μs |  3.4565 μs |  3.2332 μs |   3,923 B |         - |
|                                                  |              |              |            |            |           |           |
| TryComputeHash · Kupyna-256 · CryptoHives-Scalar | 128KB        | 2,489.202 μs |  1.0704 μs |  1.0012 μs |   5,444 B |         - |
| TryComputeHash · Kupyna-256 · BouncyCastle       | 128KB        | 3,736.964 μs | 34.3731 μs | 32.1526 μs |   3,942 B |         - |